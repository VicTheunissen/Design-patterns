namespace FactoryPattern
{
    public class Water : CondimentDecorator
    {
        public Water(Beverage beverage)
            : base(beverage)
        {
        }

        public override string GetDescription()
        {
            return beverage.GetDescription() + ", Water";
        }
    }
}
