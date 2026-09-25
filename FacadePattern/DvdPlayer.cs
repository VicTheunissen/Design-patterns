using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern
{
    internal class DvdPlayer
    {
        private Amplifier _amplifier;
        public DvdPlayer(Amplifier amplifier)
        {
            _amplifier = amplifier;
        }

        public void On()
        {
            Console.WriteLine("DVD player: On");
        }
        public void Off()
        {
            Console.WriteLine("DVD player: Off");
        }
        public void Eject()
        {
            Console.WriteLine("DVD player: Eject");
        }
        public void Pause()
        {
            Console.WriteLine("DVD player: Pause");
        }
        public void Play(string movie)
        {
            Console.WriteLine($"DVD player: playing \"{movie}\"");
        }
        public void SetSurroundAudio()
        {
            Console.WriteLine("DVD player: surround audio");
        }
        public void SetTWoChannelAudio()
        {
            Console.WriteLine("DVD player: two channel audio");
        }
        public void Stop()
        {
            Console.WriteLine("DVD player: Stop");
        }
    }
}
