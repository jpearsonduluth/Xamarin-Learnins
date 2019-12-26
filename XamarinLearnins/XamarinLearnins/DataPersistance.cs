using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace XamarinLearnins
{
    public class DataPersistance
    {
        private static IDictionary<string, object> props { get { return Application.Current.Properties;  } }
        private const string KEY = "config_data";

        public static IEnumerable<ColorModel>Get()
        {
            return JsonConvert.DeserializeObject<IEnumerable<ColorModel>>(getJson()) ?? Enumerable.Empty<ColorModel>();
        }
        public static void Save(IEnumerable<ColorModel> colorModels)
        {
            saveJson(JsonConvert.SerializeObject(colorModels));
        }

        private static string getJson()
        {
            if (!props?.ContainsKey(KEY) ?? true)
                return string.Empty;

            return props[KEY].ToString();
        }
        private static void saveJson(string json)
        {
            if (!props?.ContainsKey(KEY) ?? true)
                props.Add(KEY, json);
            else
                props[KEY] = json;
        }
    }
}
