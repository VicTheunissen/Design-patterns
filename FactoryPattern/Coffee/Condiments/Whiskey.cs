namespace FactoryPattern
{
    public class Whiskey : CondimentDecorator
    {
        public Whiskey(Beverage beverage)
            : base(beverage)
        {
        }

        public override string GetDescription()
        {
            return beverage.GetDescription() + ", Whiskey";
        }
    }
}
