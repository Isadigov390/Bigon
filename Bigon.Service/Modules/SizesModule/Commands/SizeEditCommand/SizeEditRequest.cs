using Bigon.Domain.Models.Entities;
using MediatR;

namespace Bigon.Application.Modules.SizesModule.Commands.SizeEditCommand
{
    public  class SizeEditRequest : IRequest<Size>
    {
        public int Id { get; set; } 
        public string Name { get; set; }    
        public string SmallName { get; set; }    

    }
}
