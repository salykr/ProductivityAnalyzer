namespace ProductivityApp.Domain
{
    public class Tasks
    {
        public string Id { get; set; }  // Unique task identifier
        public string Name { get; set; }  // Task name
        public bool IsCompleted { get; set; }  // Task completion status
        public DateTime CreatedAt { get; set; }  // Timestamp when the task was created
        public DateTime? CompletedAt { get; set; }  // Timestamp when the task was completed (nullable)

        // Constructor to initialize the Id, Name, and CreatedAt timestamp
        public Tasks(string name)
        {
            Id = Guid.NewGuid().ToString();  // Generate a new unique ID for each task
            Name = name;
            IsCompleted = false;  // Default task status is "not completed"
            CreatedAt = DateTime.Now;  // Set the creation time as the current time
        }

        // Mark the task as completed and set the completion timestamp
        public void MarkCompleted()
        {
            IsCompleted = true;  // Set the task's completion status
            CompletedAt = DateTime.Now;  // Set the completion timestamp to the current time
        }

        // Calculate the duration between CreatedAt and CompletedAt
        public TimeSpan Duration
        {
            get
            {
                if (CompletedAt.HasValue)
                    return CompletedAt.Value - CreatedAt;  // Calculate duration if the task is completed
                else
                    return TimeSpan.Zero;  // Return zero duration if not completed
            }
        }
    }
}
