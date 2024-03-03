using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ProPay.Test.NewGen.Runners.Configs
{
    public class ConfigReader
    {
        public static TestSettings ReadConfig()
        {
            // Get the directory of the currently executing assembly
            var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            // Construct the path to the appSettings.json file
            var configFilePath = Path.Combine(assemblyPath, "Configs", "appSettings.json");
            
            // Ensure the file exists
            if (!File.Exists(configFilePath))
            {
                throw new FileNotFoundException($"Configuration file not found at {configFilePath}");
            }

            var configFile = File.ReadAllText(configFilePath);
            
            var jsonSerializeOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            jsonSerializeOptions.Converters.Add(new JsonStringEnumConverter());

            return JsonSerializer.Deserialize<TestSettings>(configFile, jsonSerializeOptions);
        }
    }
}