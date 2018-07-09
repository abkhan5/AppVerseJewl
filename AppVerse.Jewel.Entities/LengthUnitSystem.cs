namespace AppVerse.Jewel.Entities
{
    public class LengthUnitSystem : UnitSystemBase<LengthUnit>
    {
        public LengthUnitSystem(double defaultValue = 0) : base(LengthUnit.Foot,defaultValue, QuantityType.Length, new LengthUnitConverter())
        {
            
        }
    }

    public class VolumeUnitSystem : UnitSystemBase<VolumeUnit>
    {
        public VolumeUnitSystem(double defaultValue = 0) : base(VolumeUnit.CubicFoot, defaultValue, QuantityType.Volume, new VolumeUnitConverter())
        {
            
        }


       
    }
}