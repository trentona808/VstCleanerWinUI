using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VstCleaner.Common.DataProvider;
using VstCleaner.Common.Model;

namespace VstCleaner.DataAccess
{
    public class WhitelistDataProvider : IVstDataProvider
    {
        public IEnumerable<Vst> LoadVsts()
        {
            VstDir = @"C:\Program Files\Common Files\VST2";
            var vstList = new List<Vst>();

            foreach (string file in Directory.GetFiles(VstDir, "*.vst*"))
            {
                vstList.Add(new Vst
                {
                    VstName = System.IO.Path.GetFileNameWithoutExtension(file),
                    FullPath = System.IO.Path.GetFileName(file),
                    IsWhitelisted = false
                });
            }
            return vstList;


        }


        private static string _vstDir;

        public static string VstDir
        {
            get { return _vstDir; }
            set { _vstDir = value; }
        }




        public void SaveVst(Vst vst)
        {
            Debug.WriteLine($"Vst saved: {vst.VstName}");
        }
    }
}
