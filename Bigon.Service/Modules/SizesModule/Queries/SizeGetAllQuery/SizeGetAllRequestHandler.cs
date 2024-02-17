using Bigon.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bigon.Application.Modules.SizesModule.Queries.SizeGetAllQuery
{
    class SizeGetAllRequestHandler : IRequestHandler<SizeGetAllRequest, IEnumerable<SizeGetAllRequestDto>>
    {
        private readonly ISizeRepository sizeRepository;

        public SizeGetAllRequestHandler(ISizeRepository sizeRepository)
        {
            this.sizeRepository = sizeRepository;
        }
        public async Task<IEnumerable<SizeGetAllRequestDto>> Handle(SizeGetAllRequest request, CancellationToken cancellationToken)
        {
            var query = sizeRepository.GetAll();

            if (request.OnlyAvailable)
            {
                query= query.Where(m=>m.DeletedBy==null);
            }
            var response = await query.Select(m => new SizeGetAllRequestDto
            {
                Id = m.Id,
                Name = m.Name,
                SmallName = m.SmallName,
            }).ToListAsync(cancellationToken);

            return response;
        }
    }
}
