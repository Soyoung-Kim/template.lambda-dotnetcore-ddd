using MyLambdaDotNetCoreProject.Application.Queries.Readmodel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyLambdaDotNetCoreProject.Application.Queries
{
    public interface IEntity1Query: IQuery
    {
        Task<IEnumerable<Entity1View>> GetAllAsync();
        Task<Entity1View> GetAsync(string id);
    }
}
