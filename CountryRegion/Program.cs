using BPAAdminPortal.Repository.Repository.UnitOfWork;
using CountryRegion.Domain.IRepository;
using CountryRegion.Domain.IServices;
using CountryRegion.Repository;
using CountryRegion.Service;
using Entitytest.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
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
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});
builder.Services.AddScoped<ICountryService,CountryService>();
builder.Services.AddScoped<ISRRepository, Repository>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = string.Empty; // To serve the Swagger UI at the app's root (http://localhost:<port>/)
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
