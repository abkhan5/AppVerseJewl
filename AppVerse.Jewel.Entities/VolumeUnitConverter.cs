using System.Collections.Generic;

namespace AppVerse.Jewel.Entities
{
    public class VolumeUnitConverter : UnitConverterBase<VolumeUnit>
    {
        protected override void FillMapper()
        {
            Mapper[VolumeUnit.CubicMeter] =new Dictionary<VolumeUnit, IUnitConversionSystem>();
            Mapper[VolumeUnit.CubicMeter][VolumeUnit.CubicFoot] = new UnitConversionSystem(35.315, 0);
            Mapper[VolumeUnit.CubicMeter][VolumeUnit.OilBarrel] = new UnitConversionSystem(6.2898, 0);

            Mapper[VolumeUnit.CubicFoot] = new Dictionary<VolumeUnit, IUnitConversionSystem>();
            Mapper[VolumeUnit.CubicFoot][VolumeUnit.CubicMeter] = new UnitConversionSystem(1/35.315, 0);
            Mapper[VolumeUnit.CubicFoot][VolumeUnit.OilBarrel] = new UnitConversionSystem(5.6146, 0);

            Mapper[VolumeUnit.OilBarrel] = new Dictionary<VolumeUnit, IUnitConversionSystem>();
            Mapper[VolumeUnit.OilBarrel][VolumeUnit.CubicFoot] = new UnitConversionSystem(0.17811, 0);
            Mapper[VolumeUnit.OilBarrel][VolumeUnit.CubicMeter] = new UnitConversionSystem(1/6.2898, 0);
        }

        public double Convert<T>(T from, T to) where T : VolumeUnitSystem
        {
            if (from.SelectedUnit == to.SelectedUnit) return from.SelectedValue;

            var result = Mapper[from.SelectedUnit][to.SelectedUnit].Convert(from.SelectedValue);
            return result;
        }
    }
}