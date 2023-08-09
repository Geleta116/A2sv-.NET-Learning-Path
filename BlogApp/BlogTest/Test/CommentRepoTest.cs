using Microsoft.EntityFrameworkCore;
using PostgresDb.Data;
using PostgresDb.Models;
using Xunit;

namespace PostgresDb.Tests
{
    public class CommentManagerTests
    {
        private DbContextOptions<ApiDbContext> GetDbContextOptions()
        {
            return new DbContextOptionsBuilder<ApiDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
        }

        [Fact]
        public void CreateComment_ReturnsNonNullComment()
        {
            
            using (var context = new ApiDbContext(GetDbContextOptions()))
            {
                var commentManager = new CommentManager(context);
                var text = "Test Comment";
                var postId = 1;

                
                var result = commentManager.CreateComment(text, postId);

                
                Assert.NotNull(result);
                Assert.Equal(text, result.Text);
                Assert.Equal(postId, result.PostId);
            }
        }

        [Fact]
        public void GetCommentById_ReturnsCommentWithMatchingId()
        {
            
            using (var context = new ApiDbContext(GetDbContextOptions()))
            {
                var commentManager = new CommentManager(context);
                var comment = new Comment { Text = "Test Comment", PostId = 1 };
                context.Comments.Add(comment);
                context.SaveChanges();

                
                var result = commentManager.GetCommentById(comment.CommentId);

                
                Assert.NotNull(result);
                Assert.Equal(comment.CommentId, result.CommentId);
                Assert.Equal(comment.Text, result.Text);
                Assert.Equal(comment.PostId, result.PostId);
            }
        }

        [Fact]
        public void UpdateComment_UpdatesCommentText()
        {
            
            using (var context = new ApiDbContext(GetDbContextOptions()))
            {
                var commentManager = new CommentManager(context);
                var comment = new Comment { Text = "Initial Comment", PostId = 1 };
                context.Comments.Add(comment);
                context.SaveChanges();

                var updatedText = "Updated Comment Text";

                
                var result = commentManager.UpdateComment(comment.CommentId, updatedText);

                
                Assert.NotNull(result);
                Assert.Equal(updatedText, result.Text);
            }
        }

        [Fact]
        public void UpdateComment_ReturnsNullIfCommentNotFound()
        {
            
            using (var context = new ApiDbContext(GetDbContextOptions()))
            {
                var commentManager = new CommentManager(context);
                var nonExistingId = 999;
                var updatedText = "Updated Comment Text";

                
                var result = commentManager.UpdateComment(nonExistingId, updatedText);

                
                Assert.Null(result);
            }
        }

        [Fact]
        public void DeleteCommentById_RemovesCommentFromDatabase()
        {
            
            using (var context = new ApiDbContext(GetDbContextOptions()))
            {
                var commentManager = new CommentManager(context);
                var comment = new Comment { Text = "Test Comment", PostId = 1 };
                context.Comments.Add(comment);
                context.SaveChanges();

                
                var result = commentManager.DeleteCommentById(comment.CommentId);

                
                Assert.True(result);
                Assert.Null(context.Comments.Find(comment.CommentId));
            }
        }

        [Fact]
        public void DeleteCommentById_ReturnsFalseIfCommentNotFound()
        {
            
            using (var context = new ApiDbContext(GetDbContextOptions()))
            {
                var commentManager = new CommentManager(context);
                var nonExistingId = 999;

                
                var result = commentManager.DeleteCommentById(nonExistingId);

                
                Assert.False(result);
            }
        }

        
        [Fact]
        public void GetCommentById_ReturnsNullOnException()
        {
            
            using (var context = new ApiDbContext(GetDbContextOptions()))
            {
                var commentManager = new CommentManager(context);
                var invalidId = -1;

                
                var result = commentManager.GetCommentById(invalidId);

                
                Assert.Null(result);
            }
        }
    }
}