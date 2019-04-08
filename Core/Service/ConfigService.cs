using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using YgoProFrPatcher.Core.Model;

namespace YgoProFrPatcher.Core.Service
{
    public class ConfigService : IConfigService
    {
        public ConfigModel GetConfig()
        {
            if (File.Exists(@"./Config.json"))
                using (StreamReader r = new StreamReader(@"./Config.json"))
                {
                    string json = r.ReadToEnd();
                    ConfigModel items = JsonConvert.DeserializeObject<ConfigModel>(json);
                    return items;
                }
            else
            {
                var temp = new ConfigModel();
                temp.lngInterface = "en";
                temp.lngCard = "en";
                temp.lastUpdate = "";
                return temp;
            }
        }

        public void SetConfig(ConfigModel configModel)
        {
            using (StreamWriter file = File.CreateText(@"./Config.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(file, configModel);
            }
        }
    }
}
