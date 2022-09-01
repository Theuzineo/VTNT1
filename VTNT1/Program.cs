using Microsoft.EntityFrameworkCore;
using VTNT1.Infra.Data;
using VTNT1.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<Passagem_VTNT1Service, Passagem_VTNT1Service>();
builder.Services.AddScoped<Resumo_VTNT1Service, Resumo_VTNT1Service>();


//builder.Services.AddDbContext<BackEnd_Challenge_Alura.Data.AppDbContext>(opt => opt.UseSqlServer(
//    builder.Configuration.GetConnectionString("DefaultConnection")));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();   
    app.UseSwaggerUI();
}

//app.UseCors(option =>
//{
//    option.WithOrigins("http://localhost:7057c");
//    option.AllowAnyMethod();
//    option.AllowAnyHeader();
//});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();

// 