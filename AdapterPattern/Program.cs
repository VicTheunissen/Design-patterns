using AdapterPattern.Geese;
using AdapterPattern.Interfaces;
using AdapterPattern.Turkeys;
using System;

namespace AdapterPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MallardDuck duck = new MallardDuck();
            WildTurkey turkey = new WildTurkey();
            WildGoose goose = new WildGoose();

            Duck turkeyAdapter = new TurkeyAdapter(turkey);
            Duck gooseAdapter = new GooseAdapter(goose);

            Console.WriteLine("The Turkey says...");
            turkey.Gobble();
            turkey.Fly();

            Console.WriteLine("The Goose says...");
            goose.Honk();
            goose.Fly();

            Console.WriteLine("The Duck says...");
            TestDuck(duck);

            Console.WriteLine("The TurkeyAdapter says...");
            TestDuck(turkeyAdapter);

            Console.WriteLine("The GooseAdapter says...");
            TestDuck(gooseAdapter);
        }

        static void TestDuck(Duck duck)
        {
            duck.Quack();
            duck.Fly();
        }
    }
}
