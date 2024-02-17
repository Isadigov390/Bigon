using Autofac;
using Autofac.Extensions.DependencyInjection;
using Bigon.Application;
using Bigon.Application.Services.File;
using Bigon.Application.Services.Identity;
using Bigon.Infrastructure;
using Bigon.Infrastructure.Abstracts;
using Bigon.Infrastructure.Pipeline;
using Bigon.Presentation.Pipeline;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Bigon.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<DbContext>(cfg =>
            {
                cfg.UseSqlServer(builder.Configuration.GetConnectionString("cString"));
            });

            builder.Services.AddRouting(cfg => cfg.LowercaseUrls = true);
            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblyContaining<IApplicationReference>();
            });
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory(cfg =>
            {
                cfg.RegisterModule<AppModule>();

            }));
            var container = new ContainerBuilder();

            builder.Services.AddScoped<IIdentityService, FakeIdentityService>();
            builder.Services.AddSingleton<IFileService, FileService>();
            builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            //builder.Services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            //builder.Services.AddSingleton<IValidatorInterceptor, ValidatorInterceptor>();
            builder.Services.AddFluentValidationAutoValidation(cfg =>
            {
                cfg.DisableDataAnnotationsValidation = false;
            });
            builder.Services.AddValidatorsFromAssemblyContaining<IApplicationReference>(includeInternalTypes:true);
            var app = builder.Build();
            //app.UseErrorHandling();

            app.UseStopwatch();
            app.UseStaticFiles();
            app.MapControllerRoute(name: "areas", pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");
            app.MapControllerRoute(name: "default", pattern: "{controller=home}/{action=index}/{id?}");

            //app.Use(async (context, next) =>
            //{
            //    context.Response.Headers.Add("M1B", $"Test 1 - Before {DateTime.Now:HH:mm:ss:fff}");

            //    var response = context.Response; // Capture response object

            //    context.Response.OnStarting(async (state) =>
            //    {
            //        if (state is HttpResponse)
            //        {
            //            response.Headers.Add("M1A", $"Test 2 - After: {DateTime.Now:HH:mm:ss:fff}");
            //        }

            //    }, context.Response);

            //    await next(context);
            //});





            app.Run();
        }
    }



}
    