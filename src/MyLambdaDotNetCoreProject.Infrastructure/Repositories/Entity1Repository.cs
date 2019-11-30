using Microsoft.EntityFrameworkCore;
using MyLambdaDotNetCoreProject.Domain.Aggregates.Entity1Aggregate;
using MyLambdaDotNetCoreProject.Domain.Seedwork;
using MyLambdaDotNetCoreProject.Infrastructure.Ef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLambdaDotNetCoreProject.Infrastructure.Repositories
{
    public class Entity1Repository : IEntity1Repository
    {
        readonly MyProjectDbContext _dbContext;

        public Entity1Repository(MyProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        void IEntity1Repository.Add(Entity1 item) 
            
            => this._dbContext.Entity1s.Add(item);

        void IEntity1Repository.Update(Entity1 item) 
            
            => this._dbContext.Entity1s.Update(item);

        void IEntity1Repository.Remove(Entity1 item)

            => this._dbContext.Entity1s.Remove(item);

        async Task<IEnumerable<Entity1>> IEntity1Repository.GetAllAsync()

            => await this._dbContext.Entity1s.ToListAsync();

        async Task<Entity1> IEntity1Repository.GetAsync(string id) 
            
            => await this._dbContext.Entity1s.SingleOrDefaultAsync(o => o.Id == id);
    }
}
