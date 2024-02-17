using Bigon.Application.Repositories;
using Bigon.Domain.Models.Entities;
using Bigon.Infrastructure.Constracts;
using Microsoft.EntityFrameworkCore;

namespace Bigon.Repository
{
    class ColorRepository : AsyncRepository<Color>, IColorRepository
    {
        public ColorRepository(DbContext db) : base(db)
        {
        }
    }
}
