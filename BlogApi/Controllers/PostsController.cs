using BlogApi.DTO;
using BlogApi.DTO.Responses;
using BlogApi.Exceptions;
using BlogApi.ServiceLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController: ControllerBase
    {
        private IPostService _postsService;

        public PostsController(IPostService postsService)
        {
            _postsService = postsService;
        }

        [HttpGet]
        public ActionResult<GetPostsResponse> Get()
        {
            var posts = _postsService.GetPostSummaries();
            var response = new GetPostsResponse(posts);
            return Ok(response);
        }

        [HttpGet("{slug}")]
        public ActionResult<Post> Get(string slug)
        {
            try {
                return _postsService.GetPost(slug);
            }catch(PostNotFoundException ex)
            {
                var message = $"Couldn't find post with ${ex.SearchBy} of ${ex.SearchValue}";
                return NotFound(message);   
            }
        }
    }
}