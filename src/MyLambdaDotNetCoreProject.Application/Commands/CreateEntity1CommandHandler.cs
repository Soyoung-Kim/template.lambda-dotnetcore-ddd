using MediatR;
using MyLambdaDotNetCoreProject.Domain.Aggregates.Entity1Aggregate;
using MyLambdaDotNetCoreProject.Domain.Seedwork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyLambdaDotNetCoreProject.Application.Commands
{
    public class CreateEntity1CommandHandler : IRequestHandler<CreateEntity1Command, string>
    {
        readonly IEntity1Repository _entity1Repository;
        readonly IUnitOfWork _unitOfWork;

        public CreateEntity1CommandHandler(IEntity1Repository entity1Repository, IUnitOfWork unitOfWork)
        {
            _entity1Repository = entity1Repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(CreateEntity1Command request, CancellationToken cancellationToken)
        {
            var @new = new Entity1(request.Name);

            this._entity1Repository.Add(@new);

            await this._unitOfWork.SaveEntitiesAsync();

            return @new.Id;
        }
    }
}
