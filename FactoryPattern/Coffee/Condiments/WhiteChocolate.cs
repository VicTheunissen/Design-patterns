namespace FactoryPattern
{
    public class WhiteChocolate : CondimentDecorator
    {
        public WhiteChocolate(Beverage beverage)
            : base(beverage)
        {
        }

        public override string GetDescription()
        {
            return beverage.GetDescription() + ", White Chocolate";
        }
    }
}
