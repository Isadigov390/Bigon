using MediatR;

namespace Bigon.Application.Modules.SpecificationsModule.Queries.SpecificationGetAllQuery
{
    public class SpecificationGetAllRequest : IRequest<IEnumerable<SpecificationGetAllRequestDto>>
    {
        public int Id { get; set; }
        public bool OnlyAvailable { get; set; }     
    }
}
    