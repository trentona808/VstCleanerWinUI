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
        IEnumerable<Vst> LoadVsts();

        void SaveVst(Vst vst);

        //void AddToWhitelist(Vst vst);

        //void WriteJson(Vst vst);

    }
}
