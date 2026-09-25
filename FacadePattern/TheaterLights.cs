using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern
{
    internal class TheaterLights
    {
        public void On()
        {
            Console.WriteLine("Theater lights: On");
        }

        public void Off()
        {
            Console.WriteLine("Theater lights: Off");
        }

        public void Dim(int value)
        {
            Console.WriteLine($"Theater lights: dimming to {value}%");
        }
    }
}
