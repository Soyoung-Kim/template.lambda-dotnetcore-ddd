using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.TestUtilities;
using MyLambdaDotNetCoreProject.Api;
using MyLambdaDotNetCoreProject.Application.Queries.Readmodel;
using MyLambdaDotNetCoreProject.Domain.Aggregates.Entity1Aggregate;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace MyLambdaDotNetCoreProject.Tests
{
    public class Entity1Test : IClassFixture<EnvironmentFixture>
    {
        [Fact]
        public async Task TestGetAllEntity()
        {
            // Invoke the lambda function and confirm the string was upper cased.
            var context = new TestLambdaContext();
            var response = await new Entity1Lambda().Get(new APIGatewayProxyRequest(), context);
            var entities = response.DeserializeBody<IEnumerable<Entity1View>>();

            Assert.True(entities?.Any());
        }
        [Fact]
        public async Task TestCreateEntity()
        {
            // Invoke the lambda function and confirm the string was upper cased.
            var context = new TestLambdaContext();
            var body = JsonConvert.SerializeObject(new { Name = "test name" });
            var response = await new Entity1Lambda().Create(new APIGatewayProxyRequest() { Body = body }, context);
            var newId = response.Body;

            Assert.NotEmpty(newId);
        }
    }
}
