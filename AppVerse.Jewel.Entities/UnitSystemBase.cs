using System;
using System.Collections.Generic;
using System.Linq;
using AppVerse.Jewel.Core.ApplicationBase;

namespace AppVerse.Jewel.Entities
{
    public abstract class UnitSystemBase<TUnitEnum> : UnitSystemBase
    {
        private  TUnitEnum _selectedUnit;

        protected UnitSystemBase(TUnitEnum defualtUnit, double defaultValue, QuantityType quantityType, UnitConverterBase<TUnitEnum> converter) : base(defaultValue, quantityType)
        {
            Converter = converter;
            
            var supportedUnits = Enum.GetValues(typeof(TUnitEnum)).Cast<TUnitEnum>();
            DefaultUnit = _selectedUnit = defualtUnit;
            SupportedUnits = new List<TUnitEnum>(supportedUnits);
            _unSupportedUnit = SupportedUnits.ElementAt(0);
        }

        private readonly TUnitEnum _unSupportedUnit;

        public UnitConverterBase<TUnitEnum> Converter { get;  }
        public IList<TUnitEnum> SupportedUnits { get; }

        public TUnitEnum DefaultUnit { get; }


        public TUnitEnum SelectedUnit
        {
            get => _selectedUnit;
            set
            {
                SetProperty(ref _selectedUnit, value);
                if (_unSupportedUnit.Equals(_selectedUnit))
                {
                    return;
                }
                SelectedValue = Converter.Convert(this);
            }
        }


    }

    public abstract class UnitSystemBase : DataModelBase
    {
        protected UnitSystemBase(double defaultValue, QuantityType quantityType)
        {
            QuantityType = quantityType;
            _selectedValue= DefaultValue = defaultValue;
        }
        public double SelectedValue
        {
            get => _selectedValue;
            set => SetProperty(ref _selectedValue, value);
        }

        private double _selectedValue;
        public QuantityType QuantityType { get; private set; }
        public double DefaultValue { get; protected set; }

        
        
    }
}