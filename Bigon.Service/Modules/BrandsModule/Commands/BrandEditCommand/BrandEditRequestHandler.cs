using Bigon.Application.Repositories;
using Bigon.Domain.Models.Entities;
using MediatR;

namespace Bigon.Application.Modules.BrandsModule.Commands.BrandEditCommand
{
    class BrandEditRequestHandler : IRequestHandler<BrandEditRequest, Brand>
    {
        private readonly IBrandRepository brandrepsitory;

        public BrandEditRequestHandler(IBrandRepository brandrepsitory)
        {
            this.brandrepsitory = brandrepsitory;
        }
        public async Task<Brand> Handle(BrandEditRequest request, CancellationToken cancellationToken)
        {

            var entity = await  brandrepsitory.GetAsync(m=>m.Id==request.Id);
            entity.Name = request.Name;
             
            await brandrepsitory.EditAsync(entity);
            await brandrepsitory.SaveAsync(cancellationToken);

            return entity;
        }
    }
}
