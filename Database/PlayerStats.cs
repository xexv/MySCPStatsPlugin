public class PlayerStats
{
    public int Id { get; set; }  // LiteDB автоматически создает ID
    public string UserId { get; set; }
    public string PlayerName { get; set; }
    public int Kills { get; set; }
    public int Escapes { get; set; }
    public int ScpKills { get; set; }
    public int Rank { get; set; } // Это поле не сохраняется, а вычисляется при запросе
}
