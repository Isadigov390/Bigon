using Bigon.Domain.Models.Entities;
using MediatR;

namespace Bigon.Application.Modules.SpecificationsModule.Commands.SpecificationEditCommand
{
    public class SpecificationEditRequest : IRequest<Specification>
    {

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
