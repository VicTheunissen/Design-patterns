using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern
{
    internal class Tuner
    {
        private Amplifier _amplifier;
        public Tuner(Amplifier amplifier)
        {
            this._amplifier = amplifier;
        }

        public void On()
        {
            Console.WriteLine("Tuner: On");
        }

        public void Off()
        {
            Console.WriteLine("Tuner: Off");
        }

        public void setAM()
        {
            Console.WriteLine("Tuner: AM mode");
        }

        public void setFM()
        {
            Console.WriteLine("Tuner: FM mode");
        }

        public void setFrequency()
        {
            Console.WriteLine("Tuner: frequency set");
        }

    }
}
