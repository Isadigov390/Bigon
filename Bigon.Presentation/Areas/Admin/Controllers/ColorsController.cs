using Bigon.Application.Modules.ColorsModule.Commands.ColorAddCommand;
using Bigon.Application.Modules.ColorsModule.Commands.ColorEditCommand;
using Bigon.Application.Modules.ColorsModule.Queries.ColorGetAllQuery;
using Bigon.Application.Modules.ColorsModule.Queries.ColorGetByIdQuery;
using Bigon.Infrastructure.Exceptions;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace Bigon.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class ColorsController : Controller
    {
        private readonly IMediator mediator;

        public ColorsController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public async Task<IActionResult> Index(ColorGetAllRequest request)
        {
            var response = await mediator.Send(request);    
            return View(response);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ColorAddRequest request)
        {
            await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit([FromRoute]ColorGetByIdRequest request)
        {
            var response =await mediator.Send(request);
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ColorEditRequest request)
        {
          await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }
     
        public async Task<IActionResult> Details(ColorGetByIdRequest request)
        {
             var response = await mediator.Send(request);
             return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Remove([FromRoute]ColorGetByIdRequest request)
        {
              await mediator.Send(request);
             return RedirectToAction(nameof(Index));
        }



    }
}
