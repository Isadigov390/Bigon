using MediatR;

namespace Bigon.Application.Modules.BrandsModule.Queries.BrandsGetAllQuery
{
    public class BrandGetAllQueryRequest : IRequest<IEnumerable<BrandGetAllQueryRequestDto>>
    {
        public int Id {  get; set; }    
        public bool OnlyAvailable { get; set; } =true;
    }
}
