namespace FactoryPattern
{
    public class Cream : CondimentDecorator
    {
        public Cream(Beverage beverage)
            : base(beverage)
        {
        }

        public override string GetDescription()
        {
            return beverage.GetDescription() + ", Cream";
        }
    }
}
