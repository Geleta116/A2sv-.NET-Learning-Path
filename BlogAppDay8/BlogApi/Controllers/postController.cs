using Microsoft.AspNetCore.Mvc;
using BlogApi.Data;
using BlogApi.models;

namespace Blog.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly PostManager _postManager;

        public PostController(ApiDbContext context)
        {
            _postManager = new PostManager(context);
        }

        [HttpPost]
        public IActionResult CreatePost([FromBody] PostRequestModel model)
        {
            var post = _postManager.CreatePost(model.Title, model.Content);
            if (post == null)
            {
                return BadRequest("Failed to create the post.");
            }
            return Ok(post);
        }

        [HttpGet("{postId}")]
        public IActionResult GetPostById(int postId)
        {
            var post = _postManager.GetPostById(postId);
            if (post == null)
            {
                return NotFound("Post not found.");
            }
            return Ok(post);
        }

        [HttpPut("{postId}")]
        public IActionResult UpdatePost(int postId, [FromBody] PostRequestModel model)
        {
            var updatedPost = _postManager.UpdatePost(postId, model.Title, model.Content);
            if (updatedPost == null)
            {
                return NotFound("Post not found.");
            }
            return Ok(updatedPost);
        }

        [HttpDelete("{postId}")]
        public IActionResult DeletePost(int postId)
        {
            var result = _postManager.DeletePost(postId);
            if (!result)
            {
                return NotFound("Post not found.");
            }
            return NoContent();
        }

        [HttpGet("{postId}/comments")]
        public IActionResult GetPostWithComment(int postId)
        {
            var post = _postManager.GetPostWithComment(postId);
            if (post == null)
            {
                return NotFound("Post not found.");
            }
            return Ok(post);
        }
    }

    public class PostRequestModel
    {
        public required string Title { get; set; }
        public required string Content { get; set; }
    }
}
