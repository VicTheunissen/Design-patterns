namespace FactoryPattern
{
    public class Whip : CondimentDecorator
    {
        public Whip(Beverage beverage)
            : base(beverage)
        {
        }

        public override string GetDescription()
        {
            return beverage.GetDescription() + ", Whip";
        }
    }
}
