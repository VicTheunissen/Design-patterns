using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern
{
    // Facade: één simpele interface voor het hele home theater subsysteem.
    // De facade is "composed" (HAS-A) met alle componenten van het subsysteem.
    internal class HomeTheaterFacade
    {
        private Amplifier _amp;
        private Tuner _tuner;
        private DvdPlayer _dvdPlayer;
        private CdPlayer _cdPlayer;
        private Projector _projector;
        private TheaterLights _lights;
        private Screen _screen;
        private PopcornPopper _popper;

        public HomeTheaterFacade(Amplifier amp, Tuner tuner, DvdPlayer dvdPlayer, CdPlayer cdPlayer,
            Projector projector, Screen screen, TheaterLights lights, PopcornPopper popper)
        {
            _amp = amp;
            _tuner = tuner;
            _dvdPlayer = dvdPlayer;
            _cdPlayer = cdPlayer;
            _projector = projector;
            _screen = screen;
            _lights = lights;
            _popper = popper;
        }

        public void WatchMovie(string movie)
        {
            Console.WriteLine("Get ready to watch a movie...");
            _popper.On();
            _popper.Pop();
            _lights.Dim(10);
            _screen.Down();
            _projector.On();
            _projector.SetInput(_dvdPlayer);
            _projector.WideScreenMode();
            _amp.On();
            _amp.SetDvd(_dvdPlayer);
            _amp.SetSurroundSound();
            _amp.SetVolume(5);
            _dvdPlayer.On();
            _dvdPlayer.Play(movie);
        }

        public void EndMovie()
        {
            Console.WriteLine("Shutting movie theater down...");
            _popper.Off();
            _lights.On();
            _screen.Up();
            _projector.Off();
            _amp.Off();
            _dvdPlayer.Stop();
            _dvdPlayer.Eject();
            _dvdPlayer.Off();
        }
    }
}
