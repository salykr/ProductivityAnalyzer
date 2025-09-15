namespace ProductivityApp.App
{
    partial class ProfileSetupForm
    {
        //private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.TextBox jobTitleTextBox;
        private System.Windows.Forms.ComboBox timeZoneComboBox;
        private System.Windows.Forms.Button saveButton;

        private void InitializeComponent()
        {
            usernameTextBox = new TextBox();
            emailTextBox = new TextBox();
            jobTitleTextBox = new TextBox();
            timeZoneComboBox = new ComboBox();
            saveButton = new Button();
            SuspendLayout();
            // 
            // usernameTextBox
            // 
            usernameTextBox.Location = new Point(72, 133);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.Size = new Size(100, 27);
            usernameTextBox.TabIndex = 0;
            // 
            // emailTextBox
            // 
            emailTextBox.Location = new Point(72, 177);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new Size(100, 27);
            emailTextBox.TabIndex = 1;
            // 
            // jobTitleTextBox
            // 
            jobTitleTextBox.Location = new Point(72, 224);
            jobTitleTextBox.Name = "jobTitleTextBox";
            jobTitleTextBox.Size = new Size(100, 27);
            jobTitleTextBox.TabIndex = 2;
            // 
            // timeZoneComboBox
            // 
            timeZoneComboBox.Location = new Point(72, 90);
            timeZoneComboBox.Name = "timeZoneComboBox";
            timeZoneComboBox.Size = new Size(121, 28);
            timeZoneComboBox.TabIndex = 3;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(72, 52);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(75, 23);
            saveButton.TabIndex = 4;
            // 
            // ProfileSetupForm
            // 
            ClientSize = new Size(622, 402);
            Controls.Add(usernameTextBox);
            Controls.Add(emailTextBox);
            Controls.Add(jobTitleTextBox);
            Controls.Add(timeZoneComboBox);
            Controls.Add(saveButton);
            Name = "ProfileSetupForm";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
