using MediatR;

namespace Bigon.Application.Modules.ContactPostsModule.Commands.ContactPostApplyCommand
{
    public class ContactPostApplyRequest : IRequest
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}