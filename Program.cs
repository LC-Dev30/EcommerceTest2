using EcommerceTest2.Data;
using EcommerceTest2.Repositorios.Clientes;
using EcommerceTest2.Repositorios.Facturaciones;
using EcommerceTest2.Repositorios.Ordenes;
using EcommerceTest2.Servicios.Clientes;
using EcommerceTest2.Servicios.Facturaciones;
using EcommerceTest2.Servicios.Ordenes;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<EcommercePracticeContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("Conexion"));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});


builder.Services.AddScoped<IServicioCliente, ClienteServicio>();
builder.Services.AddScoped<IClientesRepositorio,ClientesRepositorio>();

builder.Services.AddScoped<IOrdenRepositorio, OrdenRepositorio>();
builder.Services.AddScoped<IServicioOrden, OrdenServicio>();

builder.Services.AddScoped<IFacturacionRepositorio, FacturacionRepositorio>();
builder.Services.AddScoped<IServicioFacturacion, FacturacionServicio>();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler =
            ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors("AllowAll");

app.MapControllers();

app.Run();
