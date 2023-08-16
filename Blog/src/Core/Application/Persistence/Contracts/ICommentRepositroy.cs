using System.Collections.Generic;
using System.Threading.Tasks; 
using Blog.src.Core.Domain.Entity;

namespace Blog.src.Core.Application.Persistance.Contracts
{
    public interface ICommentRepository : IGenericRepository<Comment>
    {
        Task<List<Comment>> GetAllCommentsAsync(int postId);
    }
}