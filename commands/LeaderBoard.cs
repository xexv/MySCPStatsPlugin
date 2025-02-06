using CommandSystem;
using Exiled.API.Features;
using System;
using System.Text;
using ICommand = CommandSystem.ICommand;

[CommandHandler(typeof(ClientCommandHandler))]
public class LeaderboardCommand : ICommand
{
    public string Command => "leaderboard";
    public string[] Aliases => Array.Empty<string>();
    public string Description => "Показывает топ 10 игроков и вашу текущую статистику.";

    public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
    {
        var player = Player.Get(sender);
        if (player == null)
        {
            response = "Команда доступна только для игроков.";
            return false;
        }

        var leaderboard = DatabaseManager.GetTopPlayers(10);
        var playerStats = DatabaseManager.GetPlayerStats(player.UserId);

        var sb = new StringBuilder();
        sb.AppendLine("Топ 10 игроков:");
        for (int i = 0; i < leaderboard.Count; i++)
        {
            var p = leaderboard[i];
            sb.AppendLine($"[{i + 1}] {p.PlayerName} - Убийств: {p.Kills}, Побегов: {p.Escapes}, Убийств SCP: {p.ScpKills}");
        }

        sb.AppendLine($"\nВаша статистика:\n[{playerStats.Rank}] {playerStats.PlayerName} - Убийств: {playerStats.Kills}, Побегов: {playerStats.Escapes}, Убийств SCP: {playerStats.ScpKills}");

        response = sb.ToString();
        return true;
    }
}
