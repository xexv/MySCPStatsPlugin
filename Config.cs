using Exiled.API.Interfaces;
using System.ComponentModel;

public class Config : IConfig
{
    [Description("Enable Plugin?")]
    public bool IsEnabled { get; set; } = true;
    [Description("Debug mode?(for devs)")]
    public bool Debug { get; set; } = false;
    [Description("Путь к файлу базы данных LiteDB.")]
    public string DatabasePath { get; set; } = "MySCPStats.db";
    [Description("Webhook URL для отправки обновлений лидерборда в Discord.")]
    public string DiscordWebhookUrl { get; set; } = "YOUR_WEBHOOK_URL_HERE";
}
