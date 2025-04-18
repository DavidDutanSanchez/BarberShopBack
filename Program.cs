using barbershop.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
//using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
//using Swashbuckle.AspNetCore.Builder;    // for AddSwaggerGen, UseSwaggerUI

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PeluqueriaContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("PeluqueriaDb"),
        new MySqlServerVersion(new Version(8, 0, 33))
    )
);

// --- add controllers/endpoints if you haven’t already ---
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Peluqueria API",
        Version = "v1",
        Description = "API for the peluqueria_pintado schema"
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Peluqueria API V1");
        c.RoutePrefix = "";     // if you want Swagger at the app root
    });
}

// --- your routing/middleware ---
app.UseRouting();
app.UseAuthorization();
app.MapControllers();            // for [ApiController] controllers

app.Run();
