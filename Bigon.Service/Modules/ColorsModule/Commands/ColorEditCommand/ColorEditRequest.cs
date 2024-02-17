using Bigon.Domain.Models.Entities;
using MediatR;

namespace Bigon.Application.Modules.ColorsModule.Commands.ColorEditCommand
{
    public class ColorEditRequest : IRequest<Color>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string HexCode { get; set; }
    }
}
