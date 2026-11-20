using MediatR;
using Microsoft.AspNetCore.Mvc;
using RTT.Assessment.Application.Features.Address.Commands.CreateAddress;
using RTT.Assessment.Application.Features.Address.Queries;
using RTT.Assessment.Application.Features.Contact.Commands.CreateContact;
using RTT.Assessment.Application.Features.Contact.Queries;
using RTT.Assessment.Application.Features.Contact.Queries.GetAllContact;
using RTT.Assessment.Application.Features.Contact.Queries.GetPersonContactDetails;

namespace RTT.Assessment.WebApi.Controllers
{
    [Route("/v1/api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AddressController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<ActionResult<List<AddressDto>>> Get()
        {
            var contacts = await _mediator.Send(new GetAllContactQueries());

            return Ok(contacts);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AddressDto>> Get(int id)
        {
            var contact = await _mediator.Send(new GetContactDetailsQueries { Id = id });

            if (contact == null)
            {
                return NotFound();
            }

            return Ok(contact);
        }

        [HttpPost("createaddress")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateAddressCommand contactCommand)
        {
            var response = await _mediator.Send(contactCommand);
            return CreatedAtAction(nameof(Get), new { id = response });
        }
    }
}
