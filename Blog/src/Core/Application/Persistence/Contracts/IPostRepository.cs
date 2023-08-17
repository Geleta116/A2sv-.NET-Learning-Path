using System.Collections.Generic;
using Blog.src.Core.Application.Persistance.Contracts;
using Blog.src.Core.Domain.Entity;

namespace Blog.src.Core.Application.Persistance.Contracts
{
    public interface IPostRepository : IGenericRepository<Post>
    {
        // Task AddPostAsync(string Title, string Content);
        // Task UpdateCommentAsync(int Id, string Title, string Content);
        Task<Post> GetAllCommentsOfAPostAsync(int postId);
        
    }
}
