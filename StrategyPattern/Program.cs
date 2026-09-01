using StrategyPattern.Ducks;
using StrategyPattern.Interfaces.FlyBehavior;

namespace StrategyPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Duck mallardDuck = new MallardDuck();
            Duck redheadDuck = new RedheadDuck();
            Duck decoyDuck = new DecoyDuck();
            Duck rubberDuck = new RubberDuck();
            
            mallardDuck.PerformQuack();
            redheadDuck.PerformQuack();
            decoyDuck.PerformQuack();
            rubberDuck.PerformQuack();

            mallardDuck.PerformFly();
            redheadDuck.PerformFly();
            decoyDuck.PerformFly();
            rubberDuck.PerformFly();
        }
    }
}