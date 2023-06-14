
using HueFestival.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using HueFestival.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
var settings = builder.Configuration.GetRequiredSection("ConnectionStrings"); //read data from appsettings.json
builder.Services.AddDbContext<HueFestivalContext>(options =>options.UseSqlServer(settings["DefaultConnection"]));
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<IAboutRepository, AboutRepository>();
builder.Services.AddScoped<INewsRepository, NewsRepository>();

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

