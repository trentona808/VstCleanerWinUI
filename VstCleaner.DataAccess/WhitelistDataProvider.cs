using Newtonsoft.Json;
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
            //var vstList = new List<Vst>();
            //foreach (string file in Directory.GetFiles(VstDir, "*.vst*"))
            //{
            //    vstList.Add(new Vst
            //    {
            //        VstName = System.IO.Path.GetFileNameWithoutExtension(file),
            //        FullPath = System.IO.Path.GetFullPath(file),
            //        IsWhitelisted = false
            //    });
            //}


            //WriteJson(vstList, JsonPath);

            var vstList = ReadJson(JsonPath);











            return vstList;


        }


        public void WriteJson(List<Vst> list, string path)
        {
            var writeToJson = JsonConvert.SerializeObject(list, Formatting.Indented);
            using (var writer = new StreamWriter(path))
            {
                writer.Write(writeToJson);
            }
        }

        public List<Vst> ReadJson(string path)
        {
            string jsonToString;
            using (var reader = new StreamReader(path))
            {
                jsonToString = reader.ReadToEnd();
            }

            var jsonWhitelist = JsonConvert.DeserializeObject<List<Vst>>(jsonToString);
            
            return jsonWhitelist;
        }

        private string _jsonPath = @"C:\Users\Trenton\Documents\test.json";

        public string JsonPath
        {
            get { return _jsonPath; }
            set { _jsonPath = value; }
        }

        public class WhitelistVst
        {
            public string VstName { get; set; }
            public string FullPath { get; set; }
            public bool IsWhitelisted { get; set; }
        }



        private static string _vstDir = @"C:\Program Files\Common Files\VST2";


        public static string VstDir
        {
            get { return _vstDir; }
            set { _vstDir = value; }
        }




        public void SaveVst(Vst vst)
        {
            Debug.WriteLine($"Vst saved: {vst.VstName}");
        }

        /*
         File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(), "greeting.txt"), "Hello World!");
         */




    }
}
