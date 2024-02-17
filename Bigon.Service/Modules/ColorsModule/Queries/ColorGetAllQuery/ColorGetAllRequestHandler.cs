using Bigon.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bigon.Application.Modules.ColorsModule.Queries.ColorGetAllQuery
{
    class ColorGetAllRequestHandler : IRequestHandler<ColorGetAllRequest, IEnumerable<ColorGetAllRequestDto>>
    {
        private readonly IColorRepository colorRepository;

        public ColorGetAllRequestHandler(IColorRepository colorRepository)
        {
            this.colorRepository = colorRepository;
        }
        public async Task<IEnumerable<ColorGetAllRequestDto>> Handle(ColorGetAllRequest request, CancellationToken cancellationToken)
        {
            var query = colorRepository.GetAll();
                
            if (request.OnlyAvailable)
            {
                query = query.Where(m => m.DeletedBy == null);
            }
            var response = await query.Select(m => new ColorGetAllRequestDto
            {
                Id = m.Id,
                Name = m.Name,
                HexCode= m.HexCode,
            }).ToListAsync(cancellationToken);

            return response;
        }
    }
}
