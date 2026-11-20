using MediatR;
using Microsoft.AspNetCore.Mvc;
using RTT.Assessment.Application.Features.Person.Queries;
using RTT.Assessment.Application.Features.Person.Queries.GetAllPersons;

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

    }
}
