using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;



string filePath = "data.json";
string json = File.ReadAllText(filePath);
List<NBAPlayer> players = JsonConvert.DeserializeObject<List<NBAPlayer>>(json);



List<NBAPlayer> gsw = players.Where(p => p.team == "GSW").ToList();
Console.WriteLine("================== Golden State Warriors ==================");
foreach (NBAPlayer player in gsw)
{
    Console.WriteLine($"{player.player.PadLeft(20)} - {player.position.PadLeft(2)} | Pts: {player.pts}, Rpg: {player.rpg}, Apg: {player.apg}");
}
Console.WriteLine();



List<NBAPlayer> topScorers = players.OrderByDescending(p => p.pts).Take(11).ToList();
Console.WriteLine("========================== Top Scorers =========================");
foreach (NBAPlayer player in topScorers)
{
    Console.WriteLine($"{player.player.PadLeft(25)} - {player.position.PadLeft(3)} | Pts: {player.pts}, Rpg: {player.rpg}, Apg: {player.apg}");
}
Console.WriteLine();



Console.WriteLine("===================== HOF ====================");
NBAPlayer scorer = new NBAPlayer();
for (int i = 0; i < players.Count; i++)
{
    if (players[i].pts > scorer.pts)
    {
        scorer = players[i];
    }
}
Console.WriteLine($"{"Scorer".PadLeft(10)} | {scorer.player.PadLeft(20)} - {scorer.position.PadLeft(2)} | PPG: {scorer.pts}");

NBAPlayer shooter = new NBAPlayer();
for (int i = 0; i < players.Count; i++)
{
    if (players[i].three_pm > shooter.three_pm)
    {
        shooter = players[i];
    }
}
Console.WriteLine($"{"Shooter".PadLeft(10)} | {shooter.player.PadLeft(20)} - {shooter.position.PadLeft(2)} | 3PG: {shooter.three_pm}");

NBAPlayer dimer = new NBAPlayer();
for (int i = 0; i < players.Count; i++)
{
    if (players[i].apg > dimer.apg)
    {
        dimer = players[i];
    }
}
Console.WriteLine($"{"Dimer".PadLeft(10)} | {dimer.player.PadLeft(20)} - {dimer.position.PadLeft(2)} | APG: {dimer.apg}");

NBAPlayer rebounder = new NBAPlayer();
for (int i = 0; i < players.Count; i++)
{
    if (players[i].rpg > rebounder.rpg)
    {
        rebounder = players[i];
    }
}
Console.WriteLine($"{"Rebounder".PadLeft(10)} | {rebounder.player.PadLeft(20)} - {rebounder.position.PadLeft(2)} | RPG: {rebounder.rpg}");

NBAPlayer defender = new NBAPlayer();
for (int i = 0; i < players.Count; i++)
{
    if (players[i].blkpg + players[i].stpg > defender.blkpg + defender.stpg)
    {
        defender = players[i];
    }
}
Console.WriteLine($"{"Defender".PadLeft(10)} | {defender.player.PadLeft(20)} - {defender.position.PadLeft(2)} | SPG+BPG: {defender.blkpg + defender.stpg}");





public class NBAPlayer
{
    public string player { get; set; } = "";
    public string team { get; set; } = "";
    public string position { get; set; } = "";
    public double pts { get; set; }
    public double rpg { get; set; }
    public double apg { get; set; }
    public double three_pm { get; set; }
    public double stpg { get; set; }
    public double blkpg { get; set; }
}
