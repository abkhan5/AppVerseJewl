using System;
using System.Collections.Generic;
using AppVerse.Jewel.Core.ApplicationBase;

namespace AppVerse.Jewel.Entities
{
    public abstract class UnitSystemBase<T, TIUnit> : DataModelBase, IUnitSystem where TIUnit:class ,IUnit
    {
        #region Private members

        private Enum _selectedUnit;
        private Enum _defaultUnit;
        private T _applicationValue;
        private HashSet<Enum> _supportedUnits;
        private Dictionary<Enum, Dictionary<Enum, TIUnit>> _conversions;
        #endregion

        #region Constructor

        protected UnitSystemBase( Enum defaultUnit)
        {
            _defaultUnit = defaultUnit;
            _conversions= new Dictionary<Enum, Dictionary<Enum, TIUnit>>();
            _supportedUnits= new HashSet<Enum>();
        }
        #endregion

        #region Methods

        public HashSet<Enum> SupportedUnits => _supportedUnits;

        public Enum DefaultUnit
        {
            get => _defaultUnit;
            protected set => SetProperty(ref _defaultUnit, value);
        }

        public Enum SelectedUnit
        {
            get => _selectedUnit;
            set => SetProperty(ref _selectedUnit, value);
        }
        public T ApplicationValue
        {
            get => _applicationValue;
            set => SetProperty(ref _applicationValue, value);
        }

        protected  abstract void  AddUnitList();

        protected abstract void SetDefaults();
        protected void AddUnitList(TIUnit unitList)
        {
            _unitListing.Add(unitList);
        }

        protected void AddSupportedUnits(Enum supportedUnit)
        {
            _supportedUnits.Add(supportedUnit);
        }


        #endregion
    }
}