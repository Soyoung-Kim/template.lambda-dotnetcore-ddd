using MyLambdaDotNetCoreProject.Domain.Seedwork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyLambdaDotNetCoreProject.Domain.Aggregates.Entity1Aggregate
{
    public interface IEntity1Repository: IRepository<Entity1>
    {
        void Add(Entity1 item);
        void Update(Entity1 item);
        void Remove(Entity1 item);
        Task<IEnumerable<Entity1>> GetAllAsync();
        Task<Entity1> GetAsync(string id);
    }
}
