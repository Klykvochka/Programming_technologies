using Microsoft.EntityFrameworkCore;
using SaleOfAirTickets.Infrastructure.EntityFramework;

var builder = WebApplication.CreateBuilder(args); 
var configuration = builder.Configuration; 

builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(
    options =>
    {
        options.UseNpgsql(configuration.GetConnectionString(nameof(ApplicationDbContext)));
    });
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


