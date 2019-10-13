using Application.Customers.Commands.CreateCustomer;
using Domain.ValueObjects;
using KwaffeurWeb.IntegrationTest.Common;
using KwaffeurWeb.IntegrationTests.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace KwaffeurWeb.IntegrationTests.Controllers.Customers
{
    public class Create : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public Create(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenCreateCustomerCommand_ReturnsNewCustomerId()
        {
            var client = await _factory.GetAuthenticatedClientAsync();

            var command = new CreateCustomerCommand
            {
                Active = false,
                CustomerType = Domain.Enums.CustomerType.Professional,
                Person = new Person("Kevin", "Van der Mieren", Domain.Enums.GenderType.Male),
                Address = new Address("kerkstraat", "23", "brugge", "West-Vlaanderen", null, null),
                ContactData = new ContactData("kevin.v@riskmatrix.be", null, "+324700706043", null, null),
            };

            var content = Utilities.GetRequestContent(command);

            var response = await client.PostAsync($"/api/customers/create", content);

            response.EnsureSuccessStatusCode();

            var productId = await Utilities.GetResponseContent<int>(response);

            Assert.NotEqual(0, productId);
        }
    }
}
