using Microsoft.EntityFrameworkCore;
using TasinmazBackend.Data;
using TasinmazBackend.Interfaces;
using TasinmazBackend.Services;
using AutoMapper;
using TasinmazBackend.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Database
builder.Services.AddDbContext<TasinmazDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Services
builder.Services.AddScoped<ITasinmazService, TasinmazService>();

// AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
