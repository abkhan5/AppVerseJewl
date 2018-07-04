using System.Collections.Generic;
using AppVerse.Jewel.Entities;

namespace AppVerse.Jewel.Contract
{
    public interface IFilePicker
    {
        bool IsOpen { get; }
        IEnumerable<DepthFile> GetFilePaths(bool multiSelect, params FileFormat[] fileFormats);
    }
}