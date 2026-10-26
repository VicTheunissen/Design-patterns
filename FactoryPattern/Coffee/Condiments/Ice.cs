namespace FactoryPattern
{
    public class Ice : CondimentDecorator
    {
        public Ice(Beverage beverage)
            : base(beverage)
        {
        }

        public override string GetDescription()
        {
            return beverage.GetDescription() + ", Ice";
        }
    }
}
