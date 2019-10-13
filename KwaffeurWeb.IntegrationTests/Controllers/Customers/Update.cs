using Application.Customers.Commands.UpdateCustomer;
using Domain.ValueObjects;
using KwaffeurWeb.IntegrationTest.Common;
using KwaffeurWeb.IntegrationTests.Common;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace KwaffeurWeb.IntegrationTests.Controllers.Customers
{
    public class Update : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public Update(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }
        [Fact]
        public async Task GivenUpdateCustomerCommand_ReturnsSuccessStatusCode()
        {
            var client = await _factory.GetAuthenticatedClientAsync();

            var command = new UpdateCustomerCommand
            {
                Id = 1,
                Active = false,
                Person = new Person("Jos", "Jossian", Domain.Enums.GenderType.Male),
                CustomerType = Domain.Enums.CustomerType.Private,
                Address = new Address("Stationstraat", "10", "Zaventem", "West-Vlaanderen", null, null),
                ContactData = new ContactData("kevin.v@riskmatrix.be", null, "+324700706043", null, null)
            };

            var content = Utilities.GetRequestContent(command);
            var response = await client.PutAsync($"/api/customers/update/{command.Id}", content);
            response.EnsureSuccessStatusCode();
        }
        [Fact]
        public async Task GivenUpdateCustomerCommandWithInvalidId_ReturnsNotFoundStatusCode()
        {
            var client = await _factory.GetAuthenticatedClientAsync();

            var invalidCommand = new UpdateCustomerCommand
            {
                Id = 0,
                Active = false,
                Person = new Person("Jos", "Jossian", Domain.Enums.GenderType.Male),
                CustomerType = Domain.Enums.CustomerType.Private,
                Address = new Address("Stationstraat", "10", "Zaventem", "West-Vlaanderen", null, null),
                ContactData = new ContactData("kevin.v@riskmatrix.be", null, "+324700706043", null, null)
            };



            var content = Utilities.GetRequestContent(invalidCommand);

            var response = await client.PutAsync($"/api/customers/update/{invalidCommand.Id}", content);

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
