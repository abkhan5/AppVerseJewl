using System;

namespace AppVerse.Jewel.Entities
{
    public interface IUnitConversionSystem<T> where T: IUnit
    {
        double Scale { get; }
        double Shift { get; }

        T FromUnit { get; }
        T ToUnit { get; }

        double Convert(T from, T to, double value);

    }

    public abstract class UnitConversionSystem<T> : IUnitConversionSystem<T> where T : IUnit
    {
        public double Scale { get; set; }
        public double Shift { get; set; }

        public T FromUnit { get; set; }
        public T ToUnit { get; set; }

        public double Convert(T from, T to, double value)
        {
            //if (from.Type != to.Type)
            //    throw new InvalidOperationException("Conversion between incompatible types.");
            //if (from.Shift == to.Shift && from.Scale == to.Scale)
            //    return value;

            //double v = (value - from.Shift) / from.Scale;
            //return v * to.Scale + to.Shift;

            return 0;
        }


    }

    public interface IUserUnitSystem<T>
    {
        T DefaultUnit { get; }
        T SelectedUnit { get; }
    }

}