using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using VstCleaner.Common.DataProvider;
using VstCleaner.Common.Model;


namespace VstCleaner.DataAccess
{
    public class VstDataProvider : IVstDataProvider
    {
        public IEnumerable<Vst> LoadVsts(string VstDir)
        {
            var vstList = new List<Vst>();

            foreach (string file in Directory.GetFiles(VstDir, "*.vst*"))
            {
                vstList.Add(new Vst
                {
                    VstName = System.IO.Path.GetFileName(file),
                    FullPath = System.IO.Path.GetFullPath(file),
                    IsWhitelisted = false
                });
            }
            return vstList;

        }

    }
}
