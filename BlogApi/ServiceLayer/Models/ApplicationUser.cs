using System.Collections.Generic;

namespace BlogApi.ServiceLayer.Models
{
    public class ApplicationUser
    {
        public string Id { get; set; }
        public string SubId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string AvatarUrl { get; set; }
        public Dictionary<string, bool> Permissions { get; set; }
    }
}