using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;

namespace AppVerse.Jewel.Entities
{
    public class LengthUnitSystem: UnitSystemBase
    {
        private LengthUnit _selectedUnit;
        private readonly LengthUnit _defaultUnit;

        public LengthUnitSystem(double defaultValue=0) :base(defaultValue, QuantityType.Length)
        {
            _defaultUnit = _selectedUnit =  LengthUnit.Foot;
            var supportedUnits = Enum.GetValues(typeof(LengthUnit)).Cast<LengthUnit>();
            SupportedUnits = new List<LengthUnit>(supportedUnits);
        }


        public IList<LengthUnit> SupportedUnits { get;  }


        public LengthUnit DefaultUnit => _defaultUnit;

        

        public LengthUnit SelectedUnit
        {
            get => _selectedUnit;
            set
            {
                SetProperty(ref _selectedUnit , value);
                Convert();
            }
        }

     

    }
}