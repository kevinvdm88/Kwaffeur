using Application.Persons.Commands.CreatePerson;
using Application.Persons.Commands.DeletePerson;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KwaffeurWeb.Controllers
{

    public class PersonsController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreatePersonCommand command)
        {
            var personId = await Mediator.Send(command);

            return Ok(personId);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeletePersonCommand { Id = id });

            return NoContent();
        }

    }
}
