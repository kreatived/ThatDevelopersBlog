using BlogApi.DTO;
using BlogApi.DTO.Responses;
using BlogApi.Exceptions;
using BlogApi.ServiceLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    [Route("api/posts")]
    [ApiController]
    public class PostsController: ControllerBase
    {
        private IPostService _postsService;

        public PostsController(IPostService postsService)
        {
            _postsService = postsService;
        }

        /// <summary>
        ///  Gets all published posts
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(GetPostsResponse), StatusCodes.Status200OK)]
        public ActionResult<GetPostsResponse> Get()
        {
            var posts = _postsService.GetPostSummaries();
            var response = new GetPostsResponse(posts);
            return Ok(response);
        }

        /// <summary>
        /// Gets an individual published post using the associated slug
        /// </summary>
        /// <param name="slug">The uniquely identifying slug of a post</param>
        [HttpGet("{slug}")]
        [ProducesResponseType(typeof(Post), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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