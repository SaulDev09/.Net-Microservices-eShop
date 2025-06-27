var builder = WebApplication.CreateBuilder(args);

#region [Services]
var assembly = typeof(Program).Assembly;
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    config.AddOpenBehavior(typeof(LogginBehavior<,>));
});

#endregion

var app = builder.Build();

#region [HTTP request Pipeline]
app.MapCarter();

#endregion

app.Run();
