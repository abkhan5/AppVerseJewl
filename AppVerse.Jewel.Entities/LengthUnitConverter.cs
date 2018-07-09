using System.Collections.Generic;

namespace AppVerse.Jewel.Entities
{
    public class LengthUnitConverter: UnitConverterBase<LengthUnit>
    {
        protected override void FillMapper()
        {
            Mapper[LengthUnit.Foot]= new Dictionary<LengthUnit, IUnitConversionSystem>();
            Mapper[LengthUnit.Foot][LengthUnit.Meter] = new UnitConversionSystem(3.2808, 0);
            Mapper[LengthUnit.Meter] = new Dictionary<LengthUnit, IUnitConversionSystem>();
            Mapper[LengthUnit.Meter][LengthUnit.Foot] = new UnitConversionSystem(1/3.2808, 0);
        }

        
    }
}