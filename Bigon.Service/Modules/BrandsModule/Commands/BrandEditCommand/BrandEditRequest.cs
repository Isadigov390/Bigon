using Bigon.Domain.Models.Entities;
using MediatR;

namespace Bigon.Application.Modules.BrandsModule.Commands.BrandEditCommand
{
    public class BrandEditRequest : IRequest<Brand>
    {
        public int Id { get; set; } 
        public string Name { get; set; }    
    }
}
