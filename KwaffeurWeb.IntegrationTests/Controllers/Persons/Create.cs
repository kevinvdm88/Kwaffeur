using Application.Persons.Commands.CreatePerson;
using Domain.Enums;
using Domain.ValueObjects;
using KwaffeurWeb;
using KwaffeurWeb.IntegrationTest.Common;
using KwaffeurWeb.IntegrationTests.Common;
using System.Threading.Tasks;
using Xunit;

namespace KwaffeurWeb.IntegrationTest.Controllers.Persons
{
    public class Create : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public Create(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenCreateProductCommand_ReturnsNewProductId()
        {
            var client = await _factory.GetAuthenticatedClientAsync();

            var command = new CreatePersonCommand
            {

                GenderType = GenderType.Male,
                Name = new Name("Jan", "Janssen"),

            };

            var content = Utilities.GetRequestContent(command);

            var response = await client.PostAsync($"/api/persons/create", content);

            response.EnsureSuccessStatusCode();

            var productId = await Utilities.GetResponseContent<int>(response);

            Assert.NotEqual(0, productId);
        }

    }
}
