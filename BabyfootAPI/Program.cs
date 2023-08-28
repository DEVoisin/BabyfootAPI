using BabyfootAPI.Context;
using BabyfootAPI.Models;
using BabyfootAPI.Services;
using BabyfootAPI.Services.Interfaces;
using BabyfootAPI.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers()
    .AddFluentValidation(o => ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("fr"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Services

builder.Services.AddTransient<IRankServices, RankServices>();
builder.Services.AddTransient<IPlayerServices, PlayerServices>();
builder.Services.AddTransient<ITeamServices, TeamServices>();
builder.Services.AddTransient<IPlayerGameServices, PlayerGameServices>();
builder.Services.AddTransient<ITeamGameServices, TeamGameServices>();
#endregion

#region Validator

builder.Services.AddScoped<IValidator<Rank>, RankValidator>();

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
