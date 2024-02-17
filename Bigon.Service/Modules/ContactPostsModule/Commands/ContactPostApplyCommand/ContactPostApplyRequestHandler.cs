using Bigon.Application.Repositories;
using Bigon.Domain.Models.Entities;
using MediatR;

namespace Bigon.Application.Modules.ContactPostsModule.Commands.ContactPostApplyCommand
{
    public class ContactPostApplyRequestHandler : IRequestHandler<ContactPostApplyRequest>
    {
        private readonly IContactPostRepository contactPostRepository;

        public ContactPostApplyRequestHandler(IContactPostRepository contactPostRepository)
        {
            this.contactPostRepository = contactPostRepository;
        }

        public async Task Handle(ContactPostApplyRequest request, CancellationToken cancellationToken)
        {
            var entity = new ContactPost();
            entity.FullName = request.FullName;
            entity.Email = request.Email;
            entity.Subject = request.Subject;
            entity.Message = request.Message;
            entity.CreatedAt = DateTime.UtcNow;

            await contactPostRepository.AddAsync(entity, cancellationToken);
            await contactPostRepository.SaveAsync(cancellationToken);
        }
    }
}