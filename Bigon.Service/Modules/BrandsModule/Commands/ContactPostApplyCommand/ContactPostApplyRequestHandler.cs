using Bigon.Application.Repositories;
using Bigon.Domain.Models.Entities;
using MediatR;

namespace Bigon.Application.Modules.BrandsModule.Commands.ContactPostApplyCommand
{
    class ContactPostApplyRequestHandler : IRequestHandler<ContactPostApplyRequest>
    {
        private readonly IContactPostRepository contactPostRepository;

        public ContactPostApplyRequestHandler(IContactPostRepository  contactPostRepository)
        {
            this.contactPostRepository = contactPostRepository;
        }
        public async Task Handle(ContactPostApplyRequest request, CancellationToken cancellationToken)
        {
            var entity = new ContactPost();

            entity.FullName= request.FullName; 
            entity.Subject = request.Subject; 
            entity.Message = request.Message; 
            entity.Email = request.Email; 

             await contactPostRepository.AddAsync(entity, cancellationToken);  
             await contactPostRepository.SaveAsync(cancellationToken);
        }
    }
}
