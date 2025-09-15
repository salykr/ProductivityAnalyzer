using ProductivityApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductivityApp.Application
{
    public class TaskService
    {
        private List<Tasks> _tasks;

        public TaskService()
        {
            _tasks = new List<Tasks>();  // Initialize task list
        }

        // Add a new task
        public void AddTask(string taskName)
        {
            Tasks task = new Tasks(taskName); // Use the constructor to initialize the task
            _tasks.Add(task);
        }

        // Mark a task as completed
        public void MarkAsCompleted(string taskId)
        {
            Tasks task = _tasks.FirstOrDefault(t => t.Id.ToString() == taskId);
            if (task != null)
            {
                task.MarkCompleted(); // Use the method to update the read-only property
            }
        }

        // Get all tasks
        public List<Tasks> GetAllTasks()
        {
            return _tasks;
        }
    }
}