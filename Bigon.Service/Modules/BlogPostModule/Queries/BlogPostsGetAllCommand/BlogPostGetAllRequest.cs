using MediatR;

namespace Bigon.Application.Modules.BlogPostModule.Queries.BlogPostsGetAllCommand
{
    public class BlogPostGetAllRequest :IRequest<IEnumerable<BlogPostGetAllRequestDto>>
    {
        public bool OnlyAvailable { get; set; } 
    }
}
