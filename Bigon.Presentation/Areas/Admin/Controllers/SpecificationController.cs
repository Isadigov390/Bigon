using Bigon.Application.Modules.SpecificationsModule.Commands.SpecificationAddCommand;
using Bigon.Application.Modules.SpecificationsModule.Commands.SpecificationEditCommand;
using Bigon.Application.Modules.SpecificationsModule.Commands.SpecificationRemoveCommand;
using Bigon.Application.Modules.SpecificationsModule.Queries.SpecificationGetAllQuery;
using Bigon.Application.Modules.SpecificationsModule.Queries.SpecificationGetByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bigon.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SpecificationController : Controller
    {
        private readonly IMediator mediator;

        public SpecificationController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public async Task<IActionResult> Index(SpecificationGetAllRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }
        public  IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(SpecificationAddRequest request)
        {
            await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit([FromRoute]SpecificationGetByIdRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(SpecificationEditRequest request)
        {
            await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Remove ([FromRoute]SpecificationRemoveRequest request)
        {
            await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Details (SpecificationGetByIdRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }
    }
}
