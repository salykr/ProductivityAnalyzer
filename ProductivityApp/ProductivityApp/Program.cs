using System.Windows.Forms;  // This is the correct namespace for WinForms methods
using ProductivityApp.App;
using ProductivityApp.Application;
using ProductivityApp.Domain;  // Your domain logic
using System;

namespace ProductivityApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            // Ensure you're calling WinForms methods from the correct namespace
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

            // Initialize ProfileService to check for profile
            ProfileService profileService = new ProfileService();
            Profile profile = profileService.LoadProfile();  // Try to load profile\
            //string profileInfo = $"Username: {profile.Username}\nEmail: {profile.Email}\nJob Title: {profile.JobTitle}\nTime Zone: {profile.TimeZone}";
            //MessageBox.Show(profileInfo, "Profile Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // If no profile is found, show the ProfileSetupForm
            if (profile == null)
            {
                // Show ProfileSetupForm to collect profile information
                using (var setupForm = new ProfileSetupForm())
                {

                    setupForm.ShowDialog();  // Show as a modal, so it blocks until completed
                }

                // After setup, reload the profile again to get the newly saved profile
                profile = profileService.LoadProfile();
            }

            // Launch Form1 with the profile data (whether new or loaded)
            System.Windows.Forms.Application.Run(new Form1(profile));  // Pass the profile to Form1
        }
    }
}
