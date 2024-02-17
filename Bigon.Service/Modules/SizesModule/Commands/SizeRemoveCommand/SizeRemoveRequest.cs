using Bigon.Domain.Models.Entities;
using MediatR;

namespace Bigon.Application.Modules.SizesModule.Commands.SizeRemoveCommand
{
    public class SizeRemoveRequest : IRequest
    {
        public int Id { get; set; } 
    }
}
