﻿using Bigon.Domain.Models.Entities;
using Bigon.Infrastructure.Abstracts;

namespace Bigon.Application.Repositories
{
    public interface ISpecificationRepository : IAsyncRepository<Specification>
    {
    }
}
