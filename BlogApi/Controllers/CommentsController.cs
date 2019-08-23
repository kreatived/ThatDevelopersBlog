using BlogApi.ServiceLayer.Services;
using Microsoft.AspNetCore.Mvc;
using BlogApi.DTO.Responses;
using Microsoft.AspNetCore.Http;

namespace BlogApi.Controllers
{
    [Route("api/posts")]
    [ApiController]
    public class CommentsController: ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        /// <summary>
        ///  Gets paged comments for a post
        /// </summary>
        [HttpGet("{postId}/comments")]
        [ProducesResponseType(typeof(GetCommentsResponse), StatusCodes.Status200OK)]
        public ActionResult<GetCommentsResponse> Get(string postId, int page)
        {
            var comments = _commentService.GetPostComments(postId, page);
            var response = new GetCommentsResponse(comments);
            return Ok(response);
        }
    }
}