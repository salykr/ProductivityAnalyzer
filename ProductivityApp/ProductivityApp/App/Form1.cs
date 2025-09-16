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

            // Display the username before "Task Manager"
            if (profile != null && !string.IsNullOrEmpty(profile.Username))
            {
                titleLabel.Text = $"{profile.Username}'s Task Manager";  // Add username before "Task Manager"
            }
            else
            {
                titleLabel.Text = "Task Manager";  // Fallback in case username is missing
            }

            // Display all tasks on startup
            DisplayTasks();
            DisplayCompletedTasks();
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

        // Delete a selected task
        private void deleteTaskButton_Click(object sender, EventArgs e)
        {
            if (tasksListBox.SelectedItem == null && completedTasksListBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a task to delete.", "Task Manager",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                string taskName = "";

                // Check selected task in tasksListBox (pending tasks)
                if (tasksListBox.SelectedItem != null)
                {
                    string selectedText = tasksListBox.SelectedItem.ToString();
                    taskName = selectedText.Split('•')[0].Trim();
                }
                // Check selected task in completedTasksListBox (completed tasks)
                else if (completedTasksListBox.SelectedItem != null)
                {
                    string selectedText = completedTasksListBox.SelectedItem.ToString();
                    taskName = selectedText.Split('•')[0].Trim();
                }

                // Find the task by name
                Tasks task = _taskService.GetAllTasks().FirstOrDefault(t => t.Name == taskName);

                if (task != null)
                {
                    // Confirm deletion
                    DialogResult result = MessageBox.Show(
                        $"Are you sure you want to delete the task '{taskName}'?",
                        "Confirm Deletion",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        // Remove the task from the UI lists (tasksListBox and completedTasksListBox)
                        if (task.IsCompleted)
                        {
                            completedTasksListBox.Items.Remove(completedTasksListBox.SelectedItem);
                        }
                        else
                        {
                            tasksListBox.Items.Remove(tasksListBox.SelectedItem);
                        }

                        // Remove the task from the task service (task list) and save changes to JSON
                        _taskService.DeleteTask(task.Id); // Delete from TaskService
                        _taskService.SaveTasksForCurrentWeek(); // Update the JSON file with the new task list

                        // Refresh the UI to reflect the updated task lists
                        DisplayTasks();  // Refresh the pending tasks list
                        DisplayCompletedTasks();  // Refresh the completed tasks list

                        ShowTemporaryMessage($"Task '{taskName}' deleted successfully!");
                    }
                }
                else
                {
                    MessageBox.Show("Task not found.", "Task Manager",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            // Set today's date
            todayDateLabel.Text = $"Today: {DateTime.Today:MMMM dd, yyyy}";
        }

        private void DisplayCompletedTasks()
        {
            completedTasksListBox.Items.Clear();  // Clear previous items
            List<TaskLog> completedTasks = _taskService.GetCompletedTasks(); // Retrieve all completed tasks

            foreach (TaskLog task in completedTasks)
            {
                // Format each piece of information on separate lines
                string taskName = task.Name;
                string startTime = task.CreatedAt.ToString("MMM dd, HH:mm");
                string endTime = task.CompletedAt?.ToString("MMM dd, HH:mm") ?? "N/A";
                string duration = task.Duration.ToString(@"hh\:mm\:ss");

                // Add the task name
                completedTasksListBox.Items.Add($" {taskName}");
                // Add start and end time
                completedTasksListBox.Items.Add($"    {startTime} → {endTime}");
                // Add duration
                completedTasksListBox.Items.Add($"    Duration: {duration}");
                // Add empty line for spacing
                completedTasksListBox.Items.Add("");
            }
        }

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

                    _taskService.MarkTaskCompleted(task.Id);  // Mark the task as completed
                    DisplayTasks();  // Refresh the task list to show updated status
                    DisplayCompletedTasks();  // Refresh completed tasks list

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

        private void analyticsMenuItem_Click(object sender, EventArgs e)
        {
            // Open the Daily Analytics form
            var analyticsForm = new AnalyticsForm();
            analyticsForm.ShowDialog(); // Open the form as a modal window
        }
    }
}