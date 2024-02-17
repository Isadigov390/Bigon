using Bigon.Application.Modules.CategoriesModule.Commands.CategoryAddCommand;
using Bigon.Application.Modules.CategoriesModule.Commands.CategoryEditCommand;
using Bigon.Application.Modules.CategoriesModule.Commands.CategoryRemoveCommand;
using Bigon.Application.Modules.CategoriesModule.Queries.CategoriesGetAllQuery;
using Bigon.Application.Modules.CategoriesModule.Queries.CategoriesGetAllSafeQuery;
using Bigon.Application.Modules.CategoriesModule.Queries.CategoriesGetHierarcialQuery;
using Bigon.Application.Modules.CategoriesModule.Queries.CategoriesGetyIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bigon.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly IMediator mediator;

        public CategoriesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IActionResult> Index(CategoriesGetHierarcialRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

        public async Task<IActionResult> Details([FromRoute] CategoryGetByIdRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

        public async Task<IActionResult> Create()
        {
            var categories = await mediator.Send(new CategoriesGetAllRequest());

            SelectList categoryItems = new SelectList(categories, "Id", "Name");

            ViewBag.ParentId = categoryItems;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryAddRequest request)
        {
            await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit([FromRoute] CategoryGetByIdRequest request)
        {
            var response = await mediator.Send(request);


            var categories = await mediator.Send(new CategoriesGetAllSafeRequest { Id = response.Id, Type = response.Type });

            SelectList categoryItems = new SelectList(categories, "Id", "Name");

            ViewBag.ParentId = categoryItems;

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryEditRequest request)
        {
            await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public async Task<IActionResult> GetSafeCategories(CategoriesGetAllSafeRequest request)
        {
            var response = await mediator.Send(request);
            return Json(response);
        }



        [HttpPost]
        public async Task<IActionResult> Remove([FromRoute] CategoryRemoveRequest request)
        {
            await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }

    }
}
