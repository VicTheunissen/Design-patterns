namespace FactoryPattern
{
    // Component van de koffie-decorator: zowel de basisdrank als
    // ieder condiment is een Beverage.
    public abstract class Beverage
    {
        public abstract string GetDescription();
    }
}
