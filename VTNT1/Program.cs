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

builder.Services.AddScoped<RouteVTNT1Service, RouteVTNT1Service>();
builder.Services.AddScoped<SumVTNT1Service, SumVTNT1Service>();


var app = builder.Build();

//Configure the HTTP request pipeline.
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