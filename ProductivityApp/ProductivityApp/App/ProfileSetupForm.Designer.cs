using System.Drawing;
using System.Windows.Forms;

namespace ProductivityApp.App
{
    partial class ProfileSetupForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label subtitleLabel;
        private System.Windows.Forms.Panel mainContentPanel;
        private System.Windows.Forms.Panel formPanel;

        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.Label jobTitleLabel;
        private System.Windows.Forms.TextBox jobTitleTextBox;
        private System.Windows.Forms.Label timeZoneLabel;
        private System.Windows.Forms.ComboBox timeZoneComboBox;

        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;

        // Color palette - same as Task Manager
        private readonly Color DarkNavy = ColorTranslator.FromHtml("#19183B");
        private readonly Color SlateBlue = ColorTranslator.FromHtml("#708993");
        private readonly Color LightTeal = ColorTranslator.FromHtml("#A1C2BD");
        private readonly Color LightMint = ColorTranslator.FromHtml("#E7F2EF");

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.headerPanel = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.subtitleLabel = new System.Windows.Forms.Label();
            this.mainContentPanel = new System.Windows.Forms.Panel();
            this.formPanel = new System.Windows.Forms.Panel();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.emailLabel = new System.Windows.Forms.Label();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.jobTitleLabel = new System.Windows.Forms.Label();
            this.jobTitleTextBox = new System.Windows.Forms.TextBox();
            this.timeZoneLabel = new System.Windows.Forms.Label();
            this.timeZoneComboBox = new System.Windows.Forms.ComboBox();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();

            this.headerPanel.SuspendLayout();
            this.mainContentPanel.SuspendLayout();
            this.formPanel.SuspendLayout();
            this.buttonPanel.SuspendLayout();
            this.SuspendLayout();

            // 
            // ProfileSetupForm (Main Form)
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = LightMint;
            this.ClientSize = new System.Drawing.Size(550, 650);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProfileSetupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Profile Setup - Task Manager Pro";

            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = DarkNavy;
            this.headerPanel.Controls.Add(this.titleLabel);
            this.headerPanel.Controls.Add(this.subtitleLabel);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Padding = new System.Windows.Forms.Padding(30, 25, 30, 25);
            this.headerPanel.Size = new System.Drawing.Size(550, 120);

            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.titleLabel.ForeColor = LightMint;
            this.titleLabel.Location = new System.Drawing.Point(30, 25);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(220, 45);
            this.titleLabel.Text = "Welcome! 👋";

            // 
            // subtitleLabel
            // 
            this.subtitleLabel.AutoSize = true;
            this.subtitleLabel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.subtitleLabel.ForeColor = LightTeal;
            this.subtitleLabel.Location = new System.Drawing.Point(30, 75);
            this.subtitleLabel.Name = "subtitleLabel";
            this.subtitleLabel.Size = new System.Drawing.Size(280, 20);
            this.subtitleLabel.Text = "Let's set up your profile to get started";

            // 
            // mainContentPanel
            // 
            this.mainContentPanel.BackColor = LightMint;
            this.mainContentPanel.Controls.Add(this.formPanel);
            this.mainContentPanel.Controls.Add(this.buttonPanel);
            this.mainContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainContentPanel.Location = new System.Drawing.Point(0, 120);
            this.mainContentPanel.Name = "mainContentPanel";
            this.mainContentPanel.Padding = new System.Windows.Forms.Padding(30);
            this.mainContentPanel.Size = new System.Drawing.Size(550, 530);

            // 
            // formPanel
            // 
            this.formPanel.BackColor = Color.White;
            this.formPanel.Controls.Add(this.usernameLabel);
            this.formPanel.Controls.Add(this.usernameTextBox);
            this.formPanel.Controls.Add(this.emailLabel);
            this.formPanel.Controls.Add(this.emailTextBox);
            this.formPanel.Controls.Add(this.jobTitleLabel);
            this.formPanel.Controls.Add(this.jobTitleTextBox);
            this.formPanel.Controls.Add(this.timeZoneLabel);
            this.formPanel.Controls.Add(this.timeZoneComboBox);
            this.formPanel.Location = new System.Drawing.Point(30, 30);
            this.formPanel.Name = "formPanel";
            this.formPanel.Padding = new System.Windows.Forms.Padding(40, 30, 40, 30);
            this.formPanel.Size = new System.Drawing.Size(490, 380);

