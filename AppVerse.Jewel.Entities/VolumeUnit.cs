using System.ComponentModel;
using AppVerse.Jewel.Core;

namespace AppVerse.Jewel.Entities
{
    
    public enum VolumeUnit
    {
        [Description(Constants.UndefinedVolume)]
        Undefined = 0,
        [Description(UnitConstant.CubicMeter)]
        CubicMeter,
        [Description(UnitConstant.CubicFoot)]
        CubicFoot,
        [Description(UnitConstant.OilBarrel)]
        OilBarrel,
    }

    public enum LengthUnit
    {
        [Description(Constants.UndefinedLength)]
        Undefined = 0,
        [Description(UnitConstant.Meter)]
        Meter,
        [Description(UnitConstant.Foot)]
        Foot,
    }


    public enum QuantityType
    {
        Undefined = 0,
        Volume,
        Length,
    }

}