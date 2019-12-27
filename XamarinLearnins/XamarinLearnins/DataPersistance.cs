using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace XamarinLearnins
{
    public class DataPersistance
    {
        private static IDictionary<string, object> props { get { return Application.Current.Properties;  } }

        public static IEnumerable<Config> Get()
        {
            var configs = new List<Config>();
            var keys = props.Keys.ToArray();
            foreach (var key in keys)
            {
                try
                {
                    configs.Add(JsonConvert.DeserializeObject<Config>(props[key].ToString()));
                }
                catch (Exception e)
                {
                    //the data is corupt/invalid
                    props.Remove(key);
                }
            }
            return  configs;
        }
        public static void Save(Config config)
        {
            saveJson(config.Name, JsonConvert.SerializeObject(config));
        }

        private static void saveJson(string key, string json)
        {
            if (!props?.ContainsKey(key) ?? true)
                props.Add(key, json);
            else
                props[key] = json;

            Application.Current.SavePropertiesAsync();
        }
    }
}
