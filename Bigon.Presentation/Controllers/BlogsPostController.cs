using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bigon.Presentation.Controllers
{
    public class BlogsPostController : Controller
    {
        private readonly IMediator mediatr;

        public BlogsPostController(IMediator mediatr)
        {
            this.mediatr = mediatr;
        }

        public IActionResult Index()
        {
            return View();
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
