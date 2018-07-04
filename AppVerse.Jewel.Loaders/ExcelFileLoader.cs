using System.Collections.Generic;
using System.Threading.Tasks;
using AppVerse.Jewel.Contract;
using AppVerse.Jewel.Entities;
using Microsoft.Practices.Unity;

namespace AppVerse.Jewel.Loaders
{
    public class ExcelFileLoader : IFileloader
    {
        private readonly IUnityContainer _container;

        public ExcelFileLoader(IUnityContainer container)
        {
            _container = container;
        }

        
        public Task  GetDepth(DepthFile fileName)
        { return Task.CompletedTask;
            
        }

        public bool IsLoading { get; private set; }
    }
}