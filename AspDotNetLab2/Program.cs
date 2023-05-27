using AspDotNetLab2;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<TimerService>();
builder.Services.AddScoped<RandomService>();
builder.Services.AddSingleton<GeneralCounterService>();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/services/list", async (context) =>
{
    var services = builder.Services;
    context.Response.ContentType = "text/html;charset=utf-8";
    await context.Response.WriteAsync(Info.PrintHtml(services));
});

app.MapGet("/services/timer", async (context) =>
{
    var timeService = app.Services.GetService<TimerService>();
    context.Response.ContentType = "text/html;charset=utf-8";
    await context.Response.WriteAsync($"{timeService.Time()}");
});

app.MapGet("/services/random", async (context) =>
{
    using (var scope = app.Services.CreateScope())
    {
        var randomSer = scope.ServiceProvider.GetRequiredService<RandomService>();
        context.Response.ContentType = "text/html;charset=utf-8";
        await context.Response.WriteAsync($"{randomSer.GetRandom()}");
    }
});

app.MapGet("/services/general-counter", async (context) =>
{
    var counter = app.Services.GetService<GeneralCounterService>();
    context.Response.ContentType = "text/html;charset=utf-8";
    await context.Response.WriteAsync($"{counter.GetHtml()}");
});

app.UseMiddleware<CounterMiddleware>();
app.UseMiddleware<TimerMiddleware>();
app.UseMiddleware<RandomMiddleware>();

app.Run();
