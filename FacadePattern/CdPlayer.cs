using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern
{
    internal class CdPlayer
    {
        private Amplifier _amplifier;
        public CdPlayer(Amplifier amplifier)
        {
            _amplifier = amplifier;
        }

        public void On()
        {
            Console.WriteLine("CD player: On");
        }
        public void Off()
        {
            Console.WriteLine("CD player: Off");
        }
        public void Eject()
        {
            Console.WriteLine("CD player: Eject");
        }
        public void Pause()
        {
            Console.WriteLine("CD player: Pause");
        }
        public void Play()
        {
            Console.WriteLine("CD player: Play");
        }
        public void Stop()
        {
            Console.WriteLine("CD player: Stop");
        }
    }
}
