using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using AppVerse.Jewel.Core;
using AppVerse.Jewel.Entities;
using MahApps.Metro.IconPacks;

namespace AppVerse.Jewel.Controls
{
   public class HorizonControl : ContentControl
   {

       public static DependencyProperty LengthUnitSystemSourceProperty = DependencyProperty.Register(
           "LengthUnitSystemSource",
           typeof(List<List<LengthUnitSystem>>),
           typeof(HorizonControl),


           new PropertyMetadata(null,OnArrayDataSourceSourceChange));

        private static void OnArrayDataSourceSourceChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!(d is HorizonControl control))
                return;

            if(!(e.NewValue is List<List<LengthUnitSystem>> array))
                return;

            Grid dataTable= new Grid();
            int column = 0;
            
            foreach (var unitList in array)
            {
                int row = 0;
                dataTable.ColumnDefinitions.Add(new ColumnDefinition());
                foreach (var lengthUnitSystem in unitList)
                {
                    
                        dataTable.RowDefinitions.Add(new RowDefinition());
                        ContentControl ctr = new ContentControl {Content = lengthUnitSystem};
                        Grid.SetRow(ctr, row);
                        Grid.SetColumn(ctr, column);
                    row++;
                }

                column++;
            }
        }

        public List<List<LengthUnitSystem>> LengthUnitSystemSource
        {
            get => (List<List<LengthUnitSystem>>)GetValue(LengthUnitSystemSourceProperty);
            set => SetValue(LengthUnitSystemSourceProperty, value);
        }
      
    }
}
