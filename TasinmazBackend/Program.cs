using Microsoft.EntityFrameworkCore;
using TasinmazBackend.Data;
using TasinmazBackend.Interfaces;
using TasinmazBackend.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<TasinmazDbContext>(options =>
    options.UseSqlServer("Server=.;Database=TasinmazDB;Trusted_Connection=True;"));


builder.Services.AddScoped<ITasinmazService, TasinmazService>();

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
