using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductivityApp.Domain
{
    public class TaskLog
    {
        public string Name { get; set; }         // Name of the task
        public DateTime CreatedAt { get; set; }   // Task creation timestamp
        public DateTime? CompletedAt { get; set; } // Task completion timestamp (nullable)
        public TimeSpan Duration { get; set; }    // Duration between CreatedAt and CompletedAt
        public TaskLog() { }

        // Constructor to initialize TaskLog
        public TaskLog(string name, DateTime createdAt, DateTime? completedAt)
        {
            Name = name;
            CreatedAt = createdAt;
            CompletedAt = completedAt;
            Duration = completedAt.HasValue ? completedAt.Value - createdAt : TimeSpan.Zero;
        }
    }
}
