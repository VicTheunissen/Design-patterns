namespace GameApp.Subsystems
{
    public class DebugConsole
    {
        public void Enable()
        {
            Console.WriteLine("[DEV] Debugconsole geactiveerd.");
        }

        public void ShowFps()
        {
            Console.WriteLine("[DEV] FPS-teller zichtbaar.");
        }

        public void EnableCheats()
        {
            Console.WriteLine("[DEV] Cheats ingeschakeld (god mode, noclip).");
        }

        public void WriteLogFile()
        {
            Console.WriteLine("[DEV] Debuglog weggeschreven naar debug.log.");
        }

        public void Disable()
        {
            Console.WriteLine("[DEV] Debugconsole gedeactiveerd.");
        }
    }
}
