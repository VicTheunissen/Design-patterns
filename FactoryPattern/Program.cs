namespace FactoryPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // De client praat alleen met de store en kiest uit de enum.
            // Er staat hier geen enkele 'new' van een concrete drank.
            CoffeeStore store = new StarbuzzCoffeeStore();

            store.OrderCoffee(CoffeeType.Cappuccino);
            store.OrderCoffee(CoffeeType.Mocha);
            store.OrderCoffee(CoffeeType.IrishCoffee);

            Console.WriteLine("===== Alle dranken op de kaart =====");
            Console.WriteLine();

            foreach (CoffeeType type in Enum.GetValues<CoffeeType>())
            {
                store.OrderCoffee(type);
            }

            Console.ReadLine();
        }
    }
}
