using System;
using System.Linq;
using System.Windows.Forms;
using ProductivityApp.Application;
using ProductivityApp.Domain;

namespace ProductivityApp.App
{
    public partial class Form2 : Form
    {
        private readonly TaskService _taskService;

        public Form2()
        {
            InitializeComponent();
            _taskService = new TaskService();
            DisplayTaskLogs();
        }

        // Display all task logs in DataGridView
        private void DisplayTaskLogs()
        {
            var taskLogs = _taskService.GetTaskLogs();
            taskLogsDataGridView.Rows.Clear();
            foreach (var log in taskLogs)
            {
                taskLogsDataGridView.Rows.Add(log.Name, log.CreatedAt, log.CompletedAt, log.Duration);
            }
        }
    }
}
