using System;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
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

            SetupFormEvents();
            PopulateTimeZones();
            SetupValidation();
        }

        private void SetupFormEvents()
        {
            // Handle Enter key navigation between fields
            usernameTextBox.KeyPress += (s, e) =>
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    emailTextBox.Focus();
                    e.Handled = true;
                }
            };

            emailTextBox.KeyPress += (s, e) =>
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    jobTitleTextBox.Focus();
                    e.Handled = true;
                }
            };

            jobTitleTextBox.KeyPress += (s, e) =>
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    timeZoneComboBox.Focus();
                    e.Handled = true;
                }
            };

            // Handle Escape key to cancel
            this.KeyPreview = true;
            this.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Escape)
                {
                    cancelButton_Click(s, e);
                }
            };
        }

        private void PopulateTimeZones()
        {
            timeZoneComboBox.Items.Clear();

            // Get system time zones and sort them by base UTC offset
            var timeZones = TimeZoneInfo.GetSystemTimeZones()
                .OrderBy(tz => tz.BaseUtcOffset)
                .ToList();

            foreach (var timeZone in timeZones)
            {
                timeZoneComboBox.Items.Add(timeZone.DisplayName);
            }

            // Try to set the local time zone as default
            try
            {
                var localTimeZone = TimeZoneInfo.Local;
                var localDisplayName = localTimeZone.DisplayName;
                var index = timeZoneComboBox.Items.IndexOf(localDisplayName);
                if (index >= 0)
                {
                    timeZoneComboBox.SelectedIndex = index;
                }
            }
            catch
            {
                // If we can't set local timezone, that's okay
            }
        }

        private void SetupValidation()
        {
            // Real-time validation for email
            emailTextBox.Leave += (s, e) =>
            {
                ValidateEmail();
            };

            // Real-time validation for username
            usernameTextBox.Leave += (s, e) =>
            {
                ValidateUsername();
            };

            // Validate fields on text change
            usernameTextBox.TextChanged += (s, e) => UpdateSaveButtonState();
            emailTextBox.TextChanged += (s, e) => UpdateSaveButtonState();
            jobTitleTextBox.TextChanged += (s, e) => UpdateSaveButtonState();
            timeZoneComboBox.SelectedIndexChanged += (s, e) => UpdateSaveButtonState();
        }

        private void UpdateSaveButtonState()
        {
            bool isValid = !string.IsNullOrWhiteSpace(usernameTextBox.Text) &&
                          !string.IsNullOrWhiteSpace(emailTextBox.Text) &&
                          !string.IsNullOrWhiteSpace(jobTitleTextBox.Text) &&
                          timeZoneComboBox.SelectedItem != null &&
                          IsValidEmail(emailTextBox.Text) &&
                          IsValidUsername(usernameTextBox.Text);

            saveButton.Enabled = isValid;
            saveButton.BackColor = isValid ? LightTeal : SlateBlue;
        }

        private bool ValidateEmail()
        {
            string email = emailTextBox.Text.Trim();
            bool isValid = IsValidEmail(email);

            if (!string.IsNullOrWhiteSpace(email) && !isValid)
            {
                ShowFieldError(emailTextBox, "Please enter a valid email address");
                return false;
            }

            ClearFieldError(emailTextBox);
            return true;
        }

        private bool ValidateUsername()
        {
            string username = usernameTextBox.Text.Trim();
            bool isValid = IsValidUsername(username);

            if (!string.IsNullOrWhiteSpace(username) && !isValid)
            {
                ShowFieldError(usernameTextBox, "Username must be 3-20 characters, alphanumeric only");
                return false;
            }

            ClearFieldError(usernameTextBox);
            return true;
        }

        private void ShowFieldError(Control control, string message)
        {
            control.BackColor = ColorTranslator.FromHtml("#FFEBEE"); // Light red

            // Show tooltip with error message
            ToolTip tooltip = new ToolTip();
            tooltip.ToolTipTitle = "Validation Error";
            tooltip.Show(message, control, 0, control.Height + 5, 3000);
        }

        private void ClearFieldError(Control control)
        {
            if (control == usernameTextBox || control == emailTextBox || control == jobTitleTextBox)
            {
                control.BackColor = control.Focused ? Color.White : LightMint;
            }
        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Simple regex for email validation
                string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
                return Regex.IsMatch(email, pattern);
            }
            catch
            {
                return false;
            }
        }

        private bool IsValidUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return false;

            // Username should be 3-20 characters, alphanumeric and underscore only
            string pattern = @"^[a-zA-Z0-9_]{3,20}$";
            return Regex.IsMatch(username, pattern);
        }

        private void ShowSuccessMessage(string message)
        {
            var originalTitle = titleLabel.Text;
            var originalColor = titleLabel.ForeColor;

            titleLabel.Text = message;
            titleLabel.ForeColor = LightTeal;

            // Use a timer to restore the original text after 2 seconds
            var timer = new System.Windows.Forms.Timer();
            timer.Interval = 2000;
            timer.Tick += (s, e) =>
            {
                titleLabel.Text = originalTitle;
                titleLabel.ForeColor = originalColor;
                timer.Stop();
                timer.Dispose();
            };
            timer.Start();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            // Validate all inputs thoroughly
            if (!ValidateAllFields())
            {
                return;
            }

            try
            {
                // Create a new profile with trimmed values
                var profile = new Profile
                {
                    Username = usernameTextBox.Text.Trim(),
                    Email = emailTextBox.Text.Trim().ToLower(), // Normalize email
                    JobTitle = jobTitleTextBox.Text.Trim(),
                    TimeZone = timeZoneComboBox.SelectedItem.ToString()
                };

                // Save the profile using ProfileService
                _profileService.SaveProfile(profile);

                // Show success message
                ShowSuccessMessage("Profile saved successfully! ✅");

                // Close the setup form after a brief delay
                var timer = new System.Windows.Forms.Timer();
                timer.Interval = 1500;
                timer.Tick += (s, args) =>
                {
                    timer.Stop();
                    timer.Dispose();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                };
                timer.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving profile: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateAllFields()
        {
            bool isValid = true;
            string errorMessage = "";

            // Validate username
            if (string.IsNullOrWhiteSpace(usernameTextBox.Text))
            {
                errorMessage += "• Username is required\n";
                isValid = false;
            }
            else if (!IsValidUsername(usernameTextBox.Text.Trim()))
            {
                errorMessage += "• Username must be 3-20 characters, alphanumeric only\n";
                isValid = false;
            }

            // Validate email
            if (string.IsNullOrWhiteSpace(emailTextBox.Text))
            {
                errorMessage += "• Email is required\n";
                isValid = false;
            }
            else if (!IsValidEmail(emailTextBox.Text.Trim()))
            {
                errorMessage += "• Please enter a valid email address\n";
                isValid = false;
            }

            // Validate job title
            if (string.IsNullOrWhiteSpace(jobTitleTextBox.Text))
            {
                errorMessage += "• Job title is required\n";
                isValid = false;
            }
            else if (jobTitleTextBox.Text.Trim().Length < 2)
            {
                errorMessage += "• Job title must be at least 2 characters\n";
                isValid = false;
            }

            // Validate timezone
            if (timeZoneComboBox.SelectedItem == null)
            {
                errorMessage += "• Time zone is required\n";
                isValid = false;
            }

            // Show error message if validation fails
            if (!isValid)
            {
                MessageBox.Show(errorMessage, "Validation Errors", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return isValid;
        }
    }
}