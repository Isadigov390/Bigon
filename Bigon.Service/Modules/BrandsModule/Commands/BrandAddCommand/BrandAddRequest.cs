using Bigon.Domain.Models.Entities;
using MediatR;

namespace Bigon.Application.Modules.BrandsModule.Commands.BrandAddCommand
{
    public class BrandAddRequest : IRequest<Brand>
    {
        public string Name { get; set; }

    } 
}
