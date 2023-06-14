using API_Multimedios.Data;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<Contexto>();

//Se agrega la configuracion del string de conexion
// Obtener la cadena de conexión de la configuración
string connectionString = builder.Configuration.GetConnectionString("StringConexion");

// Crear una instancia de ServerVersion con la versión adecuada de MySQL
var serverVersion = new MySqlServerVersion(new Version(8, 0, 26));

// Configurar la conexión a la base de datos MySQL
builder.Services.AddDbContext<Contexto>(options =>
    options.UseMySql(connectionString, serverVersion));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
