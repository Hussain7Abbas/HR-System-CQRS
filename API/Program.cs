using Scalar.AspNetCore;
using Application;
using Infrastructure;
using Domain.Accounts;
using Microsoft.AspNetCore.Identity;
using Application.Accounts.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using API.Transformers;

var builder = WebApplication.CreateBuilder(args);

// === Add services ===
// Add controllers
builder.Services.AddControllers();
// Add MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AssemblyReference).Assembly));
// Add infrastructure (DbContext + Repositories)
builder.Services.AddInfrastructure(builder.Configuration);
// Add JwtTokenGenerator service
builder.Services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
// Add PasswordHasher service
builder.Services.AddScoped<IPasswordHasher<Account>, PasswordHasher<Account>>();

// JWT Authentication
var jwtSettings = builder.Configuration.GetSection("Jwt");
var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]!);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings["Issuer"],
            ValidAudience = jwtSettings["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };
    });

// === OpenAPI ===
builder.Services.AddOpenApi("v1", options =>
{
    options.AddDocumentTransformer<BearerSecuritySchemeTransformer>();
});

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
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
