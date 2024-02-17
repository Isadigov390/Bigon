using Bigon.Domain.Models.Entities;
using MediatR;

namespace Bigon.Application.Modules.ColorsModule.Queries.ColorGetByIdQuery
{
    public class ColorGetByIdRequest : IRequest<ColorGetByIdRequestDto>
    {
        public int Id { get; set; }
        public bool OnlyAvailable { get; set; } = true;
    }
}
