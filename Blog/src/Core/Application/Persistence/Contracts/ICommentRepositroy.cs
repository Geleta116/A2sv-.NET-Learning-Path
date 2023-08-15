using System.Collections.Generic;
using Blog.src.Core.Application.Persistance.Contracts;

using Blog.src.Core.Domain.Entity;

namespace Blog.src.Core.Application.Persistance.Contracts
{
    public interface ICommentRepository : IGenericRepository<Comment> { }
}
