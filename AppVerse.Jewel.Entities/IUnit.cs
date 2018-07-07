namespace AppVerse.Jewel.Entities
{
    public interface IUnit
    {
        string Abbreviation { get; }
        string Name { get; }
        QuantityType QuantityType { get; }


    }
}