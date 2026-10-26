namespace FactoryPattern
{
    // De procedure voor het bestellen blijft altijd hetzelfde.
    // Welke drank er precies gemaakt wordt, beslist de subclass in de
    // factory method CreateCoffee.
    public abstract class CoffeeStore
    {
        public Beverage OrderCoffee(CoffeeType type)
        {
            Beverage coffee = CreateCoffee(type);

            Console.WriteLine($"Bestelling: {type}");
            Console.WriteLine($"Bevat: {coffee.GetDescription()}");
            Console.WriteLine();

            return coffee;
        }

        // Factory method
        protected abstract Beverage CreateCoffee(CoffeeType type);
    }
}
