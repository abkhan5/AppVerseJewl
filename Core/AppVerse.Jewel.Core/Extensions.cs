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
    }
}