using Microsoft.EntityFrameworkCore;
using TasinmazBackend.Data;
using TasinmazBackend.Interfaces;
using TasinmazBackend.Services;
using AutoMapper;
using TasinmazBackend.Mappings;

var builder = WebApplication.CreateBuilder(args);

// DB Context
builder.Services.AddDbContext<TasinmazDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Service
builder.Services.AddScoped<ITasinmazService, TasinmazService>();

// AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Controllers ve Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Swagger Middleware (her ortamda açýk)
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tasinmaz API V1");
    c.RoutePrefix = "swagger"; // https://localhost:7196/swagger çalýþýr
});

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
