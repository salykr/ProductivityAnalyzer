//ConfigService
//responsible for interacting with the actual file system.
//This includes reading and writing the config.json file where the profile is stored.
using ProductivityApp.Domain;
using Newtonsoft.Json;

namespace ProductivityApp.Persistence
{
    public class ConfigService
    {
        private readonly string _configFilePath;

        public ConfigService()
        {
            _configFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ProductivityAnalyzers", "profile", "config.json");
        }

        public Profile Load()
        {
            if (File.Exists(_configFilePath))
            {
                string json = File.ReadAllText(_configFilePath);
                return JsonConvert.DeserializeObject<Profile>(json);
            }
            return null;
        }

        public void Save(Profile profile)
        {
            string json = JsonConvert.SerializeObject(profile, Formatting.Indented);
            File.WriteAllText(_configFilePath, json);
        }
    }
}
