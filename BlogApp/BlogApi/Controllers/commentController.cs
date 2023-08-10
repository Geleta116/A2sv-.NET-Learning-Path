using Microsoft.AspNetCore.Mvc;
using BlogApi.Data;
using BlogApi.models;
using System;

namespace Blog.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly CommentManager _commentManager;

        public CommentController(ApiDbContext context)
        {
            _commentManager = new CommentManager(context);
        }

        [HttpPost]
        public IActionResult CreateComment([FromBody] CommentRequestModel model)
        {
            var comment = _commentManager.CreateComment(model.Text, model.Postid);
            if (comment == null)
            {
                return BadRequest("Failed to create the comment.");
            }
            return Ok(comment);
        }

        [HttpPut("{commentId}")]
        public IActionResult UpdateComment(int commentId, [FromBody] CommentRequestModel model)
        {
            var updatedComment = _commentManager.UpdateComment(commentId, model.Text);
            if (updatedComment == null)
            {
                return NotFound("Comment not found.");
            }
            return Ok(updatedComment);
        }

        [HttpGet("{commentId}")]
        public IActionResult GetCommentById(int commentId)
        {
            var comment = _commentManager.GetCommentById(commentId);
            if (comment == null)
            {
                return NotFound("Comment not found.");
            }
            return Ok(comment);
        }

        [HttpDelete("{commentId}")]
        public IActionResult DeleteCommentById(int commentId)
        {
            var result = _commentManager.DeleteCommentById(commentId);
            if (!result)
            {
                return NotFound("Comment not found.");
            }
            return NoContent();
        }
    }

    public class CommentRequestModel
    {
        public string Text { get; set; }
        public int Postid { get; set; }
    }
}
