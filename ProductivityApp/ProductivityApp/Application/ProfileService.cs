using ProductivityApp.Domain;
using Newtonsoft.Json;
using System;
using System.IO;

namespace ProductivityApp.Application
{
    public class ProfileService
    {
        private readonly string _configFilePath;

        public ProfileService()
        {
            // Fix the path to ensure the folder name is correct
            _configFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ProductivityAnalyzers", "profile", "config.json");
        }

        // Load the profile from config.json
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

                // Print loaded profile data (you can remove this after debugging)
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

        // Save the profile to config.json
        public void SaveProfile(Profile profile)
        {
            // Ensure the directory exists, create if it doesn't
            Directory.CreateDirectory(Path.GetDirectoryName(_configFilePath));

            // Serialize the profile to JSON format
            string json = JsonConvert.SerializeObject(profile, Formatting.Indented);

            // Write the serialized JSON to the config file
            File.WriteAllText(_configFilePath, json);

            Console.WriteLine("Profile saved successfully.");
        }
    }
}
