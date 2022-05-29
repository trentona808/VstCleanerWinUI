using System.Collections.Generic;
using VstCleaner.Common.Model;

namespace VstCleaner.Common.DataProvider
{
    public interface IVstDataProvider
    {
        IEnumerable<Vst> LoadVsts(string path);
    }
}
