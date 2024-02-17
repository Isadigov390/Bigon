using Bigon.Application.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Bigon.Application.Modules.BlogPostModule.Queries.BlogPostGetByIdCommand
{
    class BlogPostGetByIdRequestHandler : IRequestHandler<BlogPostGetByIdRequest, BlogPostGetByIdRequestDto>
    {
        private readonly IBlogPostRepository blogPostRepository;
        private readonly IActionContextAccessor ctx;

        public BlogPostGetByIdRequestHandler(IBlogPostRepository blogPostRepository,IActionContextAccessor ctx)
        {
            this.blogPostRepository = blogPostRepository;
            this.ctx = ctx;
        }
        public async Task<BlogPostGetByIdRequestDto> Handle(BlogPostGetByIdRequest request, CancellationToken cancellationToken)
        {
            var entity = await blogPostRepository.GetAsync(m => m.Id == request.Id && m.DeletedAt == null, cancellationToken);

            string host = $"{ctx.ActionContext.HttpContext.Request.Scheme}://{ctx.ActionContext.HttpContext.Request.Host}";
            var dto = new BlogPostGetByIdRequestDto();
            dto.Id = entity.Id;
            dto.Title = entity.Title;
            dto.Slug = entity.Slug;
            dto.ImageUrl = $"{host}/uploads/images/{entity.ImagePath}";
            dto.CategoryName = "Demo";
            dto.Body = entity.Body;
            dto.PublishedAt = entity.PublishedAt;
            dto.CategoryId = entity.CategoryId;
            return dto;
        }

    }
}
