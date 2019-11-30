using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Serialization.Json;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using MyLambdaDotNetCoreProject.Application.Queries;
using MyLambdaDotNetCoreProject.Application.Queries.Readmodel;
using MyLambdaDotNetCoreProject.Api.Extensions;
using MyLambdaDotNetCoreProject.Application.Commands;

[assembly: LambdaSerializer(typeof(JsonSerializer))]
namespace MyLambdaDotNetCoreProject.Api
{
    public class Entity1Lambda
    {
        private readonly IEntity1Query _entity1Query;
        private readonly IMediator _mediator;

        /// <summary>
        /// Default constructor that Lambda will invoke.
        /// </summary>
        public Entity1Lambda() : this(Startup.BuildServiceProvider())
        {
        }

        /// <summary>
        /// Dependency injection for Lambda
        /// </summary>
        /// <param name="serviceProvider"></param>
        private Entity1Lambda(IServiceProvider serviceProvider)
        {
            this._mediator = serviceProvider.GetRequiredService<IMediator>();
            this._entity1Query = serviceProvider.GetRequiredService<IEntity1Query>();
        }

        [LambdaSerializer(typeof(JsonSerializer))]
        public async Task<APIGatewayProxyResponse> Create(APIGatewayProxyRequest request, ILambdaContext lambdaContext)
        {
            var command = request.DeserializeBody<CreateEntity1Command>();

            if(command is null)
            {
                return new APIGatewayProxyResponse().SetBadRequest();
            }
            else
            {
                string newEntityId = await this._mediator.Send(command).ConfigureAwait(false);

                return new APIGatewayProxyResponse().SetSuccess(newEntityId);
            }
        }

        [LambdaSerializer(typeof(JsonSerializer))]
        public async Task<APIGatewayProxyResponse> Get(APIGatewayProxyRequest request, ILambdaContext lambdaContext)
        {
            object result;

            if (request.PathParameters.ContainsKey("id"))
            {
                string id = request.PathParameters["id"];

                result = await this._entity1Query.GetAsync(id).ConfigureAwait(false);
            }
            else
            {
                result = await this._entity1Query.GetAllAsync().ConfigureAwait(false);
            }

            return result is null ?
                new APIGatewayProxyResponse().SetNotfound()
                : new APIGatewayProxyResponse().SetSuccess(result);
        }
    }
}
