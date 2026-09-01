using StrategyPattern.Interfaces.FlyBehavior;
using StrategyPattern.Interfaces.QuackBehavior;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.Ducks
{
    internal abstract class Duck
    {
        public abstract void Display();

        public void PerformQuack()
        {
        }

        public void PerformFly()
        {
        }
        public void Swim()
        {
            Console.WriteLine("All ducks float, even decoys!");
        }
    }
}
