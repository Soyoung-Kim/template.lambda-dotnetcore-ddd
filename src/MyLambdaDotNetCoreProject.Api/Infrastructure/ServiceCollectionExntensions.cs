using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyLambdaDotNetCoreProject.Application.Commands;
using MyLambdaDotNetCoreProject.Application.Queries;
using MyLambdaDotNetCoreProject.Domain.Aggregates.Entity1Aggregate;
using MyLambdaDotNetCoreProject.Domain.Seedwork;
using MyLambdaDotNetCoreProject.Infrastructure.Ef;
using MyLambdaDotNetCoreProject.Infrastructure.Queries;
using MyLambdaDotNetCoreProject.Infrastructure.Repositories;
using MyLambdaDotNetCoreProject.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MyLambdaDotNetCoreProject.Api.Infrastructure
{
    public static class ServiceCollectionExntensions
    {
        readonly static Assembly apiAssembly = typeof(Startup).Assembly;
        readonly static Assembly applicationAssembly = typeof(CreateEntity1CommandHandler).Assembly;
        readonly static Assembly domainAssembly = typeof(Entity1).Assembly;
        readonly static Assembly infrastructureAssembly = typeof(Entity1Repository).Assembly;

        /// <summary>
        /// application level injected modules
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configurationRoot"></param>
        /// <returns></returns>
        public static IServiceCollection AddModules(this IServiceCollection services, IConfigurationRoot configuration)

            => services
                .AddMediatR(applicationAssembly)
                .AddAutoMapper(apiAssembly)
                ;

        /// <summary>
        /// dbcontexts
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configurationRoot"></param>
        /// <returns></returns>
        public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfigurationRoot configuration)

            => services
                //Postgres
                //.AddDbContext<PostgreSqlDbContext>(
                //    options => options.UseNpgsql(configuration.GetConnectionString("PostgreSqlConnectionString"))
                //)
                //Mysql
                .AddDbContext<MyProjectDbContext>(
                    options => options.UseMySql(configuration.GetConnectionString("MysqlConnectionString"))
                )
                ;

        /// <summary>
        /// domain aggregate repositories
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddServices(this IServiceCollection services)
        
            => services
                /*domain repositories*/
                .AddScoped<IEntity1Repository, Entity1Repository>()
                /*domain services*/
                .AddScoped<IUnitOfWork, UnitOfWork>()
                /*application queries*/
                .AddScoped<IEntity1Query, Entity1Query>();
    }
}
