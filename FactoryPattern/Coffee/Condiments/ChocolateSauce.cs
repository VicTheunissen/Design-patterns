namespace FactoryPattern
{
    public class ChocolateSauce : CondimentDecorator
    {
        public ChocolateSauce(Beverage beverage)
            : base(beverage)
        {
        }

        public override string GetDescription()
        {
            return beverage.GetDescription() + ", Chocolate";
        }
    }
}
