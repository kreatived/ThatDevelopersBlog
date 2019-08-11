using System.Linq;
using System.Security.Claims;
using BlogApi.DTO;
using BlogApi.DTO.Posts;
using BlogApi.DTO.Responses;
using BlogApi.Exceptions;
using BlogApi.ServiceLayer.Models;
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
        private IUserService _userService;
        private IPostService _postsService;

        public PostsController(IUserService userService, IPostService postsService)
        {
            _userService = userService;
            _postsService = postsService;
        }

        /// <summary>
        ///  Gets all published posts
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(GetPostsResponse), StatusCodes.Status200OK)]
        public ActionResult<GetPostsResponse> GetAll()
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

        /// <summary>
        /// Creates a new instance of a blog post
        /// </summary>
        /// <param name="postForCreate">An object representing the data for a new blog post</param>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(Post), StatusCodes.Status201Created)]
        public ActionResult<Post> Create([FromBody]PostForCreate postForCreate)
        {
            try{
                if(!ModelState.IsValid) 
                {
                    return BadRequest(ModelState);
                }
                
                var subId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
                var user = _userService.GetUserBySubId(subId);

                var newPost = _postsService.CreatePost(postForCreate, user);

                return CreatedAtAction(nameof(Get), newPost);
            }catch(UserNotFoundException)
            {
                return BadRequest();
            }catch(UnauthorizedOperationException)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Update an existing instance of a blog post
        /// </summary>
        /// <param name="postId">The unique id of the blog post to update</param>
        /// <param name="postForUpdate">An object representing the data for the updated blog post</param>
        [HttpPut("{postId}")]
        [Authorize]
        public ActionResult Update(string postId, [FromBody]PostForUpdate postForUpdate)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(postForUpdate);
                }

                var subId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
                var user = _userService.GetUserBySubId(subId);

                _postsService.UpdatePost(postId, postForUpdate, user);

                return Ok();
            }catch(UserNotFoundException)
            {
                return BadRequest();
            }catch(UnauthorizedOperationException)
            {
                return BadRequest();
            }
        }
    }
}