//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VstCleaner.Common.DataProvider;
using VstCleaner.Common.Model;
using System.Text.Json;
using System.Collections.ObjectModel;

namespace VstCleaner.DataAccess
{
    public class WhitelistDataProvider : IVstDataProvider
    {
        public IEnumerable<Vst> LoadVsts()
        {
            var vstList = ReadJson(JsonPath);
            return vstList;
        }


        public static void SaveWhitelist(List<Vst> list)
        {
            var path = @"C:\Users\Trenton\Documents\test.json";
            string jsonString = JsonSerializer.Serialize(list);
            File.WriteAllText(path, jsonString);
        }

        public List<Vst> ReadJson(string path)
        {
            string jsonString = File.ReadAllText(path);
            List<Vst> vstList = JsonSerializer.Deserialize<List<Vst>>(jsonString)!;
            return vstList;
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


    }
}
