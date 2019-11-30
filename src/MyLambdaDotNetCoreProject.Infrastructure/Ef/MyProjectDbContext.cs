using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using MyLambdaDotNetCoreProject.Domain.Aggregates.Entity1Aggregate;
using MyLambdaDotNetCoreProject.Infrastructure.Ef.Configurations;

namespace MyLambdaDotNetCoreProject.Infrastructure.Ef
{
    public class MyProjectDbContext : DbContext
    {
        public MyProjectDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Entity1> Entity1s { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Entity1Configuration());
        }

        public class MysqlDbContextDbContextFactory : IDesignTimeDbContextFactory<MyProjectDbContext>
        {
            public MyProjectDbContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<MyProjectDbContext>();

                var configuration = new ConfigurationBuilder()
                                .AddJsonFile($"appsettings.Local.json")
                                //.AddJsonFile($"appsettings.Production.json")
                                .Build();

                optionsBuilder
                    /*
                     * mySql specific. 
                     * needed package: Pomelo.EntityFrameworkCore.MySql
                     */
                    .UseMySql(configuration.GetConnectionString("MysqlConnectionString"))
                    /*
                     * postgreSQL specific. 
                     * needed package: Npgsql.EntityFrameworkCore.PostgreSQL
                     */
                    //.UseNpgsql(configuration.GetConnectionString("PostgreSqlConnectionString"))
                    ;

                return new MyProjectDbContext(optionsBuilder.Options);
            }
        }
    }
}