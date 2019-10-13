using Application.Customers.Queries.GetCustomersList;
using KwaffeurWeb.IntegrationTest.Common;
using KwaffeurWeb.IntegrationTests.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace KwaffeurWeb.IntegrationTests.Controllers.Customers
{
    public class GetAll : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public GetAll(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ReturnsCustomersListViewModel()
        {
            var client = await _factory.GetAuthenticatedClientAsync();

            var response = await client.GetAsync("/api/customers/getall");

            response.EnsureSuccessStatusCode();

            var vm = await Utilities.GetResponseContent<CustomersListViewModel>(response);

            Assert.IsType<CustomersListViewModel>(vm);
            Assert.NotEmpty(vm.Customers);
        }
    }
}
