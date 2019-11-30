using MyLambdaDotNetCoreProject.Domain.Seedwork;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyLambdaDotNetCoreProject.Domain.Aggregates.Entity1Aggregate
{
    public class Entity1: Entity, IAggregateRoot
    {
        public Entity1(string name)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
        }
        public Entity1(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Name { get; private set; }
    }
}
