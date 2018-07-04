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
            using (var reader = new StreamReader(fileName.FilePath))
            {
                while (!reader.EndOfStream)
                {
                    var line = await reader.ReadLineAsync().ConfigureAwait(false);
                    if (line != null)
                    {
                        var values = line.Split(Delimiter);
                        int column = 0;
                        foreach (var value in values)
                        {
                            if (!int.TryParse(value, out int depth))
                                continue;
                            fileName.TopHorizon.Depth[column,row] = depth;
                            fileName.FileLoadProgress.Progress++;
                            column++;
                        }
                        await Task.Delay(TimeSpan.FromSeconds(0.2)).ConfigureAwait(false);
                    }
                    row++;
                }
            }
        }
    }
}