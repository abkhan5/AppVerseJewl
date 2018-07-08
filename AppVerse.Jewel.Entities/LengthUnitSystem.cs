using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using AppVerse.Jewel.Core.ApplicationBase;

namespace AppVerse.Jewel.Entities
{
    public class LengthUnitSystem:DataModelBase
    {
        private LengthUnit _selectedUnit;
        private readonly LengthUnit _defaultUnit;
        private double _selectedValue;

        public LengthUnitSystem()
        {
            QuantityType = QuantityType.Length;
            _defaultUnit = _selectedUnit =  LengthUnit.Foot;
            var supportedUnits = Enum.GetValues(typeof(LengthUnit)).Cast<LengthUnit>();
            SupportedUnits = new List<LengthUnit>(supportedUnits);
        }

        public LengthUnitSystem(double value):this()
        {
            _selectedValue = DefaultValue = value;
        }

        public IList<LengthUnit> SupportedUnits { get;  }

        public  QuantityType QuantityType { get; private  set; }

        public LengthUnit DefaultUnit => _defaultUnit;

        public double DefaultValue { get;  }

        public LengthUnit SelectedUnit
        {
            get => _selectedUnit;
            set
            {
                SetProperty(ref _selectedUnit , value);
                Convert();
            }
        }

        public double SelectedValue
        {
            get => _selectedValue;
            set
            {
                SetProperty(ref _selectedValue, value);
                Convert();
            } 
        }

        private void Convert()
        {

        }

    }
}