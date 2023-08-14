using Microsoft.EntityFrameworkCore;
using BlogApi.Data;
using BlogApi.models;
using Xunit;

namespace PostgresDb.Tests
{
    public class PostManagerTests
    {
        private DbContextOptions<ApiDbContext> GetDbContextOptions()
        {
            return new DbContextOptionsBuilder<ApiDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
        }

        [Fact]
        public void CreatePost_ReturnsNonNullPost()
        {
            using (var context = new ApiDbContext(GetDbContextOptions()))
            {
                var postManager = new PostManager(context);
                var title = "Test Post";
                var content = "Test Content";

                var result = postManager.CreatePost(title, content);

                Assert.NotNull(result);
                Assert.Equal(title, result.Title);
                Assert.Equal(content, result.Content);
            }
        }

        [Fact]
        public void GetPostById_ReturnsPostWithMatchingId()
        {
            using (var context = new ApiDbContext(GetDbContextOptions()))
            {
                var postManager = new PostManager(context);
                var post = new Post { Title = "Test Post", Content = "Test Content" };
                context.Posts.Add(post);
                context.SaveChanges();

                var result = postManager.GetPostById(post.PostId);

                Assert.NotNull(result);
                Assert.Equal(post.PostId, result.PostId);
                Assert.Equal(post.Title, result.Title);
                Assert.Equal(post.Content, result.Content);
            }
        }

        [Fact]
        public void UpdatePost_UpdatesPostTitleAndContent()
        {
            using (var context = new ApiDbContext(GetDbContextOptions()))
            {
                var postManager = new PostManager(context);
                var post = new Post { Title = "Initial Title", Content = "Initial Content" };
                context.Posts.Add(post);
                context.SaveChanges();

                var updatedTitle = "Updated Title";
                var updatedContent = "Updated Content";

                var result = postManager.UpdatePost(post.PostId, updatedTitle, updatedContent);

                Assert.NotNull(result);
                Assert.Equal(updatedTitle, result.Title);
                Assert.Equal(updatedContent, result.Content);
            }
        }

        [Fact]
        public void UpdatePost_ReturnsNullIfPostNotFound()
        {
            using (var context = new ApiDbContext(GetDbContextOptions()))
            {
                var postManager = new PostManager(context);
                var nonExistingId = 999;
                var updatedTitle = "Updated Title";
                var updatedContent = "Updated Content";

                var result = postManager.UpdatePost(nonExistingId, updatedTitle, updatedContent);

                Assert.Null(result);
            }
        }
    }
}