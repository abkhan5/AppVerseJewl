using System;
using AppVerse.Jewel.Core;

namespace AppVerse.Jewel.Entities
{
    public interface IUnitConversionSystem
    {
        double Scale { get; }
        double Shift { get; }
        double Convert(double value);
    }

    public interface IUnitConversionSystem<T> : IUnitConversionSystem where T: IUnit<T>
    {
        T FromUnit { get; }
        T ToUnit { get; }

        double Convert(T from, T to, double value);

    }


    public  class UnitConversionSystem : IUnitConversionSystem
    {
        public UnitConversionSystem(double scale,double shift)
        {
            Scale = scale;
            Shift = shift;
        }
        public double Scale { get; set; }
        public double Shift { get; set; }


        public double Convert( double value)
        {
            return value * Scale + Shift;
        }
    }

}