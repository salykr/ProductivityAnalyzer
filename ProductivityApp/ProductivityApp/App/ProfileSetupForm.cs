using System;
using System.Windows.Forms;
using ProductivityApp.Application;  // Include the ProfileService namespace
using ProductivityApp.Domain;      // Include the Profile class

namespace ProductivityApp.App
{
    public partial class ProfileSetupForm : Form
    {
        private readonly ProfileService _profileService;

        public ProfileSetupForm()
        {
            InitializeComponent();  // This will call the designer code (initialize controls)
            _profileService = new ProfileService();

            // Populate TimeZone ComboBox
            foreach (var timeZone in TimeZoneInfo.GetSystemTimeZones())
            {
                timeZoneComboBox.Items.Add(timeZone.DisplayName);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            // Validate inputs
            if (string.IsNullOrWhiteSpace(usernameTextBox.Text) ||
                string.IsNullOrWhiteSpace(emailTextBox.Text) ||
                string.IsNullOrWhiteSpace(jobTitleTextBox.Text) ||
                timeZoneComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            // Create a new profile
            var profile = new Profile
            {
                Username = usernameTextBox.Text,
                Email = emailTextBox.Text,
                JobTitle = jobTitleTextBox.Text,
                TimeZone = timeZoneComboBox.SelectedItem.ToString()
            };

            // Save the profile using ProfileService
            _profileService.SaveProfile(profile);

            // Close the setup form
            MessageBox.Show("Profile saved!");
            this.Close();
        }
    }
}
