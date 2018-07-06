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
   public class DataGrid2D : ContentControl
    {

        public static readonly DependencyProperty ArrayDataSourceProperty = DependencyProperty.Register(
            "ArrayDataSource",
            typeof(int[][]),
            typeof(DataGrid2D),
            new PropertyMetadata(OnArrayDataSourceSourceChange));

        private static void OnArrayDataSourceSourceChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!(d is DataGrid2D appImage))
                return;

            if(!(e.NewValue is int[][] array))
                return;

            DataGrid dataTable = new DataGrid
            {
                CanUserAddRows = false,
                HeadersVisibility = DataGridHeadersVisibility.None
            };

            
            for (int i = 0; i < array.GetLength(1); i++)
                dataTable.Columns.Add(new DataGridTextColumn());
            


                appImage.Content = dataTable;
        }

        public int[][] ArrayDataSource
        {
            get => (int[][])GetValue(ArrayDataSourceProperty);
            set => SetValue(ArrayDataSourceProperty, value);
        }
        public class Ref<T>
        {
            private readonly Func<T> getter;
            private readonly Action<T> setter;
            public Ref(Func<T> getter, Action<T> setter)
            {
                this.getter = getter;
                this.setter = setter;
            }
            public T Value { get { return getter(); } set { setter(value); } }
        }

        public static DataView GetBindable2DArray<T>(T[,] array)
        {
            DataTable dataTable = new DataTable();
            for (int i = 0; i < array.GetLength(1); i++)
            {
                dataTable.Columns.Add(i.ToString(), typeof(Ref<T>));
            }
            for (int i = 0; i < array.GetLength(0); i++)
            {
                DataRow dataRow = dataTable.NewRow();
                dataTable.Rows.Add(dataRow);
            }
            DataView dataView = new DataView(dataTable);
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    int a = i;
                    int b = j;
                    Ref<T> refT = new Ref<T>(() => array[a, b], z => { array[a, b] = z; });
                    dataView[i][j] = refT;
                }
            }
            return dataView;
        }
    }
}
