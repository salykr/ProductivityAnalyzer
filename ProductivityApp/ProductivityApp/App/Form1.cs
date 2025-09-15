using System;
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

            // Example: Add some tasks for testing
            _taskService.AddTask("Complete Report");
            _taskService.AddTask("Team Meeting");

            DisplayTasks();
        }

        // Display all tasks in the ListBox
        private void DisplayTasks()
        {
            tasksListBox.Items.Clear(); // Clear previous items
            List<Tasks> tasks = _taskService.GetAllTasks();
            foreach (Tasks task in tasks)
            {
                tasksListBox.Items.Add($"{task.Name} - {(task.IsCompleted ? "Completed" : "In Progress")}");
            }
        }

        // Add a new task
        private void addTaskButton_Click(object sender, EventArgs e)
        {
            string taskName = taskNameTextBox.Text;
            if (!string.IsNullOrWhiteSpace(taskName))
            {
                _taskService.AddTask(taskName);
                DisplayTasks();
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
                string taskName = tasksListBox.SelectedItem.ToString().Split('-')[0].Trim();
                Tasks task = _taskService.GetAllTasks().FirstOrDefault(t => t.Name == taskName);
                if (task != null)
                {
                    _taskService.MarkAsCompleted(task.Id);
                    DisplayTasks();
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Add any initialization logic here
        }
    }
}
