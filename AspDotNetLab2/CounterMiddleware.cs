namespace AspDotNetLab2
{
    public class CounterMiddleware
    {
        RequestDelegate next;

        public CounterMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context, GeneralCounterService countService)
        {
            countService.IncrementValue(context.Request.Path);
            await next.Invoke(context);
        }
    }
}
