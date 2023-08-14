using System.Collections.Generic;
using BlogApi.Core.Application.Persistance.Contracts;
using BlogApi.Core.Domain.Entity;

namespace BlogApi.Core.Application.Persistance.Contracts
{
    public interface ICommentRepository : IGenericRepository<Comment> { }
}
