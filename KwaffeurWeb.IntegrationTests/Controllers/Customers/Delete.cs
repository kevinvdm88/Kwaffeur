using KwaffeurWeb.IntegrationTests.Common;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace KwaffeurWeb.IntegrationTests.Controllers.Customers
{
    public class Delete : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public Delete(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }
        [Fact]
        public async Task GivenId_ReturnsSuccessStatusCode()
        {
            var client = await _factory.GetAuthenticatedClientAsync();

            var validId = 1;

            var response = await client.DeleteAsync($"/api/customers/delete/{validId}");

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GivenInvalidId_ReturnsNotFoundStatusCode()
        {
            var client = await _factory.GetAuthenticatedClientAsync();

            var invalidId = 0;

            var response = await client.DeleteAsync($"/api/customers/delete/{invalidId}");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
