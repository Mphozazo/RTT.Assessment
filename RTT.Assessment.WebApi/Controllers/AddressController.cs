using MediatR;
using Microsoft.AspNetCore.Mvc;
using RTT.Assessment.Application.Features.Address.Commands.CreateAddress;
using RTT.Assessment.Application.Features.Address.Commands.DeleteAddress;
using RTT.Assessment.Application.Features.Address.Commands.UpdateAddress;
using RTT.Assessment.Application.Features.Address.Queries;
using RTT.Assessment.Application.Features.Address.Queries.GetAllAddressQueries;

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
            var address = await _mediator.Send(new GetAllAddressQueries());

            return Ok(address);
        }

        [HttpGet("{addressId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AddressDto>> Get(int addressId)
        {
            var address = await _mediator.Send(new GetAllAddressQueries { Id = addressId });

            if (address == null)
            {
                return NotFound();
            }

            return Ok(address);
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


        
         [HttpPut("updateaddress")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdateAddressCommand addressCommand)
        {
            await _mediator.Send(addressCommand);
            return NoContent();
        }

        [HttpDelete("{addressId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int addressId)
        {
            var command = new DeleteAddressCommand { Id = addressId };
            await _mediator.Send(command);
            return NoContent();
        }
         
    }
}
