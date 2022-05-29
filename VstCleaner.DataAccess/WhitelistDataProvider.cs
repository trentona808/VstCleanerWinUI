//using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using VstCleaner.Common.DataProvider;
using VstCleaner.Common.Model;
using System.Text.Json;

namespace VstCleaner.DataAccess
{
    public class WhitelistDataProvider : IVstDataProvider
    {
        public static void SaveWhitelist(List<Vst> list, string jsonPath)
        {
            string jsonString = JsonSerializer.Serialize(list);
            File.WriteAllText(jsonPath, jsonString);
        }

        private static List<Vst> ReadJson(string jsonPath)
        {
            string jsonString = File.ReadAllText(jsonPath);
            List<Vst> vstList = JsonSerializer.Deserialize<List<Vst>>(jsonString)!;
            return vstList;
        }

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


        public class WhitelistVst
        {
            public string VstName { get; set; }
            public string FullPath { get; set; }
        }


    }
}
