using System.Diagnostics;

namespace Bigon.Presentation.Pipeline
{
    public class StopWatchMiddleware
    {
        private readonly RequestDelegate next;

        public StopWatchMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            Stopwatch sw= new Stopwatch();
            sw.Start();

            context.Response.OnStarting(async (state) => {

                if (state is HttpResponse response)
                {
                    response.Headers.Add("Elapsed",$"{sw.ElapsedMilliseconds} ms");
                }
            },context.Response);

             await next(context);
        }
    }
    public static class StopWatchMiddlewareEntension
    {
        public static IApplicationBuilder UseStopwatch(this IApplicationBuilder app)
        {
            app.UseMiddleware<StopWatchMiddleware>();   
            return app;
        }
    }
}
