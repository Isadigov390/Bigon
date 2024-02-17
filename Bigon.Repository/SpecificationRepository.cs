using Bigon.Application.Repositories;
using Bigon.Domain.Models.Entities;
using Bigon.Infrastructure.Constracts;
using Microsoft.EntityFrameworkCore;

namespace Bigon.Repository
{
    public class SpecificationRepository : AsyncRepository<Specification>, ISpecificationRepository
    {
        public SpecificationRepository(DbContext db) : base(db)
        {
        }
    }
}
