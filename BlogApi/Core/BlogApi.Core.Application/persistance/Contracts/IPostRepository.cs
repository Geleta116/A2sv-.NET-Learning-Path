using System.Collections.Generic;
using BlogApi.core.Application.persistance.Contracts;
using BlogApi.Core.Domain;

namespace BlogApi.Core.Application.Persistance.Contracts
{
    public interface IPostRepository : IGenericRepository<Post>
    {

    }
}