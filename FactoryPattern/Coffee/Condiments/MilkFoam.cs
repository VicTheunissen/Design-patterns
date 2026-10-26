namespace FactoryPattern
{
    public class MilkFoam : CondimentDecorator
    {
        public MilkFoam(Beverage beverage)
            : base(beverage)
        {
        }

        public override string GetDescription()
        {
            return beverage.GetDescription() + ", Milk Foam";
        }
    }
}
