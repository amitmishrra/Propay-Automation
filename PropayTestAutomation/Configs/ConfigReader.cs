using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NUnitFramework.Configs
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
            // Read the contents of appSettings.json
            var configFile = File.ReadAllText(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/appSettings.json");

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
