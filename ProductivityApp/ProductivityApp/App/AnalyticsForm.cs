using ProductivityApp.Application;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace ProductivityApp.App
{
    public partial class AnalyticsForm : Form
    {
        private readonly TaskService _taskService;

        public AnalyticsForm()
        {
            InitializeComponent();
            _taskService = new TaskService();
            LoadAnalytics();
        }

        private void LoadAnalytics()
        {
            try
            {
                // Get today's tasks
                var tasks = _taskService.GetTodaysTasks();
                int totalTasks = tasks.Count;
                int pendingTasks = tasks.Count(t => !t.IsCompleted);
                int completedTasks = totalTasks - pendingTasks;

                // Calculate time statistics for completed tasks only
                var completedTasksWithTime = tasks.Where(t => t.IsCompleted && t.Duration.TotalMinutes > 0).ToList();

                double avgTime = completedTasksWithTime.Any() ?
                    completedTasksWithTime.Average(t => t.Duration.TotalMinutes) : 0;
                double maxTime = completedTasksWithTime.Any() ?
                    completedTasksWithTime.Max(t => t.Duration.TotalMinutes) : 0;
                double minTime = completedTasksWithTime.Any() ?
                    completedTasksWithTime.Min(t => t.Duration.TotalMinutes) : 0;

                // Calculate completion rate
                double completionRate = totalTasks > 0 ? (double)completedTasks / totalTasks * 100 : 0;

                // Display KPIs
                totalTasksLabel.Text = totalTasks.ToString();
                pendingTasksLabel.Text = pendingTasks.ToString();
                completedTasksLabel.Text = completedTasks.ToString();
                completionRateLabel.Text = $"{completionRate:F1}%";
                avgTimeLabel.Text = avgTime > 0 ? $"{avgTime:F1} min" : "N/A";
                maxTimeLabel.Text = maxTime > 0 ? $"{maxTime:F1} min" : "N/A";
                minTimeLabel.Text = minTime > 0 ? $"{minTime:F1} min" : "N/A";

                // Update date label
                todayDateLabel.Text = DateTime.Today.ToString("MMMM dd, yyyy");

                // Load chart data
                LoadLineChartData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading analytics: {ex.Message}", "Analytics Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Get task completion count by each hour
        private Dictionary<int, int> GetTaskCompletionByHour()
        {
            var taskCompletionByHour = new Dictionary<int, int>();

            try
            {
                // Initialize hours from 8 AM to 8 PM with 0 tasks
                for (int hour = 8; hour <= 20; hour++)
                {
                    taskCompletionByHour[hour] = 0;
                }

                // Loop through today's completed tasks and count them by hour
                var tasks = _taskService.GetTodaysTasks();
                foreach (var task in tasks.Where(t => t.IsCompleted && t.CompletedAt.HasValue))
                {
                    int hour = task.CompletedAt.Value.Hour;

                    // Only count tasks completed between 8 AM and 8 PM
                    if (hour >= 8 && hour <= 20)
                    {
                        taskCompletionByHour[hour]++;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting task completion by hour: {ex.Message}");
            }

            return taskCompletionByHour;
        }

        private void LoadLineChartData()
        {
            try
            {
                // Get real task completion data per hour
                var taskCompletionByHour = GetTaskCompletionByHour();

                // Clear previous points from the chart
                lineChart.Series["Completed Tasks"].Points.Clear();

                // Add points to the chart for each hour
                foreach (var hourData in taskCompletionByHour.OrderBy(x => x.Key))
                {
                    // Format the hour to 12-hour format
                    string timeLabel;
                    if (hourData.Key == 0)
                        timeLabel = "12 AM";
                    else if (hourData.Key < 12)
                        timeLabel = $"{hourData.Key} AM";
                    else if (hourData.Key == 12)
                        timeLabel = "12 PM";
                    else
                        timeLabel = $"{hourData.Key - 12} PM";

                    lineChart.Series["Completed Tasks"].Points.AddXY(timeLabel, hourData.Value);
                }

                // Refresh the chart
                lineChart.Invalidate();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading chart data: {ex.Message}");
            }
        }

        private void RefreshAnalytics()
        {
            LoadAnalytics();
        }
    }
}