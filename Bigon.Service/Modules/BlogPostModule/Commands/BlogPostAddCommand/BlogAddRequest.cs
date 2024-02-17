using MediatR;
using Microsoft.AspNetCore.Http;

namespace Bigon.Application.Modules.BlogPostModule.Commands.BlogPostAddCommand
{
    public class BlogAddRequest : IRequest<BlogAddRequestDto>
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public IFormFile Image { get; set; }
        public int CategoryId { get; set; }

    }
}
