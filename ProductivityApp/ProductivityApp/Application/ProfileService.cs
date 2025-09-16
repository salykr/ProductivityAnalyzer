using ProductivityApp.Domain;
using Newtonsoft.Json;
using System;
using System.IO;
//Purpose: This class handles the loading and saving of the user profile.
//->either remove class or ConfigService.cs later, they do the same thing
namespace ProductivityApp.Application
{
    public class ProfileService
    {
        private readonly string _configFilePath;

        public ProfileService()
        {
            _configFilePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "ProductivityAnalyzers", "profile", "config.json");
        }
        public Profile LoadProfile()
        {
            if (File.Exists(_configFilePath))
            {
                Console.WriteLine("File found, loading profile...");

                // Read the content of the file
                string json = File.ReadAllText(_configFilePath);

                if (string.IsNullOrEmpty(json))  // Handle case where file is empty
                {
                    Console.WriteLine("Profile file is empty.");
                    return null;  // Return null if the file is empty
                }

                var profile = JsonConvert.DeserializeObject<Profile>(json);

                return profile;
            }
            else
            {
                //must remove this later, just for testing purposes
                Console.WriteLine("Profile file not found!");
            }

            return null;  // Return null if the file doesn't exist
        }

        // Save the profile to config.json
        public void SaveProfile(Profile profile)
        {
            // Ensure the directory exists, create if it doesn't
            Directory.CreateDirectory(Path.GetDirectoryName(_configFilePath));

            // Serialize the profile to JSON format
            string json = JsonConvert.SerializeObject(profile, Formatting.Indented);

            // Write the serialized JSON to the config file
            File.WriteAllText(_configFilePath, json);

            //must remove this later, just for testing purposes
            Console.WriteLine("Profile saved successfully.");
        }
    }
}
