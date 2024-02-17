using Bigon.Infrastructure.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Bigon.Presentation.Pipeline
{
    public class GlobalErrorHandlingMiddleware
    {
        static JsonSerializerSettings jsonSettings = new JsonSerializerSettings()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy
                {
                    ProcessDictionaryKeys = true,
                }
            }
        };

        private readonly RequestDelegate next;

        public GlobalErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {   
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                object response = null;
                int statusCode = StatusCodes.Status500InternalServerError;

                context.Response.ContentType = "application/json";
                switch (ex)
                {
                    case NotFoundException:
                        statusCode = StatusCodes.Status404NotFound;
                        response = new {
                            error=true,
                            message="Qeyd movcud deyil"
                        };

                        break;
                    case CircleReferenceException:
                        statusCode = StatusCodes.Status400BadRequest;
                        response = new {
                            error=true,
                            message=ex.Message,
                        };
                        break;
                    case BadRequestException brEx:
                        statusCode = StatusCodes.Status400BadRequest;
                        response = new {
                            error=true,
                            message=ex.Message,
                            errors=brEx.Errors  
                        };
                        break;

                    default:
                        break;
                }
                context.Response.StatusCode = statusCode;
                var jsonBody=JsonConvert.SerializeObject(response,settings: jsonSettings); 
                await context.Response.WriteAsync(jsonBody);

            }

        }
    }


    public static class GlobalErrorHandlingMiddlewareExtension
    {
        public static IApplicationBuilder UseErrorHandling(this IApplicationBuilder app)
        {
            app.UseMiddleware<GlobalErrorHandlingMiddleware>();
            return app;
        }

    }
}
