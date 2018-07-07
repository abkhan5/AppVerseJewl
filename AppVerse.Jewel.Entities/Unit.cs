using System;

namespace AppVerse.Jewel.Entities
{
    public struct Unit : IUnit
    {
        public string Abbreviation { get; }
        public string Name { get; }

        public QuantityType QuantityType { get; }


        public override string ToString()
        {
            return $"{Name} ({Abbreviation})";
        }

        internal Unit(string name, string abbreviation, QuantityType type)
        {
            Name = name;
            Abbreviation = abbreviation;
            QuantityType = type;

        }
    }
}