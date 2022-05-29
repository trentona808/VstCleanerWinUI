using System.Collections.Generic;
using System.IO;
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
                });
            }
            return vstList;

        }
    }
}
