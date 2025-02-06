using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

public static class DiscordWebhook
{
    private static readonly HttpClient HttpClient = new HttpClient();

    public static async Task SendLeaderboardUpdate()
    {
        var leaderboard = DatabaseManager.GetTopPlayers(10);
        var content = new
        {
            content = FormatLeaderboard(leaderboard)
        };
        var json = Newtonsoft.Json.JsonConvert.SerializeObject(content);
        var data = new StringContent(json, Encoding.UTF8, "application/json");

        var webhookUrl = MySCPStatsPlugin.Instance.Config.DiscordWebhookUrl;
        await HttpClient.PostAsync(webhookUrl, data);
    }

    private static string FormatLeaderboard(System.Collections.Generic.List<PlayerStats> leaderboard)
    {
        var sb = new StringBuilder();
        sb.AppendLine("**Топ 10 игроков:**");
        for (int i = 0; i < leaderboard.Count; i++)
        {
            var player = leaderboard[i];
            sb.AppendLine($"{i + 1}. {player.PlayerName} - Убийств: {player.Kills}, Побегов: {player.Escapes}, Убийств SCP: {player.ScpKills}");
        }
        return sb.ToString();
    }
}
