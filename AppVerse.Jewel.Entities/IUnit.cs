using AppVerse.Jewel.Core;

namespace AppVerse.Jewel.Entities
{


    public class LengthUnitType : Unit<LengthUnit>
    {
        public LengthUnitType(string abbreviation, string name) : base(abbreviation, name, QuantityType.Length)
        {

        }
    }

    public class VolumeUnitType : Unit<VolumeUnit>
    {
        public VolumeUnitType(string abbreviation, string name) : base(abbreviation, name, QuantityType.Volume)
        {

        }
    }


    public abstract class Unit<T> : IUnit<T>
    {
        protected Unit(string abbreviation, string name, QuantityType quantityType)
        {
            Abbreviation = abbreviation;
            Name = name;
            QuantityType = quantityType;
        }
        public string Abbreviation { get; }
        public string Name { get; }
        public QuantityType QuantityType { get; }
        public T MeasurementUnit { get; set; }
    }



    public interface IUnit
    {
        string Abbreviation { get; }
        string Name { get; }
        QuantityType QuantityType { get; }
    }
    public interface IUnit<T>:IUnit
    {
        T MeasurementUnit { get; set; }
        

    }
}