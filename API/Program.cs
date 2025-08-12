using Application;

var builder = WebApplication.CreateBuilder(args);

// Add controllers and API services
builder.Services.AddControllers();

// Register MediatR
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblies(typeof(AssemblyReference).Assembly));

var app = builder.Build();
app.MapControllers();
app.Run();
