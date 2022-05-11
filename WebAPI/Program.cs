using Application;
using Persistence;
using WebAPI.Extensions;
using Shared;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplicationLayer();
builder.Services.AddPersistenceInfra(configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApiVersioningExtension();
builder.Services.AddSharedInfra();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "WebAPI-Onion", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseErrorHandlingMiddleware();

app.MapControllers();

app.Run();
