using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Reflection;
using System.Linq;
using MyLambdaDotNetCoreProject.Domain.Aggregates.Entity1Aggregate;
using MyLambdaDotNetCoreProject.Infrastructure.Repositories;
using MyLambdaDotNetCoreProject.Application.Commands;
using System;
using MyLambdaDotNetCoreProject.Api.Infrastructure;

namespace MyLambdaDotNetCoreProject.Api
{
    class Startup
    {
        public static IServiceProvider BuildServiceProvider()
        {
            //template parameter used
            var environmentName = System.Environment.GetEnvironmentVariable("environmentName");

            if(environmentName is null)
            {
                throw new InvalidOperationException($"{nameof(environmentName)} not set");
            }

            var configuration = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddEnvironmentVariables()
                                .AddJsonFile($"appsettings.{environmentName}.json")
                                .Build();

            var serviceCollection = new ServiceCollection()
                                    .AddModules(configuration)
                                    .AddDbContexts(configuration)
                                    .AddServices()
                                    ;
            
            return serviceCollection.BuildServiceProvider();
        }
    }
}
