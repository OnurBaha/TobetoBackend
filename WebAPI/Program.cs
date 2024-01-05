using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Business;
using Business.Abstracts;
using Business.Concretes;
using Business.DependencyResolvers.Autofac;
using Castle.Core.Configuration;
using Core.CrossCuttingConcerns.Exceptions.Extensions;
using Core.Utilities.JWT;
using DataAccess;
using DataAccess.Context;
using DataAccess.DependencyResolvers.Autofac;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Reflection;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Serilog.Core;
using Core.Aspects.ActionFilters;
using Castle.Core.Logging;






var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDataAccessServices(builder.Configuration);
builder.Services.AddBusinessServices();


builder.Services.AddScoped<Serilog.ILogger>(provider => new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("myapp.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger());


builder.Services.AddScoped<LogActionFilter>();

// LogActionFilter'� ekleyin



var config = builder.Configuration;
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
builder.Logging.ClearProviders();
// Uncomment the Autofac-related code
//builder.Host
//    .UseServiceProviderFactory(new AutofacServiceProviderFactory())
//    .ConfigureContainer<ContainerBuilder>(builder =>
//    {
//        builder.RegisterInstance(config).As<Microsoft.Extensions.Configuration.IConfiguration>();
//        builder.Register<DbContextOptions<TobetoContext>>(c =>
//        {
//            var dbContextOptionsBuilder = new DbContextOptionsBuilder<TobetoContext>();
//            dbContextOptionsBuilder.UseSqlServer(c.Resolve<Microsoft.Extensions.Configuration.IConfiguration>().GetConnectionString("Tobeto"));
//            return dbContextOptionsBuilder.Options;
//        }).InstancePerLifetimeScope();

//        builder.RegisterModule(new AutofacDataAccessModule(config));
//        builder.RegisterModule(new AutofacBusinessModule(config));
//    });
builder.Services.AddScoped<LogActionFilter>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.ConfigureCustomExceptionMiddleware();
app.UseJwtDecoderMiddleware();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
