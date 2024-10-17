using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PropertySystemProject.CrossCuting.IoC;
using PropertySystemProject.Data.Context;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

Environment.SetEnvironmentVariable("DefaultConnection", builder.Configuration.GetConnectionString("DefaultConnection"));

ConfigureRepository.ConfigureDependenciesRepository(builder.Services);
ConfigureDataBase.AddDatabase(builder.Services);

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
