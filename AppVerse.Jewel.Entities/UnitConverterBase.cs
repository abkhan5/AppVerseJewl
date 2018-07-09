using System.Collections.Generic;

namespace AppVerse.Jewel.Entities
{
    public abstract class UnitConverterBase<T> 
    {
        protected readonly Dictionary<T, Dictionary<T, IUnitConversionSystem>> Mapper;

        protected UnitConverterBase()
        {
            Mapper = new Dictionary<T, Dictionary<T, IUnitConversionSystem>>();
            FillMapper();
        }
        protected  abstract void FillMapper();


        public double Convert<TUnit>(TUnit from) where TUnit : UnitSystemBase<T>
        {
            if (from.DefaultUnit.Equals(from.SelectedUnit))
            {
                return from.DefaultValue;
            }

            var result = Mapper[from.DefaultUnit][from.SelectedUnit].Convert(from.DefaultValue);
            return result;
        }

        public double Convert<TUnit>(TUnit from, TUnit to) where TUnit : UnitSystemBase<T>
        {
            if (from.SelectedUnit.Equals(to.SelectedUnit))
            {
                return from.SelectedValue;
            }

            var result = Mapper[from.SelectedUnit][to.SelectedUnit].Convert(from.SelectedValue);
            return result;
        }
    }
}