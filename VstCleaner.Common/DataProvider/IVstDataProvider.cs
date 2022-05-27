using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VstCleaner.Common.Model;

namespace VstCleaner.Common.DataProvider
{
    public interface IVstDataProvider
    {
        IEnumerable<Vst> LoadVsts(string path);

    }
}
