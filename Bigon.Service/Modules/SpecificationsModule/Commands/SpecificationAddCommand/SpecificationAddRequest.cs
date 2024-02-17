using Bigon.Domain.Models.Entities;
using MediatR;

namespace Bigon.Application.Modules.SpecificationsModule.Commands.SpecificationAddCommand
{
    public class SpecificationAddRequest : IRequest<Specification>
    {
        public string Name { get; set; }
    }
}
