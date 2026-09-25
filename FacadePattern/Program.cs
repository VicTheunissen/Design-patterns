namespace FacadePattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Amplifier amp = new Amplifier();
            CdPlayer cdPlayer = new CdPlayer(amp);
            DvdPlayer dvdPlayer = new DvdPlayer(amp);
            PopcornPopper popcornPopper = new PopcornPopper();
            Projector projector = new Projector();
            Screen screen = new Screen();
            TheaterLights lights = new TheaterLights();
            Tuner tuner = new Tuner(amp);

            HomeTheaterFacade homeTheater = new HomeTheaterFacade(
                amp, tuner, dvdPlayer, cdPlayer, projector, screen, lights, popcornPopper);

            homeTheater.WatchMovie("Die Hard");
            Console.WriteLine();
            homeTheater.EndMovie();

            // Houd het consolevenster open zodat de output zichtbaar blijft
            Console.WriteLine();
            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();
        }
    }
}
