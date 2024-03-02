using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using N5Challenge.Data;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Serilog;
using N5Challenge.Interfaces;
using Nest;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<IPermissionsRepository, PermissionsRepository>();

//
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

var dbHost = builder.Configuration["database:DB_HOST"];
var dbName = builder.Configuration["database:DB_NAME"];
var dbPassword = builder.Configuration["database:DB_SA_PASSWORD"];
var connectionString = $"Data Source={dbHost}; Initial Catalog={dbName}; User ID=sa;Password={dbPassword};Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";
// Data Source=localhost;Initial Catalog=N5_Database;User ID=sa;Password=********;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Add services to the container.

// Elasticsearch configuration
var url = builder.Configuration["elasticsearch:url"];
var defaultIndex = builder.Configuration["elasticsearch:index"];

var settings = new ConnectionSettings(new Uri(url)).DefaultIndex(defaultIndex);

var client = new ElasticClient(settings);

builder.Services.AddSingleton<IElasticClient>(client);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Configure serilog
builder.Host.UseSerilog((hostingContext, loggerConfiguration) =>
{
    loggerConfiguration
        .ReadFrom.Configuration(hostingContext.Configuration)
        .Enrich.FromLogContext()
        .WriteTo.Console()
        .WriteTo.File("logs.txt", rollingInterval: RollingInterval.Day);
});


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

