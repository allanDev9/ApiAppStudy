using ApiAppStudy.Data;
using ApiAppStudy.Repositories;
using ApiAppStudy.Repositories.Interfaces;
using ApiAppStudy.Services;
using ApiAppStudy.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// --- Configurar servicios ---

// Registrar DbContext en el contenedor de inyección de dependencias

// Obtener la cadena de conexión desde appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Registrar Repository y Service en el contenedor de inyección de dependencias
builder.Services.AddScoped<IActivityRepository, ActivityRepository>();
builder.Services.AddScoped<IActivityService, ActivityService>();

// Agregar Controllers|
builder.Services.AddControllers();

// OpenAPI / Swagger
builder.Services.AddOpenApi();

var app = builder.Build();

// Validar conexión a MySQL
try
{
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.CanConnect();
    Console.WriteLine("Conectado a MySQL exitosamente");
}
catch (Exception ex)
{
    Console.WriteLine($"Error al conectar a MySQL: {ex.Message}");
}

// --- Configurar middleware ---

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// Mapear los controllers a las rutas
app.MapControllers();

app.Run();
