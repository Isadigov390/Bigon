    using Bigon.Application.Modules.BrandsModule.Commands.BrandAddCommand;
using Bigon.Application.Modules.BrandsModule.Commands.BrandEditCommand;
using Bigon.Application.Modules.BrandsModule.Commands.BrandRemoveCommand;
using Bigon.Application.Modules.BrandsModule.Queries.BrandGetByIdQuery;
using Bigon.Application.Modules.BrandsModule.Queries.BrandsGetAllQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bigon.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class BrandsController : Controller
    {
        private readonly IMediator mediator;

        public BrandsController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public async Task<IActionResult> Index(BrandGetAllQueryRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(BrandAddRequest request)
        {
            await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit([FromRoute] BrandGetByIdRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(BrandEditRequest request)
        {
            await mediator.Send(request); 
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Remove([FromRoute]BrandRemoveRequest request)
        {
            await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }

            
        public async Task<IActionResult> Details(BrandGetByIdRequest request)
        {
            var response =await mediator.Send(request);
            return View(response);
        }
    }
}
