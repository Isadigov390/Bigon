using MediatR;

namespace Bigon.Application.Modules.BrandsModule.Commands.BrandRemoveCommand
{
    public class BrandRemoveRequest : IRequest
    {
        public int Id { get; set; }
    }
}
