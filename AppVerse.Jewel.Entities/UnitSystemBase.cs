using System;
using System.Collections.Generic;
using System.Linq;
using AppVerse.Jewel.Core.ApplicationBase;

namespace AppVerse.Jewel.Entities
{
    public class UnitSystemBase<T> : UnitSystemBase
    {
        private  T _selectedUnit;

        protected UnitSystemBase(T defualtUnit, double defaultValue, QuantityType quantityType, UnitConverterBase<T> converter) : base(defaultValue, quantityType)
        {
            Converter = converter;
            var supportedUnits = Enum.GetValues(typeof(T)).Cast<T>();
            DefaultUnit = _selectedUnit = defualtUnit;
            SupportedUnits = new List<T>(supportedUnits);
        }


        public UnitConverterBase<T> Converter { get;  }
        public IList<T> SupportedUnits { get; }

        public T DefaultUnit { get; }


        public T SelectedUnit
        {
            get => _selectedUnit;
            set
            {
                SetProperty(ref _selectedUnit, value);
                Convert();
            }
        }
    }

    public class UnitSystemBase : DataModelBase
    {
        protected UnitSystemBase(double defaultValue, QuantityType quantityType)
        {
            QuantityType = quantityType;
            _selectedValue= DefaultValue = defaultValue;
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

        private double _selectedValue;
        public QuantityType QuantityType { get; private set; }
        public double DefaultValue { get; protected set; }

        protected void Convert()
        {

        }
        
    }
}