namespace FactoryPattern
{
    public class Milk : CondimentDecorator
    {
        public Milk(Beverage beverage)
            : base(beverage)
        {
        }

        public override string GetDescription()
        {
            return beverage.GetDescription() + ", Milk";
        }
    }
}
