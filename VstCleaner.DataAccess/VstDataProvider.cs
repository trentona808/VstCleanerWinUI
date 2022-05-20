using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VstCleaner.Common.DataProvider;
using VstCleaner.Common.Model;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace VstCleaner.DataAccess
{
    public class VstDataProvider : IVstDataProvider
    {
        public IEnumerable<Vst> LoadVsts()
        {
            VstDir = @"C:\Program Files\Common Files\VST3";
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

        //private string _vstDir = @"C:\Program Files\Common Files\VST3";

        //public string VstDir
        //{
        //    get { return _vstDir; }
        //    set { _vstDir = value; }
        //}


        private static string _vstDir = "TEST";

        public  static string VstDir
        {
            get { return _vstDir; }
            set { _vstDir = value; }
        }


        public string vstTest
        {
            get
            { return "Testing"; }
        }



        //return new List<Vst>
        //{

        //    new Vst
        //    {
        //        VstName = "Name1",
        //        FullPath = "Path1",
        //        IsWhitelisted = true
        //    },
        //    new Vst
        //    {
        //        VstName = "Name2",
        //        FullPath = "Path2",
        //        IsWhitelisted = false
        //    },
        //    new Vst
        //    {
        //        VstName = "Name2",
        //        FullPath = "Path2",
        //        IsWhitelisted = true
        //    },
        //    new Vst
        //    {
        //        VstName = "Name2",
        //        FullPath = "Path2",
        //        IsWhitelisted = false
        //    },
        //    new Vst
        //    {
        //        VstName = "Name2",
        //        FullPath = "Path2",
        //        IsWhitelisted = true
        //    }

        //};




        public void SaveVst(Vst vst)
        {
            Debug.WriteLine($"Vst saved: {vst.VstName}");
        }
    }
}
