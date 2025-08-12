using Scalar.AspNetCore;
using Application;
using Infrastructure;
using Domain.Accounts;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AssemblyReference).Assembly));

// Add infrastructure (DbContext + Repositories)
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddScoped<IPasswordHasher<Account>, PasswordHasher<Account>>();

// === OpenAPI ===
builder.Services.AddOpenApi("v1");

var app = builder.Build();

// === Scalar UI ===
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options.Title = "HR System API";
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
