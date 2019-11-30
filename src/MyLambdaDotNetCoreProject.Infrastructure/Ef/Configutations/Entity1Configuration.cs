using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyLambdaDotNetCoreProject.Domain.Aggregates.Entity1Aggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyLambdaDotNetCoreProject.Infrastructure.Ef.Configurations
{
    public class Entity1Configuration : IEntityTypeConfiguration<Entity1>
    {
        public void Configure(EntityTypeBuilder<Entity1> builder)
        {
            builder.ToTable(nameof(Entity1));

            builder.HasKey(o => o.Id);
            builder.Ignore(o => o.DomainEvents);
        }
    }
}
