using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bigon.Presentation.Controllers
{
    public class BlogsController : Controller
    {
        private readonly IMediator mediatr;

        public BlogsController(IMediator mediatr)
        {
            this.mediatr = mediatr;
        }

        public IActionResult Index()
        {
            return View();
        }

        //[Route("{slug}")]
        public IActionResult Details(string slug)
        {
            return Content(slug);
        }
        //public async Task<IActionResult> Details(BlogPostGetBySlugRequest request)
        //{
        //    var response = await mediatr.Send(request); 
        //    return View(response);
        //}
        public IActionResult AddComment()
        {
            return Json(new { });
        }
    }
}
