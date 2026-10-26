namespace FactoryPattern
{
    public class Lemon : CondimentDecorator
    {
        public Lemon(Beverage beverage)
            : base(beverage)
        {
        }

        public override string GetDescription()
        {
            return beverage.GetDescription() + ", Lemon";
        }
    }
}
