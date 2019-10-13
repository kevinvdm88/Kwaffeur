using Application.Customers.Commands.CreateCustomer;
using Application.Customers.Commands.DeleteCustomer;
using Application.Customers.Commands.UpdateCustomer;
using Application.Customers.Queries.GetCustomersList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KwaffeurWeb.Controllers
{
    [Authorize]
    public class CustomersController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateCustomerCommand command)
        {
            var customerId = await Mediator.Send(command);

            return Ok(customerId);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromBody]UpdateCustomerCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteCustomerCommand { Id = id });

            return NoContent();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CustomersListViewModel>> GetAll()
        {
            return Ok(await Mediator.Send(new GetCustomersListQuery()));
        }
    }
}
