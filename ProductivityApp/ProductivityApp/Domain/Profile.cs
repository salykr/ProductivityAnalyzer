//data model for user profile information, used as a blueprint for creating profile objects

namespace ProductivityApp.Domain
{
    public class Profile
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string JobTitle { get; set; }
        public string TimeZone { get; set; }
    }
}
