using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.src.Core.Domain.Entity;

namespace Blog.src.Core.Application.Persistance.Contracts
{
    public interface ICommentRepository : IGenericRepository<Comment>
    {
        
        Task AddCommentAsync(int postId, string Text);
        // Task UpdateCommentAsync(int Id, string Text);
        
        
    }
}
