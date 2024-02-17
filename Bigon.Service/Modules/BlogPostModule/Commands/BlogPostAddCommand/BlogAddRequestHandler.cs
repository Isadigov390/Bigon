using Bigon.Application.Repositories;
using Bigon.Domain.Models.Entities;
using Bigon.Infrastructure.Abstracts;
using MediatR;

namespace Bigon.Application.Modules.BlogPostModule.Commands.BlogPostAddCommand
{
    class BlogAddRequestHandler : IRequestHandler<BlogAddRequest, BlogAddRequestDto>
    {
        private readonly IBlogPostRepository blogPostRepository;
        private readonly IFileService fileService;

        public BlogAddRequestHandler(IBlogPostRepository blogPostRepository, IFileService fileService)
        {
            this.blogPostRepository = blogPostRepository;
            this.fileService = fileService;
        }
        public async Task<BlogAddRequestDto> Handle(BlogAddRequest request, CancellationToken cancellationToken)
        {
            var entity = new BlogPost()
            {
                Title = request.Title,
                Slug = request.Title.ToSlug(),
                Body = request.Body,
                CategoryId = request.CategoryId,
            };

            entity.ImagePath = await fileService.UploadAsync(request.Image);

           await  blogPostRepository.AddAsync(entity,cancellationToken);
            await blogPostRepository.SaveAsync(cancellationToken);

            var dto = new BlogAddRequestDto() {
                Id = entity.Id,
                Title = entity.Title,
                Slug = entity.Slug,
                Body = entity.Body,
                ImageUrl = entity.ImagePath
            };
#warning must be complate

            return dto;




        }
    }
}
