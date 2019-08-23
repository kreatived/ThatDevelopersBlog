using System.Collections.Generic;
using BlogApi.DTO.Comments;

namespace BlogApi.DTO.Responses
{
    public class GetCommentsResponse
    {
        public List<Comment> Comments { get; set; }

        public GetCommentsResponse(List<Comment> comments)
        {
            Comments = comments;
        }
    }
}