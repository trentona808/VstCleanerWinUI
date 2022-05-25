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
        public IEnumerable<Vst> LoadVsts(string jsonPath)
        {
            if (File.Exists(jsonPath))
            {
                var vstList = ReadJson(jsonPath);
                return vstList;
            }
            else
            {
                var vstList = new List<Vst>();
                return vstList;
            }
        }


        public static void SaveWhitelist(List<Vst> list, string jsonPath)
        {
            //var path = @"C:\Users\Trenton\Documents\test.json";
            string jsonString = JsonSerializer.Serialize(list);
            File.WriteAllText(jsonPath, jsonString);
        }

        public List<Vst> ReadJson(string jsonPath)
        {
            string jsonString = File.ReadAllText(jsonPath);
            List<Vst> vstList = JsonSerializer.Deserialize<List<Vst>>(jsonString)!;
            return vstList;
        }

        public class WhitelistVst
        {
            public string VstName { get; set; }
            public string FullPath { get; set; }
            public bool IsWhitelisted { get; set; }
        }


    }
}
