using lab_2;

class Program
{
    public static void Main(string[] args)
    {
        UpgradedGameAccount Davyd = new UpgradedGameAccount("Davyd");
        PremiumGameAccount Player2 = new PremiumGameAccount("Player2");

        GameType gameType = new GameType();

        List<Start> games = new List<Start> { gameType.getBasicGame(), gameType.getRankedGame(), gameType.getSafeGame() };

        foreach (var game in games)
        {
            game.PlayGame(Player2, Davyd);
        }

        Console.Write("Davyd rating:");
        Console.WriteLine(Davyd.CurrentRating);
        Console.WriteLine("Davyd Stats:");
        Console.WriteLine(Davyd.GetStats());

        Console.Write("Player2 rating:");
        Console.WriteLine(Player2.CurrentRating);
        Console.WriteLine("Player2 stats:");
        Console.WriteLine(Player2.GetStats());

        Console.ReadKey();
    }
}
