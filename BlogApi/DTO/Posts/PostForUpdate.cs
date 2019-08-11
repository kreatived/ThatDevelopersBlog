using System.ComponentModel;
using Newtonsoft.Json;

namespace BlogApi.DTO.Posts
{
    public class PostForUpdate
    {
        [ReadOnly(true)]
        public string Id { get; set; }
        [JsonRequired]
        public string Title { get; set; }
        public string Teaser { get; set; }
        public string HeaderImageUrl { get; set; }
        public string Content { get; set; }
    }
}