using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductivityApp.Domain
{
    public class Tasks
    {
        public string Id { get; set; }  // Make Id read-only outside of the constructor
        public string Name { get; set; }
        public bool IsCompleted { get; set; } // Make the setter private

        public Tasks() { }
        // Constructor to initialize the Id and Name
        public Tasks(string name)
        {
            Id = Guid.NewGuid().ToString();  // Generate a new unique ID for each task
            Name = name;
            IsCompleted = false;  // Default task status
        }

        // Mark the task as completed
        public void MarkCompleted()
        {
            IsCompleted = true; // Set the task's completion status
        }
    }
}
