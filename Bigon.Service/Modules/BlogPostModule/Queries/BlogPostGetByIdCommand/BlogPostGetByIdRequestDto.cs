namespace Bigon.Application.Modules.BlogPostModule.Queries.BlogPostGetByIdCommand
{
    public class BlogPostGetByIdRequestDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string ImageUrl { get; set; }
        public string CategoryName { get; set; }
        public int CategoryId{ get; set; }
        public string Body { get; set; }
        public DateTime? PublishedAt { get; set; }
    }
}
