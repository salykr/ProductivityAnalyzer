using System;
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

            // Display all tasks on startup
            DisplayTasks();
        }

        // Display all tasks in the ListBox
        private void DisplayTasks()
        {
            tasksListBox.Items.Clear(); // Clear previous items
            List<Tasks> tasks = _taskService.GetAllTasks(); // Retrieve all tasks
            foreach (Tasks task in tasks)
            {
                // Add task to ListBox with completion status and creation timestamp
                tasksListBox.Items.Add($"{task.Name} - Created at: {task.CreatedAt:HH:mm:ss} - {(task.IsCompleted ? "Completed" : "In Progress")}");
            }
        }

        // Add a new task
        private void addTaskButton_Click(object sender, EventArgs e)
        {
            string taskName = taskNameTextBox.Text;
            if (!string.IsNullOrWhiteSpace(taskName))
            {
                _taskService.AddTask(taskName);  // Add task via TaskService
                DisplayTasks();  // Refresh task list
            }
            else
            {
                MessageBox.Show("Please enter a task name.");
            }
        }

        // Mark a task as completed
        private void markCompletedButton_Click(object sender, EventArgs e)
        {
            if (tasksListBox.SelectedItem != null)
            {
                // Extract task name from the selected ListBox item
                string taskName = tasksListBox.SelectedItem.ToString().Split('-')[0].Trim();
                // Find the task by name
                Tasks task = _taskService.GetAllTasks().FirstOrDefault(t => t.Name == taskName);
                if (task != null)
                {
                    _taskService.MarkAsCompleted(task.Id);  // Mark task as completed by Id
                    DisplayTasks();  // Refresh task list to reflect the change
                }
            }
            else
            {
                MessageBox.Show("Please select a task to mark as completed.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Initialization logic (if needed)
        }
    }
}
