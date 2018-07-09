using System;
using System.Collections.Generic;
using System.Linq;
using AppVerse.Jewel.Core.ApplicationBase;

namespace AppVerse.Jewel.Entities
{
    public class UnitSystemBase<T> : UnitSystemBase
    {
        protected T _selectedUnit;
        protected T _defaultUnit;

        protected UnitSystemBase(double defaultValue, QuantityType quantityType) : base(defaultValue, quantityType)
        {

            var supportedUnits = Enum.GetValues(typeof(T)).Cast<T>();
            SupportedUnits = new List<T>(supportedUnits);
        }


        public IList<T> SupportedUnits { get; }


        public T DefaultUnit => _defaultUnit;



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
        
        public UnitSystemBase(double defaultValue, QuantityType quantityType)
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

    //public abstract class UnitSystemBase<T, TIUnit> : DataModelBase, IUnitSystem where TIUnit:class ,IUnit
    //{
    //    #region Private members

    //    private Enum _selectedUnit;
    //    private Enum _defaultUnit;
    //    private T _applicationValue;
    //    private HashSet<Enum> _supportedUnits;
    //    private Dictionary<Enum, Dictionary<Enum, TIUnit>> _conversions;
    //    #endregion

    //    #region Constructor

    //    protected UnitSystemBase( Enum defaultUnit)
    //    {
    //        _defaultUnit = defaultUnit;
    //        _conversions= new Dictionary<Enum, Dictionary<Enum, TIUnit>>();
    //        _supportedUnits= new HashSet<Enum>();
    //    }
    //    #endregion

    //    #region Methods

    //    public HashSet<Enum> SupportedUnits => _supportedUnits;

    //    public Enum DefaultUnit
    //    {
    //        get => _defaultUnit;
    //        protected set => SetProperty(ref _defaultUnit, value);
    //    }

    //    public Enum SelectedUnit
    //    {
    //        get => _selectedUnit;
    //        set => SetProperty(ref _selectedUnit, value);
    //    }
    //    public T ApplicationValue
    //    {
    //        get => _applicationValue;
    //        set => SetProperty(ref _applicationValue, value);
    //    }

    //    protected  abstract void  AddUnitList();

    //    protected abstract void SetDefaults();
    //    protected void AddUnitList(TIUnit unitList)
    //    {
    //        _unitListing.Add(unitList);
    //    }

    //    protected void AddSupportedUnits(Enum supportedUnit)
    //    {
    //        _supportedUnits.Add(supportedUnit);
    //    }


    //    #endregion
    //}
}