using System.Collections.Generic;
using Blog.src.Core.Application.Persistance.Contracts;
using BlogApi.Core.Domain.Entity;

namespace Blog.src.Core.Application.Persistance.Contracts
{
    public interface IPostRepository : IGenericRepository<Post> { }
}
