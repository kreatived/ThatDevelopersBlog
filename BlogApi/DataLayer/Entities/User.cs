using System.Collections.Generic;

namespace BlogApi.DataLayer.Entities
{
    public class User: Entity
    {
        public string SubId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string AvatarUrl { get; set; }
        public Dictionary<string, bool> Permissions { get; set; }
    }
}