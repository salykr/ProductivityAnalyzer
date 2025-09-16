using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProductivityApp.App
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Panel mainContentPanel;
        private System.Windows.Forms.ListBox tasksListBox;
        private System.Windows.Forms.Panel inputPanel;
        private System.Windows.Forms.TextBox taskNameTextBox;
        private System.Windows.Forms.Button addTaskButton;
        private System.Windows.Forms.Button markCompletedButton;
        private System.Windows.Forms.Button deleteTaskButton;
        private System.Windows.Forms.Label taskCountLabel;
        private System.Windows.Forms.ListBox completedTasksListBox;
        private System.Windows.Forms.Label todayDateLabel;
        private System.Windows.Forms.Label todayTasksTitleLabel;
        private System.Windows.Forms.Label todayCompletedTitleLabel;

        // Color palette
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
            this.taskCountLabel = new System.Windows.Forms.Label();
            this.mainContentPanel = new System.Windows.Forms.Panel();
            this.todayDateLabel = new System.Windows.Forms.Label();
            this.todayTasksTitleLabel = new System.Windows.Forms.Label();
            this.tasksListBox = new System.Windows.Forms.ListBox();
            this.todayCompletedTitleLabel = new System.Windows.Forms.Label();
            this.completedTasksListBox = new System.Windows.Forms.ListBox();
            this.inputPanel = new System.Windows.Forms.Panel();
            this.taskNameTextBox = new System.Windows.Forms.TextBox();
            this.addTaskButton = new System.Windows.Forms.Button();
            this.markCompletedButton = new System.Windows.Forms.Button();
            this.deleteTaskButton = new System.Windows.Forms.Button();

            this.headerPanel.SuspendLayout();
            this.mainContentPanel.SuspendLayout();
            this.inputPanel.SuspendLayout();
            this.SuspendLayout();

            // 
            // Form1 (Main Form) - Made wider to accommodate side-by-side layout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = LightMint;
            this.ClientSize = new System.Drawing.Size(1000, 700);  // Increased width for side-by-side layout
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Task Manager Pro";
            this.Load += new System.EventHandler(this.Form1_Load);

            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = DarkNavy;
            this.headerPanel.Controls.Add(this.titleLabel);
            this.headerPanel.Controls.Add(this.taskCountLabel);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Padding = new System.Windows.Forms.Padding(20, 15, 20, 15);
            this.headerPanel.Size = new System.Drawing.Size(1000, 80);

            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.titleLabel.ForeColor = LightMint;
            this.titleLabel.Location = new System.Drawing.Point(20, 20);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(167, 32);
            this.titleLabel.Text = "Task Manager";

            // 
            // taskCountLabel
            // 
            this.taskCountLabel.AutoSize = true;
            this.taskCountLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.taskCountLabel.ForeColor = LightTeal;
            this.taskCountLabel.Location = new System.Drawing.Point(800, 30);  // Adjusted for wider form
            this.taskCountLabel.Name = "taskCountLabel";
            this.taskCountLabel.Size = new System.Drawing.Size(72, 19);
            this.taskCountLabel.Text = "0 tasks";

            // 
            // mainContentPanel
            // 
            this.mainContentPanel.BackColor = LightMint;
            this.mainContentPanel.Controls.Add(this.todayDateLabel);
            this.mainContentPanel.Controls.Add(this.todayTasksTitleLabel);
            this.mainContentPanel.Controls.Add(this.tasksListBox);
            this.mainContentPanel.Controls.Add(this.todayCompletedTitleLabel);
            this.mainContentPanel.Controls.Add(this.completedTasksListBox);
            this.mainContentPanel.Controls.Add(this.inputPanel);
            this.mainContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainContentPanel.Location = new System.Drawing.Point(0, 80);
            this.mainContentPanel.Name = "mainContentPanel";
            this.mainContentPanel.Padding = new System.Windows.Forms.Padding(20);
            this.mainContentPanel.Size = new System.Drawing.Size(1000, 620);

            // 
            // todayDateLabel
            // 
            this.todayDateLabel.AutoSize = true;
            this.todayDateLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.todayDateLabel.ForeColor = DarkNavy;
            this.todayDateLabel.Location = new System.Drawing.Point(20, 20);
            this.todayDateLabel.Name = "todayDateLabel";
            this.todayDateLabel.Size = new System.Drawing.Size(200, 25);
            this.todayDateLabel.Text = $"Today: {DateTime.Today:MMMM dd, yyyy}";

            // 
            // todayTasksTitleLabel
            // 
            this.todayTasksTitleLabel.AutoSize = true;
            this.todayTasksTitleLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.todayTasksTitleLabel.ForeColor = DarkNavy;
            this.todayTasksTitleLabel.Location = new System.Drawing.Point(20, 55);
            this.todayTasksTitleLabel.Name = "todayTasksTitleLabel";
            this.todayTasksTitleLabel.Size = new System.Drawing.Size(125, 21);
            this.todayTasksTitleLabel.Text = "Today's Tasks";

            // 
            // tasksListBox
            // 
            this.tasksListBox.BackColor = Color.White;
            this.tasksListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tasksListBox.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tasksListBox.ForeColor = DarkNavy;
            this.tasksListBox.ItemHeight = 24;
            this.tasksListBox.Location = new System.Drawing.Point(20, 85);
            this.tasksListBox.Name = "tasksListBox";
            this.tasksListBox.SelectionMode = System.Windows.Forms.SelectionMode.One;
            this.tasksListBox.Size = new System.Drawing.Size(460, 300);

            // Create custom draw to add hover and selection effects
            this.tasksListBox.DrawMode = DrawMode.OwnerDrawFixed;
            this.tasksListBox.DrawItem += TasksListBox_DrawItem;

            // 
            // todayCompletedTitleLabel
            // 
            this.todayCompletedTitleLabel.AutoSize = true;
            this.todayCompletedTitleLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.todayCompletedTitleLabel.ForeColor = DarkNavy;
            this.todayCompletedTitleLabel.Location = new System.Drawing.Point(500, 55);
            this.todayCompletedTitleLabel.Name = "todayCompletedTitleLabel";
            this.todayCompletedTitleLabel.Size = new System.Drawing.Size(195, 21);
            this.todayCompletedTitleLabel.Text = "Today's Completed Tasks";

            // 
            // completedTasksListBox
            // 
            this.completedTasksListBox.BackColor = Color.White;
            this.completedTasksListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.completedTasksListBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.completedTasksListBox.ForeColor = DarkNavy;
            this.completedTasksListBox.ItemHeight = 20;
            this.completedTasksListBox.Location = new System.Drawing.Point(500, 85);
            this.completedTasksListBox.Name = "completedTasksListBox";
            this.completedTasksListBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.completedTasksListBox.Size = new System.Drawing.Size(460, 300);

            // Create custom draw to match the tasks listbox style
            this.completedTasksListBox.DrawMode = DrawMode.OwnerDrawFixed;
            this.completedTasksListBox.DrawItem += CompletedTasksListBox_DrawItem;

            // 
            // inputPanel
            // 
            this.inputPanel.BackColor = Color.White;
            this.inputPanel.Controls.Add(this.taskNameTextBox);
            this.inputPanel.Controls.Add(this.addTaskButton);
            this.inputPanel.Controls.Add(this.markCompletedButton);
            this.inputPanel.Controls.Add(this.deleteTaskButton);
            this.inputPanel.Location = new System.Drawing.Point(20, 400);
            this.inputPanel.Name = "inputPanel";
            this.inputPanel.Padding = new System.Windows.Forms.Padding(20);
            this.inputPanel.Size = new System.Drawing.Size(940, 120);  // Made wider to span across

            // Add rounded corners effect (simulated with border)
            this.inputPanel.Paint += InputPanel_Paint;

            // 
            // taskNameTextBox
            // 
            this.taskNameTextBox.BackColor = LightMint;
            this.taskNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.taskNameTextBox.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.taskNameTextBox.ForeColor = DarkNavy;
            this.taskNameTextBox.Location = new System.Drawing.Point(20, 20);
            this.taskNameTextBox.Multiline = true;
            this.taskNameTextBox.Name = "taskNameTextBox";
            this.taskNameTextBox.Padding = new System.Windows.Forms.Padding(12);
            this.taskNameTextBox.PlaceholderText = "Enter a new task...";
            this.taskNameTextBox.Size = new System.Drawing.Size(500, 40);  // Made wider

            // Add custom paint for rounded appearance
            this.taskNameTextBox.Paint += TextBox_Paint;

            // 
            // addTaskButton
            // 
            this.addTaskButton.BackColor = LightTeal;
            this.addTaskButton.FlatAppearance.BorderSize = 0;
            this.addTaskButton.FlatAppearance.MouseDownBackColor = SlateBlue;
            this.addTaskButton.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#B5D3CE");
            this.addTaskButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addTaskButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.addTaskButton.ForeColor = DarkNavy;
            this.addTaskButton.Location = new System.Drawing.Point(540, 20);
            this.addTaskButton.Name = "addTaskButton";
            this.addTaskButton.Size = new System.Drawing.Size(150, 40);
            this.addTaskButton.Text = "➕ Add Task";
            this.addTaskButton.UseVisualStyleBackColor = false;
            this.addTaskButton.Click += new System.EventHandler(this.addTaskButton_Click);

            // Add rounded corners
            this.addTaskButton.Paint += Button_Paint;

            // 
            // markCompletedButton
            // 
            this.markCompletedButton.BackColor = SlateBlue;
            this.markCompletedButton.FlatAppearance.BorderSize = 0;
            this.markCompletedButton.FlatAppearance.MouseDownBackColor = DarkNavy;
            this.markCompletedButton.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#8A9BA4");
            this.markCompletedButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.markCompletedButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.markCompletedButton.ForeColor = Color.White;
            this.markCompletedButton.Location = new System.Drawing.Point(20, 70);
            this.markCompletedButton.Name = "markCompletedButton";
            this.markCompletedButton.Size = new System.Drawing.Size(160, 35);
            this.markCompletedButton.Text = "✓ Mark Complete";
            this.markCompletedButton.UseVisualStyleBackColor = false;
            this.markCompletedButton.Click += new System.EventHandler(this.markCompletedButton_Click);

            // Add rounded corners
            this.markCompletedButton.Paint += Button_Paint;

            // 
            // deleteTaskButton
            // 
            this.deleteTaskButton.BackColor = ColorTranslator.FromHtml("#E74C3C");
            this.deleteTaskButton.FlatAppearance.BorderSize = 0;
            this.deleteTaskButton.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#C0392B");
            this.deleteTaskButton.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#EC7063");
            this.deleteTaskButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteTaskButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.deleteTaskButton.ForeColor = Color.White;
            this.deleteTaskButton.Location = new System.Drawing.Point(200, 70);
            this.deleteTaskButton.Name = "deleteTaskButton";
            this.deleteTaskButton.Size = new System.Drawing.Size(120, 35);
            this.deleteTaskButton.Text = "🗑 Delete";
            this.deleteTaskButton.UseVisualStyleBackColor = false;
            this.deleteTaskButton.Click += new System.EventHandler(this.deleteTaskButton_Click);

            // Add rounded corners
            this.deleteTaskButton.Paint += Button_Paint;

            // Add all controls to their respective containers
            this.headerPanel.Controls.Add(this.titleLabel);
            this.headerPanel.Controls.Add(this.taskCountLabel);
            this.mainContentPanel.Controls.Add(this.todayDateLabel);
            this.mainContentPanel.Controls.Add(this.todayTasksTitleLabel);
            this.mainContentPanel.Controls.Add(this.tasksListBox);
            this.mainContentPanel.Controls.Add(this.todayCompletedTitleLabel);
            this.mainContentPanel.Controls.Add(this.completedTasksListBox);
            this.mainContentPanel.Controls.Add(this.inputPanel);
            this.inputPanel.Controls.Add(this.taskNameTextBox);
            this.inputPanel.Controls.Add(this.addTaskButton);
            this.inputPanel.Controls.Add(this.markCompletedButton);
            this.inputPanel.Controls.Add(this.deleteTaskButton);

            // Add panels to form
            this.Controls.Add(this.mainContentPanel);
            this.Controls.Add(this.headerPanel);

            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.mainContentPanel.ResumeLayout(false);
            this.mainContentPanel.PerformLayout();
            this.inputPanel.ResumeLayout(false);
            this.inputPanel.PerformLayout();
            this.ResumeLayout(false);
        }

        // Custom drawing methods for modern appearance
        private void TasksListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            var listBox = sender as ListBox;
            var isSelected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
            var isCompleted = listBox.Items[e.Index].ToString().Contains("Completed");

            // Background
            var backgroundColor = isSelected ? LightTeal : Color.White;
            var textColor = isCompleted ? SlateBlue : DarkNavy;

            using (var brush = new SolidBrush(backgroundColor))
            {
                e.Graphics.FillRectangle(brush, e.Bounds);
            }

            // Text
            var text = listBox.Items[e.Index].ToString();
            var font = isCompleted ? new Font(e.Font, FontStyle.Strikeout) : e.Font;

            using (var brush = new SolidBrush(textColor))
            {
                var textRect = new Rectangle(e.Bounds.X + 10, e.Bounds.Y + 3, e.Bounds.Width - 20, e.Bounds.Height);
                e.Graphics.DrawString(text, font, brush, textRect);
            }

            // Draw focus rectangle if needed
            if (isSelected)
            {
                using (var pen = new Pen(SlateBlue, 2))
                {
                    var focusRect = new Rectangle(e.Bounds.X + 1, e.Bounds.Y + 1, e.Bounds.Width - 2, e.Bounds.Height - 2);
                    e.Graphics.DrawRectangle(pen, focusRect);
                }
            }
        }

        // Custom drawing for completed tasks listbox
        private void CompletedTasksListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            var listBox = sender as ListBox;
            var text = listBox.Items[e.Index].ToString();

            // Background
            using (var brush = new SolidBrush(Color.White))
            {
                e.Graphics.FillRectangle(brush, e.Bounds);
            }

            // Determine text color based on content
            Color textColor = DarkNavy;
            Font textFont = e.Font;

            if (text.StartsWith("📋"))
            {
                // Task name - make it bold
                textFont = new Font(e.Font, FontStyle.Bold);
                textColor = DarkNavy;
            }
            else if (text.StartsWith("   🕒") || text.StartsWith("   ⏱"))
            {
                // Time and duration info - make it slightly lighter
                textColor = SlateBlue;
            }
            else if (string.IsNullOrWhiteSpace(text))
            {
                // Empty line - skip drawing
                return;
            }

            // Draw text
            using (var brush = new SolidBrush(textColor))
            {
                var textRect = new Rectangle(e.Bounds.X + 10, e.Bounds.Y + 2, e.Bounds.Width - 20, e.Bounds.Height);
                e.Graphics.DrawString(text, textFont, brush, textRect);
            }

            // Dispose custom font if created
            if (textFont != e.Font)
            {
                textFont.Dispose();
            }
        }

        private void InputPanel_Paint(object sender, PaintEventArgs e)
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
            using (var pen = new Pen(LightTeal, 1))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, textBox.Width - 1, textBox.Height - 1);
            }
        }

        private void Button_Paint(object sender, PaintEventArgs e)
        {
            // This creates a subtle rounded appearance effect
            var button = sender as Button;
            using (var pen = new Pen(button.BackColor, 1))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, button.Width - 1, button.Height - 1);
            }
        }

        #endregion
    }
}