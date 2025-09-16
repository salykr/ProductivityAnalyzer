using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ProductivityApp.Application;  // TaskService namespace
using ProductivityApp.Domain;

namespace ProductivityApp.App
{
    public partial class Form1 : Form
    {
        private readonly TaskService _taskService;

        public Form1(Profile profile)
        {
            InitializeComponent();
            _taskService = new TaskService();

            // Set up event handlers
            SetupEventHandlers();

            // Display all tasks on startup
            DisplayTasks();
        }

        private void SetupEventHandlers()
        {
            // Clear textbox text when it gets focus
            taskNameTextBox.Enter += (s, e) => {
                if (taskNameTextBox.Text == "Enter a new task...")
                {
                    taskNameTextBox.Text = "";
                    taskNameTextBox.ForeColor = DarkNavy;
                }
            };

            // Restore placeholder text when textbox loses focus and is empty
            taskNameTextBox.Leave += (s, e) => {
                if (string.IsNullOrWhiteSpace(taskNameTextBox.Text))
                {
                    taskNameTextBox.Text = "Enter a new task...";
                    taskNameTextBox.ForeColor = SlateBlue;
                }
            };

            // Allow Enter key to add task
            taskNameTextBox.KeyPress += (s, e) => {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    addTaskButton_Click(s, e);
                    e.Handled = true;
                }
            };

            // Enable/disable action buttons based on selection
            tasksListBox.SelectedIndexChanged += (s, e) => {
                var hasSelection = tasksListBox.SelectedItem != null;
                markCompletedButton.Enabled = hasSelection;
                deleteTaskButton.Enabled = hasSelection;
            };
        }

        // Display all tasks in the ListBox with improved formatting
        private void DisplayTasks()
        {
            tasksListBox.Items.Clear(); // Clear previous items
            List<Tasks> tasks = _taskService.GetAllTasks(); // Retrieve all tasks

            foreach (Tasks task in tasks)
            {
                // Create more readable task display format
                string status = task.IsCompleted ? "✓ Completed" : "⏳ In Progress";
                string timeDisplay = task.CreatedAt.ToString("MMM dd, HH:mm");
                tasksListBox.Items.Add($"{task.Name} • {timeDisplay} • {status}");
            }

            // Update task count
            UpdateTaskCount(tasks);

            // Clear textbox after adding
            if (taskNameTextBox.Text != "Enter a new task...")
            {
                taskNameTextBox.Clear();
                taskNameTextBox.Focus();
            }

            // Disable action buttons if no selection
            markCompletedButton.Enabled = false;
            deleteTaskButton.Enabled = false;
        }

        private void UpdateTaskCount(List<Tasks> tasks)
        {
            int totalTasks = tasks.Count;
            int completedTasks = tasks.Count(t => t.IsCompleted);
            int pendingTasks = totalTasks - completedTasks;

            if (totalTasks == 0)
            {
                taskCountLabel.Text = "No tasks yet";
            }
            else if (completedTasks == totalTasks)
            {
                taskCountLabel.Text = $"All {totalTasks} tasks completed! 🎉";
            }
            else
            {
                taskCountLabel.Text = $"{pendingTasks} pending • {completedTasks} completed";
            }
        }

        // Add a new task with validation
        private void addTaskButton_Click(object sender, EventArgs e)
        {
            string taskName = taskNameTextBox.Text?.Trim();

            // Check if textbox has placeholder text or is empty
            if (string.IsNullOrWhiteSpace(taskName) || taskName == "Enter a new task...")
            {
                MessageBox.Show("Please enter a task name.", "Task Manager",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                taskNameTextBox.Focus();
                return;
            }

            // Check if task already exists
            var existingTasks = _taskService.GetAllTasks();
            if (existingTasks.Any(t => t.Name.Equals(taskName, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("A task with this name already exists.", "Task Manager",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                taskNameTextBox.SelectAll();
                taskNameTextBox.Focus();
                return;
            }

            try
            {
                _taskService.AddTask(taskName);  // Add task via TaskService
                DisplayTasks();  // Refresh task list

                // Show success feedback
                ShowTemporaryMessage($"Task '{taskName}' added successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding task: {ex.Message}", "Task Manager",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Mark a task as completed with improved error handling
        private void markCompletedButton_Click(object sender, EventArgs e)
        {
            if (tasksListBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a task to mark as completed.", "Task Manager",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                // Extract task name from the selected ListBox item (before the first '•')
                string selectedText = tasksListBox.SelectedItem.ToString();
                string taskName = selectedText.Split('•')[0].Trim();

                // Find the task by name
                Tasks task = _taskService.GetAllTasks().FirstOrDefault(t => t.Name == taskName);

                if (task != null)
                {
                    if (task.IsCompleted)
                    {
                        MessageBox.Show("This task is already completed.", "Task Manager",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    _taskService.MarkAsCompleted(task.Id);  // Mark task as completed by Id
                    DisplayTasks();  // Refresh task list to reflect the change

                    ShowTemporaryMessage($"Task '{taskName}' marked as completed!");
                }
                else
                {
                    MessageBox.Show("Task not found.", "Task Manager",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error completing task: {ex.Message}", "Task Manager",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Delete a selected task
        private void deleteTaskButton_Click(object sender, EventArgs e)
        {
            if (tasksListBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a task to delete.", "Task Manager",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                // Extract task name from the selected ListBox item
                string selectedText = tasksListBox.SelectedItem.ToString();
                string taskName = selectedText.Split('•')[0].Trim();

                // Confirm deletion
                DialogResult result = MessageBox.Show(
                    $"Are you sure you want to delete the task '{taskName}'?",
                    "Confirm Deletion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Find the task by name
                    Tasks task = _taskService.GetAllTasks().FirstOrDefault(t => t.Name == taskName);

                    if (task != null)
                    {
                        _taskService.DeleteTask(task.Id);  // Assuming you have a DeleteTask method
                        DisplayTasks();  // Refresh task list

                        ShowTemporaryMessage($"Task '{taskName}' deleted successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Task not found.", "Task Manager",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting task: {ex.Message}", "Task Manager",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Helper method to show temporary success messages
        private void ShowTemporaryMessage(string message)
        {
            var originalText = titleLabel.Text;
            var originalColor = titleLabel.ForeColor;

            titleLabel.Text = message;
            titleLabel.ForeColor = LightTeal;

            // Use a timer to restore the original text after 2 seconds
            var timer = new System.Windows.Forms.Timer();
            timer.Interval = 2000;
            timer.Tick += (s, e) => {
                titleLabel.Text = originalText;
                titleLabel.ForeColor = originalColor;
                timer.Stop();
                timer.Dispose();
            };
            timer.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Set initial placeholder text appearance
            taskNameTextBox.Text = "Enter a new task...";
            taskNameTextBox.ForeColor = SlateBlue;

            // Disable action buttons initially
            markCompletedButton.Enabled = false;
            deleteTaskButton.Enabled = false;
        }
    }
}