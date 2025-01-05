using ProniaOnion.Application.Abstractions.Repositories;
using ProniaOnion.Domain.Entities;
using ProniaOnion.Persistence.Contexts;

namespace ProniaOnion.Persistence.Implementations.Repositories
{
    internal class BlogRepository : Repository<Blog>, IBlogRepositpry
    {
        public BlogRepository(AppDbContext context) : base(context) { }
    }
}
