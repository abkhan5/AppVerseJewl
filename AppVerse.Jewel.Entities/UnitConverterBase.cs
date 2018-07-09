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

    }
}