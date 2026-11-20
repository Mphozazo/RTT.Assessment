using MediatR;
using Microsoft.AspNetCore.Mvc;
using RTT.Assessment.Application.Features.Contact.Commands.DeleteContact;
using RTT.Assessment.Application.Features.Person.Commands.CreatePerson;
using RTT.Assessment.Application.Features.Person.Commands.DeletePerson;
using RTT.Assessment.Application.Features.Person.Commands.UpdatePerson;
using RTT.Assessment.Application.Features.Person.Queries;
using RTT.Assessment.Application.Features.Person.Queries.GetAllPersons;
using RTT.Assessment.Application.Features.Person.Queries.GetPersonDetails;
using RTT.Assessment.Application.Features.Reports;

namespace RTT.Assessment.WebApi.Controllers
{
    [Route("/v1/api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<PersonDto>>> Get()
        {
            var people = await _mediator.Send(new GetAllPersonsQueries());

            return Ok(people);

        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PersonDto>> Get(int id)
        {
            var person = await _mediator.Send(new GetPersonDetailsQueries { Id = id });

            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        [HttpGet("generate-report/{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PersonReportDto>> GetReport(int id)
        {
            var personReport = await _mediator.Send(new GeneratePersonReportCommnd { PersonId = id });

            if (personReport == null)
            {
                return NotFound();
            }

            //Todo ;Implement report generation and return the report as a Excel file .





            return Ok(personReport);
        }
        [HttpPost("createperson")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreatePersonCommand personCommand)
        {
            var response = await _mediator.Send(personCommand);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        [HttpPut("updateperson")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdatePersonCommand personCommand)
        {
            await _mediator.Send(personCommand);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeletePersonCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }

    
}
