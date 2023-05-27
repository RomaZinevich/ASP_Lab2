namespace AspDotNetLab2
{
    public class RandomMiddleware
    {
        RequestDelegate next;

        public RandomMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context, RandomService random)
        {
            if (context.Request.Path == "/services/random")
            {
                await context.Response.WriteAsJsonAsync(random.GetRandom());
            }
            else
            {
                await next.Invoke(context);
            }
        }
    }
}
