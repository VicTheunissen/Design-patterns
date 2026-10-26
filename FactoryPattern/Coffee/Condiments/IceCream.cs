namespace FactoryPattern
{
    public class IceCream : CondimentDecorator
    {
        public IceCream(Beverage beverage)
            : base(beverage)
        {
        }

        public override string GetDescription()
        {
            return beverage.GetDescription() + ", Ice Cream";
        }
    }
}
