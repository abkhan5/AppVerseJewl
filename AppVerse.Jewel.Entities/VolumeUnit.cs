using System.ComponentModel;
using AppVerse.Jewel.Core;

namespace AppVerse.Jewel.Entities
{
    
    public enum VolumeUnit
    {
        [Description(Constants.UndefinedVolume)]
        Undefined = 0,
        [Description(Constants.CubicMeter)]
        CubicMeter,
        [Description(Constants.CubicFoot)]
        CubicFoot,
        [Description(Constants.OilBarrel)]
        OilBarrel,
    }

    public enum LengthUnit
    {
        [Description(Constants.UndefinedLength)]
        Undefined = 0,
        [Description(Constants.Meter)]
        Meter,
        [Description(Constants.Foot)]
        Foot,
    }


    public enum QuantityType
    {
        Undefined = 0,
        Volume,
        Length,
    }

}