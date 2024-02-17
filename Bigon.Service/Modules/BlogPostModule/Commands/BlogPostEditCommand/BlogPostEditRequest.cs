using MediatR;
using Microsoft.AspNetCore.Http;

namespace Bigon.Application.Modules.BlogPostModule.Commands.BlogPostEditCommand
{
    public class BlogPostEditRequest : IRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public IFormFile Image { get; set; }
        public int CategoryId { get; set; }

    }
}
