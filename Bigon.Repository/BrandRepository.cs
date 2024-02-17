using Bigon.Application.Repositories;
using Bigon.Domain.Models.Entities;
using Bigon.Infrastructure.Constracts;
using Microsoft.EntityFrameworkCore;

namespace Bigon.Repository
{
    public class BrandRepository : AsyncRepository<Brand>, IBrandRepository
    {
        public BrandRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
