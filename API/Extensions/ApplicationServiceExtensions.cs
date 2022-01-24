using System;
using App.Applications;
using App.Interface;
using App.Repository;
using Application.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Persistence;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
        IConfiguration config)
        {
            //!ativa o uso do contexto da aplicação. (SQL Server)
            var query = config.GetConnectionString("MSSQLConnection");

            services.AddDbContext<DataContext>(
               opt => opt.UseSqlServer(
                   config.GetConnectionString("MSSQLConnection")
               )
           );

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });

            services.AddCors(opt =>
            {
                opt.AddPolicy(name: "CorsPolicy", policy =>
                {
                    policy.AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithOrigins("http://localhost:3000");
                });
            });

            services.ConfigureMediatR();
            services.AddScoped<IAppmanagerRepository, AppmanagerRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddAutoMapper(typeof(MappingProfiles).Assembly);

            return services;
        }
    }
}