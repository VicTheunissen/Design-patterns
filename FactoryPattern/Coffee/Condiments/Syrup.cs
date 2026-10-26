namespace FactoryPattern
{
    public class Syrup : CondimentDecorator
    {
        public Syrup(Beverage beverage)
            : base(beverage)
        {
        }

        public override string GetDescription()
        {
            return beverage.GetDescription() + ", Syrup";
        }
    }
}
