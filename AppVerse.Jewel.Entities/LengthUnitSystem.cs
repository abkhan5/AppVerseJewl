namespace AppVerse.Jewel.Entities
{
    public class LengthUnitSystem : UnitSystemBase<LengthUnit>
    {
        public LengthUnitSystem(double defaultValue = 0) : base(defaultValue, QuantityType.Length)
        {
            _defaultUnit = _selectedUnit = LengthUnit.Foot;
        }
    }

    public class VolumeUnitSystem : UnitSystemBase<VolumeUnit>
    {
        public VolumeUnitSystem(double defaultValue = 0) : base(defaultValue, QuantityType.Volume)
        {
            _defaultUnit = _selectedUnit = VolumeUnit.CubicFoot;
        }
    }
}