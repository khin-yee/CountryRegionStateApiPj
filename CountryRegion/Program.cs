using BPAAdminPortal.Repository.Repository.UnitOfWork;
using CountryRegion.Domain.IRepository;
using CountryRegion.Domain.IServices;
using CountryRegion.Repository;
using CountryRegion.Service;
using Entitytest.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Enrichers;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

builder.Host.UseSerilog();
Log.Logger = new LoggerConfiguration()
    .Enrich.With(new ThreadIdEnricher())
    .ReadFrom.Configuration(configuration)
    .WriteTo.Console()
    .CreateLogger();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DatabaseConnect>(options => {
    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<ICountryService,CountryService>();
builder.Services.AddScoped<ISRRepository, Repository>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
