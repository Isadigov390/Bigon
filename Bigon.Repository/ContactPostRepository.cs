using Bigon.Application.Repositories;
using Bigon.Domain.Models.Entities;
using Bigon.Infrastructure.Constracts;
using Microsoft.EntityFrameworkCore;

namespace Bigon.Repository
{
    class ContactPostRepository : AsyncRepository<ContactPost>, IContactPostRepository
    {
        public ContactPostRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
