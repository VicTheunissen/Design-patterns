using AdapterPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern.Geese
{
    internal class WildGoose : Goose
    {
        public void Fly()
        {
            Console.WriteLine("I'm flying");
        }

        public void Honk()
        {
            Console.WriteLine("Honk");
        }
    }
}
