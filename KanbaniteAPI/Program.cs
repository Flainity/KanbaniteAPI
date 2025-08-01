using FastEndpoints;
using KanbaniteAPI.Data;
using KanbaniteAPI.Extension;
using KanbaniteAPI.Repository;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddKanbaniteServices();

builder.Services.AddAuthorization();

builder.Services.AddFastEndpoints();
builder.Services.AddOpenApi();
builder.Services.AddCors();

builder.Services.AddDbContext<KanbaniteDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("KanbaniteDb");

    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseCors(policy => policy.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod());

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseFastEndpoints();

app.Run();