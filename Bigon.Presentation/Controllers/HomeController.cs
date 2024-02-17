using Bigon.Application.Modules.ContactPostsModule.Commands.ContactPostApplyCommand;
using Bigon.Infrastructure.Abstracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NuGet.Versioning;
namespace Bigon.Presentation.Controllers
{
    public class PostAddModel
    {
        public string Name { get; set; }
        public int  Number { get; set; }
        public DateTime  OperationDate { get; set; }
        public IFormFile  CoverFile { get; set; }

    }
    public class HomeController : Controller
    {
        private readonly IMediator mediator;
        private readonly IFileService fileService;
        private readonly IWebHostEnvironment env;

        public HomeController(IMediator mediator,IFileService fileService)
        {
            this.mediator = mediator;
            this.fileService = fileService;
        } 
        public async Task<IActionResult> Index()
        {
            await Task.Delay(TimeSpan.FromMilliseconds(50));
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index([FromForm] PostAddModel model)
        {
            var fileName = await fileService.UploadAsync(model.CoverFile);

            return Content($"{fileName},{model.Name} {model.Number},{model.OperationDate:yyyy.MM.dd HH:mm:ss}");
        }


        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Contact(ContactPostApplyRequest request )
        {
            if (string.IsNullOrWhiteSpace(request.FullName))
            {
                ModelState.AddModelError("FullName", "Ad doldurulmayib");
            } 

            if (string.IsNullOrWhiteSpace(request.Email))
            {
                ModelState.AddModelError("Email", "Email doldurulmayib");
            }

            if (string.IsNullOrWhiteSpace(request.Subject))
            {
                ModelState.AddModelError("Subject", "Subject doldurulmayib");
            }

            if (string.IsNullOrWhiteSpace(request.Message))
            {
                ModelState.AddModelError("Message", "Message doldurulmayib");
            }

            if (ModelState.IsValid)
            {
                await mediator.Send(request);
                return Json(new
                {
                    error=false,
                    message="",
                    errors=new Dictionary<string,IEnumerable<string>>()
                });     
            }


            var errors = ModelState.Select(m => new
            {
                Property = m.Key,
                Messages = m.Value.Errors.Select(m => m.ErrorMessage)
            })
                .ToDictionary(m => m.Property, v => v.Messages);

            return BadRequest(new
            {
                error = true,
                message = "Xeta bas verdi",
                errors = errors
            });

        }

    }
}
