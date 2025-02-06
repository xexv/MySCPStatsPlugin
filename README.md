Here’s an English README for your project:

---

# SCP:SL Player Stats Plugin

This plugin for **SCP: Secret Laboratory** tracks and stores player statistics in a database, displaying player leaderboards and individual player stats both in-game and through Discord integration.

## Features

- Tracks player statistics such as kills, escapes, and SCP kills.
- Displays player leaderboards in the console with the command `.leaderboard`.
- Integrates with Discord using a webhook to send player statistics to a designated channel.
- Uses **LiteDB** for storing player data in a local database.

## Installation

1. Download dll file.
2. Place the plugin files in your **SCP: Secret Laboratory** server’s `Plugins` folder (in Exiled/Plugins).
3. Dependencies: LiteDB.dll.
4. Open the plugin’s configuration file and set the following:
    - Path to your database file.
    - Your **Discord Webhook URL**.

## Project Structure

```
SCPStatsPlugin/
├── DatabaseManager.cs       # Handles database operations.
├── EventHandlers.cs         # Event handlers for game-related actions.
├── PlayerStats.cs           # Defines the player stats class.
├── Plugin.cs                # Main plugin class.
├── config.json              # Plugin configuration.
└── README.md                # Project documentation.
```

## Configuration

The plugin’s configuration is stored in the `config.json` file. Here’s an example:

```json
{
  "DatabasePath": "C:/path/to/MySCPStats.db",
  "DiscordWebhookUrl": "https://discord.com/api/webhooks/your-webhook-url"
}
```

### Configuration Parameters:

- **DatabasePath**: Path to the LiteDB database file where player stats will be stored.
- **DiscordWebhookUrl**: URL for your Discord webhook to send player statistics to a Discord channel.

## Usage

- After installing the plugin and configuring it, start your SCP:SL server.
- Players can view the leaderboard by typing `.leaderboard` in the game console.
- The plugin will automatically update player statistics upon relevant events (such as kills or escapes).

## License

This project is licensed under the MIT License.

---

Let me know if you need further adjustments or additions!