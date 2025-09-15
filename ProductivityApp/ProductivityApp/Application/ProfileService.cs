//responsible for managing the profile:
//loading it from the config.json, saving changes, and ensuring the profile data is available when needed.

//Responsibilities:
//Load profile from config.json when the app starts.
//Save profile to config.json when the user provides or updates their information

using ProductivityApp.Domain;
using Newtonsoft.Json;


namespace ProductivityApp.Application
{
    public class ProfileService
    {
        private readonly string _configFilePath;

        public ProfileService()
        {
            _configFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ProductivityAnalyzers", "profile", "config.json");
        }

        public Profile LoadProfile()
        {
            if (File.Exists(_configFilePath))
            {
                Console.WriteLine("File found, loading profile...");
                string json = File.ReadAllText(_configFilePath);
                var profile = JsonConvert.DeserializeObject<Profile>(json);

                // Print loaded profile data
                Console.WriteLine($"Username: {profile.Username}");
                Console.WriteLine($"Email: {profile.Email}");
                Console.WriteLine($"Job Title: {profile.JobTitle}");
                Console.WriteLine($"Time Zone: {profile.TimeZone}");

                return profile;
            }
            else
            {
                Console.WriteLine("Profile file not found!");
            }

            return null;  // Return null if the file doesn't exist
        }



        public void SaveProfile(Profile profile)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(_configFilePath));

            string json = JsonConvert.SerializeObject(profile, Formatting.Indented);

            File.WriteAllText(_configFilePath, json);
        }
    }
}
