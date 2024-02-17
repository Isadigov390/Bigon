namespace Bigon.Application.Modules.BlogPostModule.Commands.BlogPostAddCommand
{
    public  class BlogAddRequestDto
    {
        public int Id { get; set; } 
        public string Title { get; set; } 
        public string Slug { get; set; } 
        public string ImageUrl { get; set; } 
        public string Body { get; set; } 

    }
}
