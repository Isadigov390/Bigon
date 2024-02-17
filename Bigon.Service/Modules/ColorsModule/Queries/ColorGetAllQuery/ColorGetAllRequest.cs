using MediatR;

namespace Bigon.Application.Modules.ColorsModule.Queries.ColorGetAllQuery
{
    public class ColorGetAllRequest : IRequest<IEnumerable<ColorGetAllRequestDto>>
    {
        public int Id { get; set; }
        public bool OnlyAvailable { get; set; } = true;
    }
}
