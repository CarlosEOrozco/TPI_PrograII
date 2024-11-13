using Microsoft.AspNetCore.Hosting.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebApiFcturacionTPI.Models;
using WebApiFcturacionTPI.Repositories;
using WebApiFcturacionTPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext < facturacionContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IArticuloRepository, ArticuloRepository>();
builder.Services.AddScoped<IarticuloService,ArticuloManager>();
builder.Services.AddScoped<IFacturasRepository,FacturaRepository>();
builder.Services.AddScoped<IUnitofwork,UnitOfWork>();
builder.Services.AddScoped<FacturaService>();
builder.Services.AddScoped<IDetalleRepository, DetalleRepository>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("http://127.0.0.1:5500")
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Usar CORS
app.UseCors("AllowSpecificOrigin");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
