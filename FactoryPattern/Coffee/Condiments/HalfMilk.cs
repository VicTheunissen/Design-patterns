namespace FactoryPattern
{
    public class HalfMilk : CondimentDecorator
    {
        public HalfMilk(Beverage beverage)
            : base(beverage)
        {
        }

        public override string GetDescription()
        {
            return beverage.GetDescription() + ", Half Milk";
        }
    }
}
