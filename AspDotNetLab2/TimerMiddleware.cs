namespace AspDotNetLab2
{
    public class TimerMiddleware
    {
        RequestDelegate next;

        public TimerMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context, TimerService timerService)
        {
            if (context.Request.Path == "/services/timer")
            {
                await context.Response.WriteAsJsonAsync(timerService.Time());
            }
            else
            {
                await next.Invoke(context);
            }
        }
    }
}
