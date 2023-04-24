using API.Config;
using Agency.Entities.Interfaces;
using Agency.Data.Services;
using APIResfault.Application.Services;
using Agency.Bussiness.Services;
using Agency.Entities.Models.Request;
using FluentValidation;
using Agency.Bussiness.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddScoped<IFlight, FligthsServices>();
builder.Services.AddScoped<IConfig, Config>();
builder.Services.AddScoped<IFlightFiltered, FilterFlightServices>();
builder.Services.AddScoped<ITotalCalculator, PriceCalculatorService>();
builder.Services.AddScoped<IBuildJson, BuildJsonService>();
builder.Services.AddTransient<IValidator<RequestJourney>, JourneyValidator>();

//politica cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("PolicyCors", app => 
    {
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("PolicyCors");

app.UseAuthorization();

app.MapControllers();

app.Run();
