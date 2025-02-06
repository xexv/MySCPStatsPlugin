using LiteDB;
using System.Collections.Generic;
using System.Linq;

public static class DatabaseManager
{
    private static readonly string DatabasePath = MySCPStatsPlugin.Instance.Config.DatabasePath;

    public static void UpdatePlayerStats(string userId, string playerName, int kills = 0, int escapes = 0, int scpKills = 0)
    {
        using (var db = new LiteDatabase(DatabasePath))
        {
            var col = db.GetCollection<PlayerStats>("player_stats");
            var stats = col.FindOne(p => p.UserId == userId);

            if (stats == null)
            {
                stats = new PlayerStats
                {
                    UserId = userId,
                    PlayerName = playerName,
                    Kills = kills,
                    Escapes = escapes,
                    ScpKills = scpKills
                };
                col.Insert(stats);
            }
            else
            {
                stats.Kills += kills;
                stats.Escapes += escapes;
                stats.ScpKills += scpKills;
                stats.PlayerName = playerName;
                col.Update(stats);
            }
        }
    }

    public static List<PlayerStats> GetTopPlayers(int count)
    {
        using (var db = new LiteDatabase(DatabasePath))
        {
            var col = db.GetCollection<PlayerStats>("player_stats");
            return col.FindAll()
                      .OrderByDescending(p => p.Kills)
                      .ThenByDescending(p => p.Escapes)
                      .ThenByDescending(p => p.ScpKills)
                      .Take(count)
                      .ToList();
        }
    }

    public static PlayerStats GetPlayerStats(string userId)
    {
        using (var db = new LiteDatabase(DatabasePath))
        {
            var col = db.GetCollection<PlayerStats>("player_stats");
            var stats = col.FindOne(p => p.UserId == userId);
            if (stats == null)
            {
                return new PlayerStats
                {
                    UserId = userId,
                    PlayerName = "Неизвестный",
                    Kills = 0,
                    Escapes = 0,
                    ScpKills = 0
                };
            }

            var rankedList = col.FindAll()
                                .OrderByDescending(p => p.Kills)
                                .ThenByDescending(p => p.Escapes)
                                .ThenByDescending(p => p.ScpKills)
                                .ToList();

            stats.Rank = rankedList.FindIndex(p => p.UserId == userId) + 1;
            return stats;
        }
    }
}
