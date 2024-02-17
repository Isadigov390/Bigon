using Bigon.Application.Repositories;
using Bigon.Domain.Models.Entities;
using MediatR;

namespace Bigon.Application.Modules.BrandsModule.Commands.BrandAddCommand
{
    public class BrandAddRequestHandler : IRequestHandler<BrandAddRequest, Brand>
    {
        private readonly IBrandRepository brandRepository;

        public BrandAddRequestHandler(IBrandRepository brandRepository)
        {
            this.brandRepository = brandRepository;
        }

        public async Task<Brand> Handle(BrandAddRequest request, CancellationToken cancellationToken)
        {
            var brand = new Brand
            {
                Name= request.Name,
            };
           brand= await  brandRepository.AddAsync(brand,cancellationToken);
           await brandRepository.SaveAsync(cancellationToken);
            return brand;   

        }
    }
}
