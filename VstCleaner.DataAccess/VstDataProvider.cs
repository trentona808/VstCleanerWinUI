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
                    FullPath = System.IO.Path.GetFullPath(file),
                    IsWhitelisted = false
                });
            }
            return vstList;



            //return new List<Vst>
            //{
            //    new Vst
            //    {
            //        VstName = "1",
            //        FullPath = "111",
            //        IsWhitelisted = true,
            //    },
            //    new Vst
            //    {
            //        VstName= "2",
            //        FullPath = "222",
            //        IsWhitelisted= true,
            //    }
            //};


        }

        //private string _vstDir = @"C:\Program Files\Common Files\VST3";



        private static string _vstDir;

        public  static string VstDir
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
