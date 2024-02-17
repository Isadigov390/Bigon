using Bigon.Domain.Models.Entities;
using MediatR;

namespace Bigon.Application.Modules.SizesModule.Commands.SizeAddCommand
{
    public class SizeAddRequest : IRequest<Size>
    {
        public string Name { get; set; }
        public string SmallName { get; set; }

    }
}
