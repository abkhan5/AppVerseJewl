using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Documents;
using AppVerse.Jewel.Entities;

namespace AppVerse.Jewel.Contract
{
    public interface IFileloader
    {
        Task  GetDepth(DepthFile  fileName);
       
    }
}