            // Add custom paint for border
            this.formPanel.Paint += FormPanel_Paint;

            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.usernameLabel.ForeColor = DarkNavy;
            this.usernameLabel.Location = new System.Drawing.Point(40, 30);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(120, 20);
            this.usernameLabel.Text = "👤 Username";

            // 
            // usernameTextBox
            // 
            this.usernameTextBox.BackColor = LightMint;
            this.usernameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.usernameTextBox.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.usernameTextBox.ForeColor = DarkNavy;
            this.usernameTextBox.Location = new System.Drawing.Point(40, 60);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(410, 22);
            this.usernameTextBox.TabIndex = 0;
            this.usernameTextBox.Padding = new System.Windows.Forms.Padding(15, 12, 15, 12);

            // Custom styling
            this.usernameTextBox.Paint += TextBox_Paint;
            this.usernameTextBox.Enter += TextBox_Enter;
            this.usernameTextBox.Leave += TextBox_Leave;

            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.emailLabel.ForeColor = DarkNavy;
            this.emailLabel.Location = new System.Drawing.Point(40, 110);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(90, 20);
            this.emailLabel.Text = "📧 Email";

            // 
            // emailTextBox
            // 
            this.emailTextBox.BackColor = LightMint;
            this.emailTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.emailTextBox.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.emailTextBox.ForeColor = DarkNavy;
            this.emailTextBox.Location = new System.Drawing.Point(40, 140);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(410, 22);
            this.emailTextBox.TabIndex = 1;

            // Custom styling
            this.emailTextBox.Paint += TextBox_Paint;
            this.emailTextBox.Enter += TextBox_Enter;
            this.emailTextBox.Leave += TextBox_Leave;

            // 
            // jobTitleLabel
            // 
            this.jobTitleLabel.AutoSize = true;
            this.jobTitleLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.jobTitleLabel.ForeColor = DarkNavy;
            this.jobTitleLabel.Location = new System.Drawing.Point(40, 190);
            this.jobTitleLabel.Name = "jobTitleLabel";
            this.jobTitleLabel.Size = new System.Drawing.Size(105, 20);
            this.jobTitleLabel.Text = "💼 Job Title";

            // 
            // jobTitleTextBox
            // 
            this.jobTitleTextBox.BackColor = LightMint;
            this.jobTitleTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.jobTitleTextBox.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.jobTitleTextBox.ForeColor = DarkNavy;
            this.jobTitleTextBox.Location = new System.Drawing.Point(40, 220);
            this.jobTitleTextBox.Name = "jobTitleTextBox";
            this.jobTitleTextBox.Size = new System.Drawing.Size(410, 22);
            this.jobTitleTextBox.TabIndex = 2;

            // Custom styling
            this.jobTitleTextBox.Paint += TextBox_Paint;
            this.jobTitleTextBox.Enter += TextBox_Enter;
            this.jobTitleTextBox.Leave += TextBox_Leave;

            // 
            // timeZoneLabel
            // 
            this.timeZoneLabel.AutoSize = true;
            this.timeZoneLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.timeZoneLabel.ForeColor = DarkNavy;
            this.timeZoneLabel.Location = new System.Drawing.Point(40, 270);
            this.timeZoneLabel.Name = "timeZoneLabel";
            this.timeZoneLabel.Size = new System.Drawing.Size(115, 20);
            this.timeZoneLabel.Text = "🌍 Time Zone";

            // 
            // timeZoneComboBox
            // 
            this.timeZoneComboBox.BackColor = LightMint;
            this.timeZoneComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.timeZoneComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.timeZoneComboBox.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.timeZoneComboBox.ForeColor = DarkNavy;
            this.timeZoneComboBox.FormattingEnabled = true;
            this.timeZoneComboBox.Location = new System.Drawing.Point(40, 300);
            this.timeZoneComboBox.Name = "timeZoneComboBox";
            this.timeZoneComboBox.Size = new System.Drawing.Size(410, 29);
            this.timeZoneComboBox.TabIndex = 3;

