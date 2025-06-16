using barbershop.Context;
using barbershop.Interface;
using barbershop.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
// for the UseMySQL() extension:

var builder = WebApplication.CreateBuilder(args);

// 1) Configure EF Core to use Oracle's MySQL provider
builder.Services.AddDbContext<PeluqueriaContext>(options =>
    options.UseMySQL(
        builder.Configuration.GetConnectionString("PeluqueriaDb")
    )
    // you could pass Provider‐specific options here via the second parameter if needed
);  // ── UseMySQL lives in MySQL.EntityFrameworkCore.Extensions :contentReference[oaicite:0]{index=0}

// 2) Register your Personas service
builder.Services.AddScoped<IControladorPersona, PeluqueriaServicePersona>();
builder.Services.AddScoped<IControladorFile, PeluqueriaServiceFile>();
builder.Services.AddScoped<IControladorProducto, PeluqueriaServiceProducto>();
builder.Services.AddScoped<IControladorServicio, PeluqueriaServiceServicio>();
builder.Services.AddScoped<IControladorTicket, PeluqueriaServiceTicket>();
builder.Services.AddScoped<IControladorUsuario, PeluqueriaServiceUsuario>();

// 3) Add controllers + Swagger
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
        c.RoutePrefix = "";
    });
}

// 4) Middleware & routing
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();
