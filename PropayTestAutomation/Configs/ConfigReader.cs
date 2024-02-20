using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NUnitFramework.Configs
{
    public class ConfigReader
    {
        public static TestSettings ReadConfig() {
            var configFile = File.ReadAllText(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/appSettings.json");

            var jsonSerialzeOptions = new JsonSerializerOptions() { 
                PropertyNameCaseInsensitive = true
            };
            jsonSerialzeOptions.Converters.Add(new JsonStringEnumConverter());

            return JsonSerializer.Deserialize<TestSettings>(configFile, jsonSerialzeOptions);
        }
    }
}
