using MediatR;

namespace Bigon.Application.Modules.SpecificationsModule.Queries.SpecificationGetByIdQuery
{
    public class SpecificationGetByIdRequest : IRequest<SpecificationGetByIdRequestDto>
    {
        public int Id { get; set; }
        public bool OnlyAvailable { get; set; }
    }
}
