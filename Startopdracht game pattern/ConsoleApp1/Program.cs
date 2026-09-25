using GameApp.Facade;
using GameApp.Subsystems;

namespace GameApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameFacade game = new GameFacade(
                new GraphicsSystem(),
                new AudioSystem(),
                new SaveSystem(),
                new NetworkService(),
                new GameEngine(),
                new DebugConsole());

            GameMode gameMode = AskGameMode();
            ConnectionMode connectionMode = AskConnectionMode();
            Console.WriteLine();

            game.StartGame(gameMode, connectionMode);

            Console.WriteLine();
            Console.WriteLine("Druk op Enter om de game te stoppen...");
            Console.ReadLine();

            game.StopGame();

            Console.WriteLine();
            Console.WriteLine("Druk op Enter om af te sluiten...");
            Console.ReadLine();
        }

        static GameMode AskGameMode()
        {
            Console.WriteLine("Kies een modus: [1] Normal  [2] Developer");
            return Console.ReadLine()?.Trim() == "2" ? GameMode.Developer : GameMode.Normal;
        }

        static ConnectionMode AskConnectionMode()
        {
            Console.WriteLine("Kies verbinding: [1] Online  [2] Offline");
            return Console.ReadLine()?.Trim() == "2" ? ConnectionMode.Offline : ConnectionMode.Online;
        }
    }
}
