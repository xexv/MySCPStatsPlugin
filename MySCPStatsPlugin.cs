using Exiled.API.Features;
using System;

public class MySCPStatsPlugin : Plugin<Config>
{
    public static MySCPStatsPlugin Instance { get; private set; }

    private EventHandlers eventHandlers;

    public override string Author => "xexv";
    public override string Name => "MySCPStatsPlugin";
    public override string Prefix => "MSSP";
    public override Version Version => base.Version;

    public override void OnEnabled()
    {
        Instance = this;
        eventHandlers = new EventHandlers();

        Exiled.Events.Handlers.Player.Died += eventHandlers.OnPlayerDeath;
        Exiled.Events.Handlers.Player.Escaping += eventHandlers.OnPlayerEscape;
        Exiled.Events.Handlers.Server.RoundEnded += eventHandlers.OnRoundEnd;

        Log.Info("MySCPStatsPlugin успешно загружен!");
        base.OnEnabled();
    }

    public override void OnDisabled()
    {
        Exiled.Events.Handlers.Player.Died -= eventHandlers.OnPlayerDeath;
        Exiled.Events.Handlers.Player.Escaping -= eventHandlers.OnPlayerEscape;
        Exiled.Events.Handlers.Server.RoundEnded -= eventHandlers.OnRoundEnd;

        eventHandlers = null;
        Instance = null;

        Log.Info("MySCPStatsPlugin отключен.");
        base.OnDisabled();
    }
}
