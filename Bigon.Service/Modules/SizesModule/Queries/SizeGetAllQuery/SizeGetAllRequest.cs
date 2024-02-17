using MediatR;

namespace Bigon.Application.Modules.SizesModule.Queries.SizeGetAllQuery
{
    public class SizeGetAllRequest : IRequest<IEnumerable<SizeGetAllRequestDto>>
    {
        public int Id { get; set; }
        public bool OnlyAvailable { get; set; } = true; 
    }
}
