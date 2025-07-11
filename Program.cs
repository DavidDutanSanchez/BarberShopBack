using barbershop.Context;
using barbershop.Interface;
using barbershop.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// 1) Configure EF Core to use MySQL provider
var connectionString = builder.Configuration.GetConnectionString("PeluqueriaDb");
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Connection string 'PeluqueriaDb' not found.");
}
builder.Services.AddDbContext<PeluqueriaContext>(options =>
    options.UseMySQL(connectionString)
);

// 2) Register your services
builder.Services.AddScoped<IControladorPersona, PeluqueriaServicePersona>();
builder.Services.AddScoped<IControladorFile, PeluqueriaServiceFile>();
builder.Services.AddScoped<IControladorProducto, PeluqueriaServiceProducto>();
builder.Services.AddScoped<IControladorServicio, PeluqueriaServiceServicio>();
builder.Services.AddScoped<IControladorTicket, PeluqueriaServiceTicket>();
builder.Services.AddScoped<IControladorUsuario, PeluqueriaServiceUsuario>();
builder.Services.AddScoped<IControladorReporte, PeluqueriaServiceReporte>();


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

    // Adding JWT Bearer Token support for Swagger
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Enter JWT Bearer token",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { new OpenApiSecurityScheme { Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" } }, new string[] { } }
    });
});

// 4) CORS configuration (Allow requests from specific origins only)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", policy =>
    {
         policy.WithOrigins("https://yourfrontenddomain.com", "http://localhost:5151")
        // policy.WithOrigins("http://181.113.129.250:22600")
        //       .AllowAnyHeader()
        //       .AllowAnyMethod()
        //       .AllowCredentials();

       // policy.AllowAnyOrigin()
          .AllowAnyHeader()
          .AllowAnyMethod();

    });
});

// builder.Services.AddControllers().AddJsonOptions(options =>
// {
//     options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
//     options.JsonSerializerOptions.WriteIndented = true;
// });


// 5) JWT Authentication configuration
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = true;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["AppSettings:JwtSecret"])),
        };
    });

// 6) HTTPS Redirection
builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.KnownNetworks.Clear();
    options.KnownProxies.Clear();
});

// Enforce HTTPS
builder.Services.AddHttpsRedirection(options =>
{
    // options.HttpsPort = 5151; 
});

// Build the app
var app = builder.Build();

// Enable Swagger in Development and add Authentication Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Peluqueria API V1");
        c.RoutePrefix = ""; // Makes Swagger UI available at the root
    });
}

// 7) Middleware & Routing
app.UseRouting();

// Enable CORS policy
app.UseCors("AllowSpecificOrigin");

// Use Authentication and Authorization Middleware
app.UseAuthentication();
app.UseAuthorization();

// Enforce HTTPS
// app.UseHttpsRedirection();
// Use Forwarded Headers Middleware (Important for proxy setup)
app.UseForwardedHeaders();

// Map controllers
app.MapControllers();

app.Urls.Add("http://localhost:5151/");
//app.Urls.Add("http://0.0.0.0:22600");

app.Run();
