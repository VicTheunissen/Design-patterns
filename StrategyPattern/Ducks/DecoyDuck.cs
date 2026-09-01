using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.Ducks
{
    internal class DecoyDuck : Duck
    {
        public DecoyDuck()
        {
            quackBehavior = new Squeak();
            flyBehavior = new FlyNoWay();
        }
        public override void Display()
        {
            Console.WriteLine("I'm a Decoy Duck");
        }
    }
}
