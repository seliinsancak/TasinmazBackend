using Microsoft.EntityFrameworkCore;
using TasinmazBackend.Data;
using TasinmazBackend.Interfaces;
using TasinmazBackend.Services;
using AutoMapper;
using TasinmazBackend.Mappings;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<TasinmazDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));


builder.Services.AddScoped<ITasinmazService, TasinmazService>();


builder.Services.AddAutoMapper(typeof(MappingProfile));


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
    {
        policy.WithOrigins("https://localhost:4200") 
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tasinmaz API V1");
    c.RoutePrefix = "swagger";  // https://localhost:7196/swagger
});


app.UseHttpsRedirection();


app.UseCors("AllowAngular");

app.UseAuthorization();

app.MapControllers();

app.Run();
