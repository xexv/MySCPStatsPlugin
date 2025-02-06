using Exiled.Events.EventArgs.Player;
using Exiled.Events.EventArgs.Server;

public class EventHandlers
{
    public void OnPlayerDeath(DiedEventArgs ev)
    {
        if (ev.Attacker == null || ev.Player == null)
            return;

        if (ev.Attacker.IsScp)
        {
            DatabaseManager.UpdatePlayerStats(ev.Attacker.UserId, ev.Attacker.Nickname, scpKills: 1);
        }
        else
        {
            DatabaseManager.UpdatePlayerStats(ev.Attacker.UserId, ev.Attacker.Nickname, kills: 1);
        }
    }

    public void OnPlayerEscape(EscapingEventArgs ev)
    {
        if (ev.Player == null)
            return;

        DatabaseManager.UpdatePlayerStats(ev.Player.UserId, ev.Player.Nickname, escapes: 1);
    }

    public void OnRoundEnd(RoundEndedEventArgs ev)
    {
        DiscordWebhook.SendLeaderboardUpdate();
    }
}

