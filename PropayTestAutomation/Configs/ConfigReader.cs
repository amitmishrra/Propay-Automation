using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ProPay.Test.NewGen.Runners.Configs
{
    /// <summary>
    /// Class for reading configuration settings from appSettings.json.
    /// </summary>
    public class ConfigReader
    {
        /// <summary>
        /// Reads and deserializes configuration settings from appSettings.json.
        /// </summary>
        /// <returns>An instance of TestSettings containing configuration values.</returns>
        public static TestSettings ReadConfig()
        {
            Console.WriteLine("path to the path:--"+ Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            // Read the contents of appSettings.json
            var configFile = File.ReadAllText(
                "/Users/saurabh/RiderProjects/Propay-Automation/PropayNUnitFramework/Configs/appSettings.json");
            
            // Configure JSON serialization options
            var jsonSerializeOptions = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            };
            jsonSerializeOptions.Converters.Add(new JsonStringEnumConverter());

            // Deserialize the JSON content into TestSettings object
            return JsonSerializer.Deserialize<TestSettings>(configFile, jsonSerializeOptions);
        }
    }
}
