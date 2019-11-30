using MediatR;
using MyLambdaDotNetCoreProject.Domain.Seedwork;
using MyLambdaDotNetCoreProject.Infrastructure.Ef;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MyLambdaDotNetCoreProject.Infrastructure.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly IMediator _mediator;
        readonly MyProjectDbContext _dbContext;

        public UnitOfWork(IMediator mediator, MyProjectDbContext dbContext)
        {
            _mediator = mediator;
            _dbContext = dbContext;
        }

        /// <summary>
        /// more discussions:
        /// <see: href="https://github.com/dotnet-architecture/eShopOnContainers/issues/721">
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        async Task<bool> IUnitOfWork.SaveEntitiesAsync(CancellationToken cancellationToken)
        {
            await _mediator.DispatchDomainEventsAsync(_dbContext);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        void IDisposable.Dispose() => this._dbContext.Dispose();
    }
}
