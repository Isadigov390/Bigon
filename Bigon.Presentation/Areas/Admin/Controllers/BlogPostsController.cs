using Bigon.Application.Modules.BlogPostModule.Commands.BlogPostAddCommand;
using Bigon.Application.Modules.BlogPostModule.Commands.BlogPostEditCommand;
using Bigon.Application.Modules.BlogPostModule.Queries.BlogPostGetByIdCommand;
using Bigon.Application.Modules.BlogPostModule.Queries.BlogPostsGetAllCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bigon.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogPostsController : Controller
    {
        private readonly IMediator mediator;

        public BlogPostsController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public async Task<IActionResult> Index(BlogPostGetAllRequest request)
        {
            var response=await mediator.Send(request);
            return View(response);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] BlogAddRequest blogPostRepository)
        {
             await mediator.Send(blogPostRepository); 
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit([FromRoute]BlogPostGetByIdRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] BlogPostEditRequest request)
        {
            await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Details(BlogPostGetByIdRequest request)
        {
            var response = await mediator.Send(request);
            response.Body =Extension.ClearHtml(response.Body);
            return View(response);
        }
    }
}
