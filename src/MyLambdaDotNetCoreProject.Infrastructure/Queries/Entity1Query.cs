using AutoMapper;
using MyLambdaDotNetCoreProject.Application.Queries;
using MyLambdaDotNetCoreProject.Application.Queries.Readmodel;
using MyLambdaDotNetCoreProject.Domain.Aggregates.Entity1Aggregate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyLambdaDotNetCoreProject.Infrastructure.Queries
{
    public class Entity1Query : IEntity1Query
    {
        readonly IEntity1Repository _entity1Repository;
        readonly IMapper _mapper;

        public Entity1Query(IEntity1Repository entity1Repository,
                            IMapper mapper)
        {
            this._entity1Repository = entity1Repository;
            this._mapper = mapper;
        }

        async Task<IEnumerable<Entity1View>> IEntity1Query.GetAllAsync()
        {
            IEnumerable<Entity1> entities = await this._entity1Repository.GetAllAsync();

            return this._mapper.Map<IEnumerable<Entity1View>>(entities);
        }
            
            

        async Task<Entity1View> IEntity1Query.GetAsync(string id)
        {
            Entity1 entity = await this._entity1Repository.GetAsync(id);

            return this._mapper.Map<Entity1View>(entity);
        }
    }
}
