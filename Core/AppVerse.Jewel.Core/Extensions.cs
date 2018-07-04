using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Windows;

namespace AppVerse.Jewel.Core
{
    public static class Extensions
    {
        public static void RegisterResources(IEnumerable<string> Source)
        {
            foreach (var source in Source)
            {
                SetResource(source);
            }
        }

        private static void SetResource(string source)
        {
            ResourceDictionary dictionary = new ResourceDictionary();
            dictionary.Source = new Uri(string.Format(source));
            Application.Current.Resources.MergedDictionaries.Add(dictionary);
        }

        public static string GetDescription(this Enum enumValue)
        {
            FieldInfo fi = enumValue.GetType().GetField(enumValue.ToString());

            if (null != fi)
            {
                object[] attrs = fi.GetCustomAttributes(typeof(DescriptionAttribute), true);
                if (attrs.Length > 0)
                    return ((DescriptionAttribute)attrs[0]).Description;
            }

            return "";
        }
    }
}