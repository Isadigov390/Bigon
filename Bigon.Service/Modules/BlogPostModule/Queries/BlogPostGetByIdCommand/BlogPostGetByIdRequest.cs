using MediatR;

namespace Bigon.Application.Modules.BlogPostModule.Queries.BlogPostGetByIdCommand
{
    public class BlogPostGetByIdRequest : IRequest<BlogPostGetByIdRequestDto>
    {
        public int Id { get; set; }
    }
}
