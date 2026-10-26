namespace FactoryPattern
{
    public class Liquor : CondimentDecorator
    {
        public Liquor(Beverage beverage)
            : base(beverage)
        {
        }

        public override string GetDescription()
        {
            return beverage.GetDescription() + ", Liquor";
        }
    }
}
