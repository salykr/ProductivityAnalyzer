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
            System.Windows.Forms.Application.EnableVisualStyles();  // Fully qualify the namespace
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);  // Fully qualify the namespace

            // Initialize ProfileService to check for profile
            ProfileService profileService = new ProfileService();
            Profile profile = profileService.LoadProfile();

            if (profile == null)
            {
                // No profile found, show ProfileSetupForm
                using (var setupForm = new ProfileSetupForm())
                {
                    setupForm.ShowDialog();  // Show Profile Setup form as a modal
                }
                profile = profileService.LoadProfile(); // Reload profile after setup
            }

            // Launch main form (Form1) after profile is loaded
            System.Windows.Forms.Application.Run(new Form1(profile));  // Fully qualify the namespace
        }
    }
}
