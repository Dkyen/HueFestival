
using HueFestival.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using HueFestival.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using System.Text;
using HueFestival.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using HueFestival.Filters;
using Microsoft.AspNetCore.Mvc;
using HueFestival.Helper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Microsoft.Extensions.DependencyModel;
using HueFestival.IRepositories;
using HueFestival_OnlineTicket.Core.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey
    (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true
    };
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Northwind CRUD",
        Version = "v1"
    });

    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });

    option.OperationFilter<AuthResponsesOperationFilter>();
});
builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
var settings = builder.Configuration.GetRequiredSection("ConnectionStrings"); //read data from appsettings.json
builder.Services.AddDbContext<HueFestivalContext>(options =>options.UseSqlServer(settings["DefaultConnection"]));

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<IAboutRepository, AboutRepository>();
builder.Services.AddScoped<INewsRepository, NewsRepository>();
builder.Services.AddScoped<IProgramRepository, ProgramRepository>();
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IEventCategoryRepository, EventCategoryRepository>();
builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<ILocationCategoryRepository, LocationCategoryRepository>();
builder.Services.AddScoped<ITypeTicketRepository, TypeTicketRepository>();
builder.Services.AddScoped<ITicketLocationRepository, TicketLocationRepository>();
builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddScoped<ICheckInRepository, CheckInRepository>();
builder.Services.AddTransient<AuthRepository>();
builder.Services.AddAuthorization();

var serviceProvider = builder.Services.BuildServiceProvider();
var logger = serviceProvider.GetRequiredService<ILogger<ControllerBase>>();
builder.Services.AddSingleton(typeof(ILogger), logger);
var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new ApplicationMapper());
});

var mapper = config.CreateMapper();

builder.Services.AddSingleton(mapper);
//Add CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            //you can configure your custom policy
            builder.AllowAnyOrigin()
                                .AllowAnyHeader()
                                .AllowAnyMethod();
        });
});

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
}

app.MapControllers();

app.Run();

