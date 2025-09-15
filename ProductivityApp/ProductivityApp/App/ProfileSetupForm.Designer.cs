namespace ProductivityApp.App
{
    partial class ProfileSetupForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.TextBox jobTitleTextBox;
        private System.Windows.Forms.ComboBox timeZoneComboBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label usernameLabel;  // Label for Username
        private System.Windows.Forms.Label emailLabel;     // Label for Email
        private System.Windows.Forms.Label jobTitleLabel;  // Label for Job Title
        private System.Windows.Forms.Label timeZoneLabel;  // Label for Time Zone

        private void InitializeComponent()
        {
            usernameTextBox = new TextBox();
            emailTextBox = new TextBox();
            jobTitleTextBox = new TextBox();
            timeZoneComboBox = new ComboBox();
            saveButton = new Button();
            usernameLabel = new Label();
            emailLabel = new Label();
            jobTitleLabel = new Label();
            timeZoneLabel = new Label();
            SuspendLayout();
            // 
            // usernameTextBox
            // 
            usernameTextBox.Location = new Point(72, 179);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.Size = new Size(172, 27);
            usernameTextBox.TabIndex = 0;
            // 
            // emailTextBox
            // 
            emailTextBox.Location = new Point(72, 246);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new Size(172, 27);
            emailTextBox.TabIndex = 1;
            // 
            // jobTitleTextBox
            // 
            jobTitleTextBox.Location = new Point(72, 310);
            jobTitleTextBox.Name = "jobTitleTextBox";
            jobTitleTextBox.Size = new Size(172, 27);
            jobTitleTextBox.TabIndex = 2;
            // 
            // timeZoneComboBox
            // 
            timeZoneComboBox.Location = new Point(72, 114);
            timeZoneComboBox.Name = "timeZoneComboBox";
            timeZoneComboBox.Size = new Size(172, 28);
            timeZoneComboBox.TabIndex = 3;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(487, 339);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(80, 31);
            saveButton.TabIndex = 4;
            saveButton.Text = "Save";
            saveButton.Click += saveButton_Click_1;
            // 
            // usernameLabel
            // 
            usernameLabel.Location = new Point(72, 156);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(100, 20);
            usernameLabel.TabIndex = 0;
            usernameLabel.Text = "Username:";
            // 
            // emailLabel
            // 
            emailLabel.Location = new Point(72, 223);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(100, 20);
            emailLabel.TabIndex = 1;
            emailLabel.Text = "Email:";
            // 
            // jobTitleLabel
            // 
            jobTitleLabel.Location = new Point(72, 287);
            jobTitleLabel.Name = "jobTitleLabel";
            jobTitleLabel.Size = new Size(100, 20);
            jobTitleLabel.TabIndex = 2;
            jobTitleLabel.Text = "Job Title:";
            // 
            // timeZoneLabel
            // 
            timeZoneLabel.Location = new Point(72, 81);
            timeZoneLabel.Name = "timeZoneLabel";
            timeZoneLabel.Size = new Size(100, 20);
            timeZoneLabel.TabIndex = 3;
            timeZoneLabel.Text = "Time Zone:";
            // 
            // ProfileSetupForm
            // 
            ClientSize = new Size(622, 402);
            Controls.Add(usernameLabel);
            Controls.Add(usernameTextBox);
            Controls.Add(emailLabel);
            Controls.Add(emailTextBox);
            Controls.Add(jobTitleLabel);
            Controls.Add(jobTitleTextBox);
            Controls.Add(timeZoneLabel);
            Controls.Add(timeZoneComboBox);
            Controls.Add(saveButton);
            Name = "ProfileSetupForm";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
