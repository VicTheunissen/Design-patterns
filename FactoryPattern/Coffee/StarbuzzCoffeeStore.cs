namespace FactoryPattern
{
    public class StarbuzzCoffeeStore : CoffeeStore
    {
        // Hier staat alle kennis over welke basis en condiments bij welke
        // drank horen. De rest van de applicatie hoeft dat niet te weten.
        protected override Beverage CreateCoffee(CoffeeType type)
        {
            return type switch
            {
                CoffeeType.Espresso =>
                    new Espresso(),
                CoffeeType.Doppio =>
                    new ExtraEspresso(new Espresso()),
                CoffeeType.Lungo =>
                    new Water(new Espresso()),
                CoffeeType.Macchiato =>
                    new MilkFoam(new Espresso()),
                CoffeeType.Corretto =>
                    new Liquor(new Espresso()),
                CoffeeType.ConPanna =>
                    new Whip(new Espresso()),
                CoffeeType.Cappuccino =>
                    new MilkFoam(new SteamedMilk(new Espresso())),
                CoffeeType.Americano =>
                    new Water(new Water(new Espresso())),
                CoffeeType.CaffeLatte =>
                    new MilkFoam(new SteamedMilk(new SteamedMilk(new Espresso()))),
                CoffeeType.FlatWhite =>
                    new SteamedMilk(new SteamedMilk(new Espresso())),
                CoffeeType.Romana =>
                    new Lemon(new Espresso()),
                CoffeeType.Marocchino =>
                    new MilkFoam(new ChocolateSauce(new Espresso())),
                CoffeeType.Mocha =>
                    new Whip(new SteamedMilk(new ChocolateSauce(new Espresso()))),
                CoffeeType.Bicerin =>
                    new Whip(new WhiteChocolate(new BlackChocolate(new Espresso()))),
                CoffeeType.Breve =>
                    new HalfMilk(new MilkFoam(new Espresso())),
                CoffeeType.RafCoffee =>
                    new Cream(new VanillaSugar(new Espresso())),
                CoffeeType.MeadRaf =>
                    new Cream(new Honey(new Espresso())),
                CoffeeType.Galao =>
                    new MilkFoam(new MilkFoam(new Espresso())),
                CoffeeType.CaffeAffogato =>
                    new IceCream(new ExtraEspresso(new Espresso())),
                CoffeeType.ViennaCoffee =>
                    new Whip(new Whip(new ExtraEspresso(new Espresso()))),
                CoffeeType.Glace =>
                    new IceCream(new Espresso()),
                CoffeeType.ChocolateMilk =>
                    new Milk(new Milk(new Chocolate())),
                CoffeeType.DemiCreme =>
                    new Cream(new Cream(new ExtraEspresso(new Espresso()))),
                CoffeeType.LatteMacchiato =>
                    new MilkFoam(new SteamedMilk(new SteamedMilk(new Espresso()))),
                CoffeeType.Freddo =>
                    new Ice(new Liquor(new Espresso())),
                CoffeeType.Frappuccino =>
                    new Whip(new SteamedMilk(new Ice(new Espresso()))),
                CoffeeType.CaramelFrappuccino =>
                    new Syrup(new Cream(new SteamedMilk(new Ice(new Espresso())))),
                CoffeeType.Frappe =>
                    new IceCream(new SteamedMilk(new SteamedMilk(new Espresso()))),
                CoffeeType.IrishCoffee =>
                    new Whip(new Whiskey(new ExtraEspresso(new Espresso()))),
                _ => throw new ArgumentOutOfRangeException(
                    nameof(type), type, "Deze drank staat niet op de kaart.")
            };
        }
    }
}
