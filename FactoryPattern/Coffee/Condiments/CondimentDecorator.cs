namespace FactoryPattern
{
    // Basis Decorator voor koffie:
    // IS-A  Beverage -> kan weer ingepakt worden door een ander condiment
    // HAS-A Beverage -> de drank waar dit condiment aan toegevoegd wordt
    public abstract class CondimentDecorator : Beverage
    {
        protected Beverage beverage;

        public CondimentDecorator(Beverage beverage)
        {
            this.beverage = beverage;
        }
    }
}
