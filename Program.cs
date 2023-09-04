using Microsoft.EntityFrameworkCore;
using TrainTicketsWebsite.Data;
using TrainTicketsWebsite.Models;
using TrainTicketsWebsite.Service.CabinService;
using TrainTicketsWebsite.Service.CarriageService;
using TrainTicketsWebsite.Service.SeatService;
using TrainTicketsWebsite.Service.StationService;
using TrainTicketsWebsite.Service.TrainService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>();

//Services
builder.Services.AddScoped<ITrainService, TrainService>(); 
builder.Services.AddScoped<ICarriageService, CarriageService>();
builder.Services.AddScoped<IStationService, StationService>();
builder.Services.AddScoped<ICabinService, CabinService>();
builder.Services.AddScoped<ISeatService, SeatService>();

builder.Services.AddCors(p => p.AddPolicy("cors", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("cors");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<DataContext>();
var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

try
{
    context.Database.Migrate();
    DbInitializer.Initialize(context);
}
catch (Exception e)
{
    logger.LogError(e, "An error occurred while migrating or initializing the database.");
}

app.Run();