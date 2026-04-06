using Microsoft.EntityFrameworkCore;
using eder_web_api.Infrastructure.Persistence;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<AppDbContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(FileOptions =>
    {
        FileOptions.SwaggerEndpoint("/openapi/v1.json","API v1");
    });
}

app.UseHttpsRedirection();

app.Run();

