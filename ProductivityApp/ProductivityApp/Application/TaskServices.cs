using ProductivityApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.IO;

namespace ProductivityApp.Application
{
    public class TaskService
    {
        private List<Tasks> _tasks;
        private readonly string _dataDirectory;

        public TaskService()
        {
            _dataDirectory = Path.Combine(
               Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
               "ProductivityAnalyzers", "tasks");
  
        Directory.CreateDirectory(_dataDirectory);
            _tasks = LoadTasksForCurrentWeek();
        }

        // Save all tasks for the current week to JSON
        public void SaveTasksForCurrentWeek()
        {
            string filePath = GetCurrentWeekFilePath();
            var json = JsonSerializer.Serialize(_tasks, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }


        // Load tasks for the current week from JSON
        private List<Tasks> LoadTasksForCurrentWeek()
        {
            string filePath = GetCurrentWeekFilePath();
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<List<Tasks>>(json) ?? new List<Tasks>();
            }
            return new List<Tasks>();
        }

        // Helper to get the file path for the current week
        private string GetCurrentWeekFilePath()
        {
            var today = DateTime.Today;
            var cal = System.Globalization.CultureInfo.CurrentCulture.Calendar;
            int week = cal.GetWeekOfYear(today, System.Globalization.CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            int year = today.Year;
            return Path.Combine(_dataDirectory, $"tasks_{year}_week{week}.json");
        }

        // Add a new task
        public void AddTask(string taskName)
        {
            Tasks task = new Tasks(taskName)
            {
                CreatedAt = DateTime.Now // Set the creation time for the task
            };

            _tasks.Add(task); // Add task to the list
            SaveTasksForCurrentWeek();
        }

        // Delete a task by its ID
        public void DeleteTask(string taskId)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == taskId);
            if (task != null)
            {
                _tasks.Remove(task);  // Remove the task from the list
                SaveTasksForCurrentWeek();  // Save the updated task list to the JSON file
            }
        }


        // Mark a task as completed
        public void MarkTaskCompleted(string taskId)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == taskId);
            if (task != null && !task.IsCompleted)
            {
                task.MarkCompleted();  // Mark the task as completed
                SaveTasksForCurrentWeek();  // Ensure the task list is updated and saved
            }
        }


        // Get all tasks
        public List<Tasks> GetAllTasks()
        {
            // Only return today's tasks
            return _tasks.Where(t => t.CreatedAt.Date == DateTime.Today).ToList();
        }

        // Get today's tasks (created today)
        public List<Tasks> GetTodaysTasks()
        {
            return _tasks.Where(t => t.CreatedAt.Date == DateTime.Today).ToList();
        }

        public List<TaskLog> GetCompletedTasks()
        {
            return _tasks
                .Where(t => t.IsCompleted && t.CompletedAt.HasValue && t.CompletedAt.Value.Date == DateTime.Today)
                .Select(t => new TaskLog
                {
                    Name = t.Name,
                    CreatedAt = t.CreatedAt,
                    CompletedAt = t.CompletedAt,
                    Duration = t.Duration
                }).ToList();
        }

        // Get task logs (for display purposes)
        public List<TaskLog> GetTaskLogs()
        {
            return _tasks.Select(t => new TaskLog
            {
                Name = t.Name,
                CreatedAt = t.CreatedAt,
                CompletedAt = t.CompletedAt,
                Duration = t.Duration
            }).ToList();
        }
    }
}
