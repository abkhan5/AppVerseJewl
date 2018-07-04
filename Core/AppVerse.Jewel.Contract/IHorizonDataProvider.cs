using System.Collections.Generic;
using System.Threading.Tasks;
using AppVerse.Jewel.Entities;

namespace AppVerse.Jewel.Contract
{
    public interface IHorizonDataProvider
    {
        Task GetDepth(DepthFile file);
    }
}