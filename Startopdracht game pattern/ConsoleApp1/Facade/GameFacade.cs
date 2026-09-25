using GameApp.Subsystems;

namespace GameApp.Facade
{
    public class GameFacade
    {
        private readonly GraphicsSystem graphics;
        private readonly AudioSystem audio;
        private readonly SaveSystem saveSystem;
        private readonly NetworkService network;
        private readonly GameEngine gameEngine;
        private readonly DebugConsole debugConsole;

        private GameMode gameMode;
        private ConnectionMode connectionMode;
        private bool isRunning;

        public GameFacade(GraphicsSystem graphics,
                          AudioSystem audio,
                          SaveSystem saveSystem,
                          NetworkService network,
                          GameEngine gameEngine,
                          DebugConsole debugConsole)
        {
            this.graphics = graphics;
            this.audio = audio;
            this.saveSystem = saveSystem;
            this.network = network;
            this.gameEngine = gameEngine;
            this.debugConsole = debugConsole;
        }

        public void StartGame(GameMode gameMode, ConnectionMode connectionMode)
        {
            if (isRunning)
            {
                Console.WriteLine("De game draait al.");
                return;
            }

            this.gameMode = gameMode;
            this.connectionMode = connectionMode;

            Console.WriteLine($"--- Game starten ({gameMode}, {connectionMode}) ---");

            graphics.Initialize();
            audio.Initialize();

            if (gameMode == GameMode.Developer)
            {
                graphics.SetResolution(1280, 720);
                audio.SetVolume(0);
            }
            else
            {
                graphics.SetResolution(1920, 1080);
                audio.SetVolume(70);
            }

            saveSystem.LoadSettings();
            if (gameMode == GameMode.Developer)
            {
                saveSystem.LoadTestPlayer();
            }
            else
            {
                saveSystem.LoadPlayer();
            }

            if (connectionMode == ConnectionMode.Online)
            {
                network.Connect();
                network.Login();
            }

            if (gameMode == GameMode.Developer)
            {
                debugConsole.Enable();
                debugConsole.ShowFps();
                debugConsole.EnableCheats();
            }

            gameEngine.LoadWorld();
            gameEngine.Start();

            isRunning = true;
        }

        public void StopGame()
        {
            if (!isRunning)
            {
                Console.WriteLine("Er draait geen game.");
                return;
            }

            Console.WriteLine($"--- Game stoppen ({gameMode}, {connectionMode}) ---");

            gameEngine.Stop();
            gameEngine.UnloadWorld();

            if (gameMode == GameMode.Developer)
            {
                debugConsole.WriteLogFile();
                debugConsole.Disable();
            }
            else
            {
                saveSystem.SavePlayer();
            }
            saveSystem.SaveSettings();

            if (connectionMode == ConnectionMode.Online)
            {
                network.Logout();
                network.Disconnect();
            }

            audio.Shutdown();
            graphics.Shutdown();

            isRunning = false;
        }
    }
}
