using System;

namespace AppVerse.Jewel.Entities
{
    public interface  IUnit
    {

    }
    public struct Unit :IUnit
    {
        internal string Abbreviation { get; set; }
        internal string Name { get; set; }
        internal double Scale { get; set; }
        internal double Shift { get; set; }
        internal UnitType Type { get; set; }



        public override string ToString()
        {
            return $"{Name} ({Abbreviation})";
        }

        internal Unit(
            string name,
            string abbreviation,
            double scale,
            double shift,
            UnitType type)
        {
            if (Math.Abs(scale) < 0)
                throw new ArgumentException("Scale factor cannot be zero.");

            Name = name;
            Abbreviation = abbreviation;
            Scale = scale;
            Shift = shift;
            Type = type;
        }
    }
}