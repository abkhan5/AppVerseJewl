using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AppVerse.Jewel.Contract;
using AppVerse.Jewel.Entities;
using Microsoft.Practices.Unity;

namespace AppVerse.Jewel.Loaders
{
    public class CsvFileLoader : IFileloader
    {
        private readonly IUnityContainer _container;

        public CsvFileLoader(IUnityContainer container)
        {
            _container = container;
        }

         const char Delimiter = ' ';
        
        public async  Task GetDepth(DepthFile fileName)
        {
            int row = 0;
            int sum = 0;
            using (var reader = new StreamReader(fileName.FilePath))
            {
                while (!reader.EndOfStream)
                {
                    var line = await reader.ReadLineAsync().ConfigureAwait(false);
                    if (line != null)
                    {
                        var values = line.Split(Delimiter);
                        FillDepthSheet(fileName, values, row,ref sum);
                        await Task.Delay(TimeSpan.FromSeconds(0.1)).ConfigureAwait(false);
                    }
                    row++;
                }
            }

            fileName.Volume = sum+" feet";
        }

        private static int FillDepthSheet(DepthFile fileName, string[] values, int row, ref int sum)
        {
            var column = 0;
            foreach (var value in values)
            {
                if (!int.TryParse(value, out var depth))
                    continue;
                fileName.TopHorizon.Depth[column][row] = new LengthUnitSystem(depth);
                sum += depth;
                fileName.FileLoadProgress.Progress++;
                column++;
            }

            return sum;
        }
    }
}