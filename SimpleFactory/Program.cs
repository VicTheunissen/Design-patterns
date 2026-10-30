namespace SimpleFactory
{
    internal class Program
    {
        static void Main(string[] args)
        {

            NYPizzaFactory nyFactory = new NYPizzaFactory();
            PizzaStore nyStore = new PizzaStore(nyFactory);
            nyStore.OrderPizza("Veggie");

            ChicagoPizzaFactory chicagoFactory = new ChicagoPizzaFactory();
            PizzaStore chicagoStore = new PizzaStore(chicagoFactory);
            chicagoStore.OrderPizza("Veggie");
        }
    }
}