using Bigon.Application.Repositories;
using Bigon.Domain.Models.Entities;
using Bigon.Infrastructure.Constracts;
using Microsoft.EntityFrameworkCore;

namespace Bigon.Repository
{
    class BlogPostRepository : AsyncRepository<BlogPost>, IBlogPostRepository
    {
        public BlogPostRepository(DbContext db) : base(db)
        {
        }
    }
}
