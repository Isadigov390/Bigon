    using Bigon.Application.Repositories;
    using Bigon.Domain.Models.Entities;
    using MediatR;

namespace Bigon.Application.Modules.ColorsModule.Queries.ColorGetByIdQuery
{
    class ColorGetByIdRequestHandler : IRequestHandler<ColorGetByIdRequest, ColorGetByIdRequestDto>
    {
        private readonly IColorRepository colorRepository;

        public ColorGetByIdRequestHandler(IColorRepository colorRepository)
        {
            this.colorRepository = colorRepository;
        }
        public async  Task<ColorGetByIdRequestDto> Handle(ColorGetByIdRequest request, CancellationToken cancellationToken)
        {
            Color entity;
            if (request.OnlyAvailable)
            {
                entity = await colorRepository.GetAsync(m => m.Id == request.Id && m.DeletedBy == null, cancellationToken);
            }
            else
            {
                entity = await colorRepository.GetAsync(m => m.Id == request.Id, cancellationToken);
            }


            var dto = new ColorGetByIdRequestDto();
            dto.Id = entity.Id; 
            dto.Name = entity.Name;
            dto.HexCode = entity.HexCode; 
            return dto;
        }
    }   
}
