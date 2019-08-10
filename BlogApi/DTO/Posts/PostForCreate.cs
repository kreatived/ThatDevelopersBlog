using System;
using Newtonsoft.Json;

namespace BlogApi.DTO.Posts
{
    public class PostForCreate
    {
        [JsonRequired]
        public string Title { get; set; }
        public string Teaser { get; set; }
        public string HeaderImageUrl { get; set; }
        public string Content { get; set; }
    }
}