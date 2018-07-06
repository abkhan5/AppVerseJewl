using System;
using System.ComponentModel;
using AppVerse.Jewel.Core;

namespace AppVerse.Jewel.Entities
{
    public static class Extensions
    {
        public static string GetDescription(this Enum enumValue)
        {
            var fi = enumValue.GetType().GetField(enumValue.ToString());

            if (null == fi) return "";
            var attrs = fi.GetCustomAttributes(typeof(DescriptionAttribute), true);
            if (attrs.Length > 0)
                return ((DescriptionAttribute) attrs[0]).Description;

            return "";
        }

        public static string GetImageDescription(this Enum enumValue)
        {
            var fi = enumValue.GetType().GetField(enumValue.ToString());

            if (null == fi) return "";
            var attrs = fi.GetCustomAttributes(typeof(ImagePathAttribute), true);
            if (attrs.Length > 0)
                return ((ImagePathAttribute) attrs[0]).ImageDescription;

            return "";
        }
    }
}