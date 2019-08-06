using System.Collections.Generic;

namespace BlogApi.DTO.Responses
{
    public class GetPostsResponse
    {
        public List<PostSummary> Posts { get; set; }

        public GetPostsResponse(List<PostSummary> posts)
        {
            Posts = posts;
        }
    }
}