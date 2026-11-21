using MediatR;
using Microsoft.AspNetCore.Mvc;
using RTT.Assessment.Application.Features.Person.Commands.CreatePerson;
using RTT.Assessment.Application.Features.Person.Commands.DeletePerson;
using RTT.Assessment.Application.Features.Person.Commands.UpdatePerson;
using RTT.Assessment.Application.Features.Person.Queries;
using RTT.Assessment.Application.Features.Person.Queries.GetAllPersons;
using RTT.Assessment.Application.Features.Person.Queries.GetPersonDetails;
using RTT.Assessment.Application.Features.Reports;
using RTT.Assessment.WebApi.Contracts;

namespace RTT.Assessment.WebApi.Controllers
{
    [Route("/v1/api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        // GET: /v1/api/person - returns a list of all persons in excel format
        private const string XlsxContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

        private readonly IMediator _mediator;
        private readonly IPersonExcelBuilder _personExcelBuilder;
        public PersonController(IMediator mediator , IPersonExcelBuilder personExcelBuilder)
        {
            _mediator = mediator;
            _personExcelBuilder = personExcelBuilder;
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

        [HttpGet("generate-report/{personId}")]
        [ProducesResponseType(typeof(FileContentResult), StatusCodes.Status200OK, XlsxContentType)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PersonReportDto>> GetReport(int personId)
        {
            var personReport = await _mediator.Send(new GeneratePersonReportCommnd { PersonId = personId });

            if (personReport == null)
            {
                return NotFound();
            }

            var excelBytes = _personExcelBuilder.Build(personReport);
            var fileName = $"PersonReport_{personId}_{DateTime.UtcNow:yyyyMMddHHmm}.xlsx";

            return File(excelBytes, XlsxContentType, fileName);
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

        [HttpDelete("{personId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int personId)
        {
            var command = new DeletePersonCommand { Id = personId };
            await _mediator.Send(command);
            return NoContent();
        }
    }

    
}
