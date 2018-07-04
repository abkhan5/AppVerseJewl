#region Namespace

using System.Threading.Tasks;
using AppVerse.Jewel.Contract;
using AppVerse.Jewel.Core;
using AppVerse.Jewel.Entities;
using Microsoft.Practices.Unity;

#endregion

namespace AppVerse.Jewel.Loaders
{
    public class HorizonDataProvider : IHorizonDataProvider
    {
        private readonly IUnityContainer _container;


        public HorizonDataProvider(IUnityContainer container)
        {
            _container = container;
        }

        public async Task GetDepth(DepthFile file)
        {
            IFileloader loader = null;
            switch (file.Format)
            {
                case FileFormat.Csv:
                    loader = _container.Resolve<IFileloader>(ContainerNamesConstant.CsvLoader);
                    break;
                case FileFormat.Excel:
                    loader = _container.Resolve<IFileloader>(ContainerNamesConstant.ExcelLoader);
                    break;
            }

            await loader.GetDepth(file);
        }
    }
}