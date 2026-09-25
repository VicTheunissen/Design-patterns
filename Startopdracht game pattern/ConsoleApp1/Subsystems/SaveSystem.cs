namespace GameApp.Subsystems
{
    public class SaveSystem
    {
        public void LoadPlayer()
        {
            Console.WriteLine("Spelergegevens geladen.");
        }

        public void LoadTestPlayer()
        {
            Console.WriteLine("Testspeler geladen (alle levels ontgrendeld).");
        }

        public void LoadSettings()
        {
            Console.WriteLine("Instellingen geladen.");
        }

        public void SavePlayer()
        {
            Console.WriteLine("Spelergegevens opgeslagen.");
        }

        public void SaveSettings()
        {
            Console.WriteLine("Instellingen opgeslagen.");
        }
    }
}
