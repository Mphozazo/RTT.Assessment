using MediatR;
using Microsoft.AspNetCore.Mvc;
using RTT.Assessment.Application.Features.Contact.Commands.CreateContact;
using RTT.Assessment.Application.Features.Contact.Commands.DeleteContact;
using RTT.Assessment.Application.Features.Contact.Commands.UpdateContact;
using RTT.Assessment.Application.Features.Contact.Queries;
using RTT.Assessment.Application.Features.Contact.Queries.GetAllContact;
using RTT.Assessment.Application.Features.Contact.Queries.GetPersonContactDetails;

namespace RTT.Assessment.WebApi.Controllers
{
    [Route("/v1/api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ContactController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<ContactDto>>> Get()
        {
            var contacts = await _mediator.Send(new GetAllContactQueries());

            return Ok(contacts);
        }

        [HttpGet("{contactId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ContactDto>> Get(int contactId)
        {
            var contact = await _mediator.Send(new GetContactDetailsQueries { Id = contactId });

            if (contact == null)
            {
                return NotFound();
            }

            return Ok(contact);
        }

        [HttpPost("createcontact")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateContactCommand contactCommand)
        {
            var response = await _mediator.Send(contactCommand);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        [HttpPut("updatecontact")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdateContactCommand contactCommand)
        {
            await _mediator.Send(contactCommand);
            return NoContent();
        }

        [HttpDelete("{contactId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int contactId)
        {
            var command = new DeleteContactCommand { Id = contactId };
            await _mediator.Send(command);
            return NoContent();
        }



    }
}
