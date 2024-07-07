using AutoMapper;
using Company.Ecommerce.Transversal.Mapper;
using Company.Ecommerce.Transversal.Common;
using Company.Ecommerce.Transversal.Logging;
using Company.Ecommerce.Infrastructure.Data;
using Company.Ecommerce.Infrastructure.Repository;
using Company.Ecommerce.Infrastructure.Interface;
using Company.Ecommerce.Domain.Interface;
using Company.Ecommerce.Domain.Core;
using Company.Ecommerce.Application.Interface;
using Company.Ecommerce.Application.Main;
using Newtonsoft.Json.Serialization;
using Microsoft.OpenApi.Models;
using Company.Ecommerce.Services.WebApi.Helpers;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAutoMapper(x => 
    x.AddProfile(new MappingsProfile()));

builder.Services.AddCors(options =>
    options.AddPolicy("policyApiEcommerce", b =>
        b.WithOrigins(builder.Configuration["Config:OriginCors"])
                .AllowAnyHeader()
                .AllowAnyMethod()
                ));

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver();
    });

var appSettingsSection = builder.Configuration.GetSection("Config");
builder.Services.Configure<AppSettings>(appSettingsSection);

// configure JWT authentication
var appSettings = appSettingsSection.Get<AppSettings>();

// Access the IConfiguration instance
var configuration = builder.Configuration;
builder.Services.AddSingleton<IConfiguration>(configuration);
builder.Services.AddSingleton<IConnectionFactory, ConnectionFactory>();
builder.Services.AddScoped<ICustomerApplication, CustomersApplication>();
builder.Services.AddScoped<ICustomersDomain, CustomersDomain>();
builder.Services.AddScoped<ICustomersRepository, CustomersRepository>();
builder.Services.AddScoped<IUsersApplication, UsersApplication>();
builder.Services.AddScoped<IUsersDomain, UsersDomain>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
builder.Services.AddScoped<ILogRepository, LogRepository>();

var key = Encoding.ASCII.GetBytes(appSettings.Secret);
var  Issuer = appSettings.Issuer;
var Audience = appSettings.Audience;

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.Events = new JwtBearerEvents
        {
            OnTokenValidated = context =>
            {
                var userId = int.Parse(context.Principal.Identity.Name);
                return Task.CompletedTask;
            },
            OnAuthenticationFailed = context =>
            {
                if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                {
                    context.Response.Headers.Add("Token-Expired", "true");
                }
                return Task.CompletedTask;
            }
        };
        options.RequireHttpsMetadata = false;
        options.SaveToken = false;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = true,
            ValidIssuer = Issuer,
            ValidateAudience = true,
            ValidAudience = Audience,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero,
        };
    });



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//Register the swagger generator
builder.Services.AddSwaggerGen(s => 
{
    s.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Company Technology Services API Market",
        Description = "Simple example ASP .NET Core Web API",
        //TermsOfService = "None",
        Contact = new OpenApiContact
        {
            Name = "Send to email to Jorge Machado",
            Email = "machadoggg@gmail.com",
            //Url = "https://company.com"
        },
        License = new OpenApiLicense
        {
            Name = "Use License",
            //Url = "https://example.com/licence"
        }
    });

    s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Authorization by API key.",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT"
    });

    s.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });

});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseSwaggerUI(s =>
    {
        s.SwaggerEndpoint("swagger/v1/swagger.json", "My API Ecommerce V1");
    });
}

app.UseAuthentication();

app.UseAuthorization();


app.UseCors("policyApiEcommerce");

app.MapControllers();

app.Run();
