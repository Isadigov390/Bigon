using MediatR;

namespace Bigon.Application.Modules.SpecificationsModule.Commands.SpecificationRemoveCommand
{
    public class SpecificationRemoveRequest : IRequest
    {
        public int Id { get; set; } 
    }
}
