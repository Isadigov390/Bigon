using Bigon.Domain.Models.Entities;
using MediatR;

namespace Bigon.Application.Modules.SizesModule.Queries.SizeGetByIdQuery
{
    public class SizeGetByIdRequest : IRequest<SizeGetByIdRequesDto>
    {
        public int Id { get; set; }
        public bool OnlyAvailable { get; set; } 
    }
}
