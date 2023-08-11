using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MarkovDotnetCoreNotFriendly2.Saver
{
    internal class Manager
    {
        private List<string> sentances = new List<string>();
        private string URL = "bigdata.json";

        public List<string> OnLoadDataFirst()
        {
            var file = File.ReadAllText(URL);
            sentances = file.Split('\n').ToList();

            var json = JsonConvert.SerializeObject(sentances);
            File.WriteAllText($"{URL}.json", json);

            return sentances;
        }

        public List<string> OnLoadData()
        {
            var json = File.ReadAllText(URL);
            sentances = JsonConvert.DeserializeObject<List<string>>(json);
            return sentances;
        }

        public void PutData(string data)
        {
            sentances.Add(data);
            SaveData();
        }

        public void SaveData()
        {
            var json = JsonConvert.SerializeObject(sentances);
            File.WriteAllText(URL, json);
        }
    }
}
