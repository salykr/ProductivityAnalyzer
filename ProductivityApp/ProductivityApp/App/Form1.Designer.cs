namespace ProductivityApp.App
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.ListBox tasksListBox;  // ListBox to display tasks
        private System.Windows.Forms.TextBox taskNameTextBox;  // TextBox to enter task name
        private System.Windows.Forms.Button addTaskButton;  // Button to add task
        private System.Windows.Forms.Button markCompletedButton;  // Button to mark task as completed

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
            this.tasksListBox = new System.Windows.Forms.ListBox();
            this.taskNameTextBox = new System.Windows.Forms.TextBox();
            this.addTaskButton = new System.Windows.Forms.Button();
            this.markCompletedButton = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // 
            // tasksListBox
            // 
            this.tasksListBox.FormattingEnabled = true;
            this.tasksListBox.ItemHeight = 20;
            this.tasksListBox.Location = new System.Drawing.Point(12, 12);  // Position of ListBox
            this.tasksListBox.Name = "tasksListBox";
            this.tasksListBox.Size = new System.Drawing.Size(300, 200);  // Size of the ListBox
            this.tasksListBox.Text = " ";
            // 
            // taskNameTextBox
            // 
            this.taskNameTextBox.Location = new System.Drawing.Point(12, 230);  // Position of TextBox
            this.taskNameTextBox.Name = "taskNameTextBox";
            this.taskNameTextBox.Size = new System.Drawing.Size(200, 27);  // Size of the TextBox

            // 
            // addTaskButton
            // 
            this.addTaskButton.Location = new System.Drawing.Point(230, 230);  // Position of Button
            this.addTaskButton.Name = "addTaskButton";
            this.addTaskButton.Size = new System.Drawing.Size(75, 30);  // Size of the Button
            this.addTaskButton.Text = "Add Task";
            this.addTaskButton.Click += new System.EventHandler(this.addTaskButton_Click);  // Button Click Event

            // 
            // markCompletedButton
            // 
            this.markCompletedButton.Location = new System.Drawing.Point(12, 270);  // Position of Button
            this.markCompletedButton.Name = "markCompletedButton";
            this.markCompletedButton.Size = new System.Drawing.Size(150, 30);  // Size of the Button
            this.markCompletedButton.Text = "Mark as Completed";
            this.markCompletedButton.Click += new System.EventHandler(this.markCompletedButton_Click);  // Button Click Event

            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(400, 350);
            this.Controls.Add(this.tasksListBox);
            this.Controls.Add(this.taskNameTextBox);
            this.Controls.Add(this.addTaskButton);
            this.Controls.Add(this.markCompletedButton);
            this.Name = "Form1";
            this.Text = "Task Manager";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
