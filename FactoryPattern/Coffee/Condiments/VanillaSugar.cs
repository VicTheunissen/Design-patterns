namespace FactoryPattern
{
    public class VanillaSugar : CondimentDecorator
    {
        public VanillaSugar(Beverage beverage)
            : base(beverage)
        {
        }

        public override string GetDescription()
        {
            return beverage.GetDescription() + ", Vanilla Sugar";
        }
    }
}
