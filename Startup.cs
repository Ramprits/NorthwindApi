using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WebApplicationNorthwind.Context;
using WebApplicationNorthwind.Entities;
using WebApplicationNorthwind.Model;
using WebApplicationNorthwind.Services;

namespace WebApplicationNorthwind
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration["connectionStrings:NorthDBConnectionString"];
            services.AddDbContext<NorthWindDbContext>(o => o.UseSqlServer(connectionString));
            services.AddMvc(opt => { opt.Filters.Add(new RequireHttpsAttribute()); }).AddJsonOptions(opt => { opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore; });
            services.AddCors(config =>
            {
                config.AddPolicy("MyApplication", builder => { builder.AllowAnyHeader().AllowAnyMethod().AllowAnyMethod(); });
                config.AddPolicy("AllowAny", builder => { builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin(); });
            });
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            Mapper.Initialize(config =>
            {
                config.CreateMap<Employee, EmployeeVm>().ReverseMap();
                config.CreateMap<CreateEmployee, Employee>().ReverseMap();

            });

            app.UseMvc();
        }
    }
}
