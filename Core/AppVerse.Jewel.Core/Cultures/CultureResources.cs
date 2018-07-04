using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace AppVerse.Jewel.Core.Cultures
{
    public class CultureResources
    {
        /// <summary>
        /// The Resources ObjectDataProvider uses this method to get an instance of the WPFLocalize.Properties.Resources class
        /// </summary>
        /// <returns></returns>
        public AppVerse.Jewel.Core.Cultures.Resources GetResourceInstance()
        {
            return new AppVerse.Jewel.Core.Cultures.Resources();
        }

        private static ObjectDataProvider m_provider;
        public static ObjectDataProvider ResourceProvider
        {
            get
            {
                try
                {
                    if (m_provider == null)
                        m_provider = (ObjectDataProvider)System.Windows.Application.Current.FindResource("LanguageResources");
                }
                catch (Exception e)
                {

                    
                }
                return m_provider;
            }
        }

        public static void ChangeCulture(CultureInfo culture)
        {
            Properties.Resources.Culture = culture;
            ResourceProvider.Refresh();
        }
    }
}
