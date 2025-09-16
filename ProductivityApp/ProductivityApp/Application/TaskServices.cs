using ProductivityApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

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
            Tasks task = new Tasks(taskName)
            {
                CreatedAt = DateTime.Now // Set the creation time for the task
            };

            _tasks.Add(task); // Add task to the list
        }

        public void MarkAsCompleted(string taskId)
        {
            Tasks task = _tasks.FirstOrDefault(t => t.Id == taskId); // Fix the comparison, use the Id directly
            if (task != null)
            {
                task.MarkCompleted(); // Mark task as completed
                task.CompletedAt = DateTime.Now; // Set the completion time for the task
            }
        }

        // Get all tasks
        public List<Tasks> GetAllTasks()
        {
            return _tasks;
        }

        // Get today's tasks (created today)
        public List<Tasks> GetTodaysTasks()
        {
            return _tasks.Where(t => t.CreatedAt.Date == DateTime.Today).ToList();
        }

        // Get task logs (for display purposes)
        public List<TaskLog> GetTaskLogs()
        {
            return _tasks.Select(t => new TaskLog
            {
                Name = t.Name,
                CreatedAt = t.CreatedAt,
                CompletedAt = t.CompletedAt
            }).ToList();
        }
    }
}
