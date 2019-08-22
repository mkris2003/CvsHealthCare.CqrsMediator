using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using CvsHealthCare.CqrsMediator.Application.Databases;
using CvsHealthCare.CqrsMediator.Application.Employees.Commands.CreateEmployee;
using CvsHealthCare.CqrsMediator.Application.Infrastructure;
using CvsHealthCare.CqrsMediator.Application.Infrastructure.AutoMapper;
using CvsHealthCare.CqrsMediator.Application.Interfaces;
using CvsHealthCare.CqrsMediator.Common;
using CvsHealthCare.CqrsMediator.Infrastructure;
using CvsHealthCare.CqrsMediator.WebApi.Filters;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CvsHealthCare.CqrsMediator.WebApi
{
    public class Startup
    {
        public IConfigurationRoot Configuration
        {
            get;
            set;
        }
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
           // Log.Logger = new LoggerConfiguration()
                               // .ReadFrom.Configuration(Configuration)
                               // .CreateLogger();
        }

       

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
               .AddMvc(options => options.Filters.Add(typeof(CustomExceptionFilterAttribute)))
               .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            //Add connectionstring
            services.AddSingleton<IDbConnectionFactory>(new SqlConnectionFactory(Configuration));
            // Add AutoMapper
            services.AddAutoMapper(new Assembly[] { typeof(AutoMapperProfile).GetTypeInfo().Assembly });

            // Add framework services.
            services.AddTransient<INotificationService, NotificationService>();
            services.AddTransient<IDateTime, MachineDateTime>();

            // Add MediatR
            services.AddMediatR(typeof(CreateEmployeeCommand).GetTypeInfo().Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
