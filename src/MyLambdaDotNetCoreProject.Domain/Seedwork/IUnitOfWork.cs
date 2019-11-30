using System;
using System.Threading;
using System.Threading.Tasks;

namespace MyLambdaDotNetCoreProject.Domain.Seedwork
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default);
    }
}
