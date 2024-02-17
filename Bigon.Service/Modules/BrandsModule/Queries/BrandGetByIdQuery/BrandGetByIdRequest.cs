using MediatR;

namespace Bigon.Application.Modules.BrandsModule.Queries.BrandGetByIdQuery
{
    public class BrandGetByIdRequest : IRequest<BrandGetByIdRequestDto>
    {

        public int Id { get; set; }
        public bool OnlyAvailable { get; set; } = true;

    }
}
    