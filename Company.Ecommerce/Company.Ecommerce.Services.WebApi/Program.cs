using AutoMapper;
using Company.Ecommerce.Transversal.Mapper;
using Company.Ecommerce.Transversal.Common;
using Company.Ecommerce.Infrastructure.Data;
using Company.Ecommerce.Infrastructure.Repository;
using Company.Ecommerce.Infrastructure.Interface;
using Company.Ecommerce.Domain.Interface;
using Company.Ecommerce.Domain.Core;
using Company.Ecommerce.Application.Interface;
using Company.Ecommerce.Application.Main;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAutoMapper(x => 
    x.AddProfile(new MappingsProfile()));

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver();
    });

// Access the IConfiguration instance
var configuration = builder.Configuration;
builder.Services.AddSingleton<IConfiguration>(configuration);
builder.Services.AddSingleton<IConnectionFactory, ConnectionFactory>();
builder.Services.AddScoped<ICustomerApplication, CustomersApplication>();
builder.Services.AddScoped<ICustomersDomain, CustomersDomain>();
builder.Services.AddScoped<ICustomersRepository, CustomersRepository>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