            // Custom styling
            this.timeZoneComboBox.Paint += ComboBox_Paint;

            // 
            // buttonPanel
            // 
            this.buttonPanel.BackColor = LightMint;
            this.buttonPanel.Controls.Add(this.saveButton);
            this.buttonPanel.Controls.Add(this.cancelButton);
            this.buttonPanel.Location = new System.Drawing.Point(30, 430);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(490, 70);

            // 
            // saveButton
            // 
            this.saveButton.BackColor = LightTeal;
            this.saveButton.FlatAppearance.BorderSize = 0;
            this.saveButton.FlatAppearance.MouseDownBackColor = SlateBlue;
            this.saveButton.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#B5D3CE");
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.saveButton.ForeColor = DarkNavy;
            this.saveButton.Location = new System.Drawing.Point(280, 15);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(200, 45);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "✅ Save Profile";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);

            // Add rounded appearance
            this.saveButton.Paint += Button_Paint;

            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = SlateBlue;
            this.cancelButton.FlatAppearance.BorderSize = 0;
            this.cancelButton.FlatAppearance.MouseDownBackColor = DarkNavy;
            this.cancelButton.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#8A9BA4");
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.cancelButton.ForeColor = Color.White;
            this.cancelButton.Location = new System.Drawing.Point(60, 15);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(120, 45);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "✖ Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);

            // Add rounded appearance
            this.cancelButton.Paint += Button_Paint;

            // Add all controls to their respective containers
            this.headerPanel.Controls.Add(this.titleLabel);
            this.headerPanel.Controls.Add(this.subtitleLabel);

            this.formPanel.Controls.Add(this.usernameLabel);
            this.formPanel.Controls.Add(this.usernameTextBox);
            this.formPanel.Controls.Add(this.emailLabel);
            this.formPanel.Controls.Add(this.emailTextBox);
            this.formPanel.Controls.Add(this.jobTitleLabel);
            this.formPanel.Controls.Add(this.jobTitleTextBox);
            this.formPanel.Controls.Add(this.timeZoneLabel);
            this.formPanel.Controls.Add(this.timeZoneComboBox);

            this.buttonPanel.Controls.Add(this.saveButton);
            this.buttonPanel.Controls.Add(this.cancelButton);

            this.mainContentPanel.Controls.Add(this.formPanel);
            this.mainContentPanel.Controls.Add(this.buttonPanel);

            // Add panels to form
            this.Controls.Add(this.mainContentPanel);
            this.Controls.Add(this.headerPanel);

            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.mainContentPanel.ResumeLayout(false);
            this.formPanel.ResumeLayout(false);
            this.formPanel.PerformLayout();
            this.buttonPanel.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        // Custom drawing methods for modern appearance
        private void FormPanel_Paint(object sender, PaintEventArgs e)
        {
            var panel = sender as Panel;
            using (var pen = new Pen(LightTeal, 2))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, panel.Width - 1, panel.Height - 1);
            }
        }

        private void TextBox_Paint(object sender, PaintEventArgs e)
        {
            var textBox = sender as TextBox;

            // Draw background
            using (var brush = new SolidBrush(LightMint))
            {
                e.Graphics.FillRectangle(brush, 0, 0, textBox.Width, textBox.Height);
            }

            // Draw border
            using (var pen = new Pen(LightTeal, 1))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, textBox.Width - 1, textBox.Height - 1);
            }
        }

        private void ComboBox_Paint(object sender, PaintEventArgs e)
        {
            var comboBox = sender as ComboBox;
            using (var pen = new Pen(LightTeal, 1))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, comboBox.Width - 1, comboBox.Height - 1);
            }
        }

        private void Button_Paint(object sender, PaintEventArgs e)
        {
            var button = sender as Button;
            using (var pen = new Pen(button.BackColor, 1))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, button.Width - 1, button.Height - 1);
            }
        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            textBox.BackColor = Color.White;
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            textBox.BackColor = LightMint;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            // Close the form when the cancel button is clicked
            this.Close();
        }

        #endregion
    }
}