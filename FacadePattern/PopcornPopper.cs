using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern
{
    internal class PopcornPopper
    {
        public void On()
        {
            Console.WriteLine("Popcorn popper: On");
        }

        public void Off()
        {
            Console.WriteLine("Popcorn popper: Off");
        }

        public void Pop()
        {
            Console.WriteLine("Popcorn popper: popping popcorn!");
        }
    }
}
