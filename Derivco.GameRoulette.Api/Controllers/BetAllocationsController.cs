using Derivco.GameRoulette.Application.Features.BetAllocation.Commands.CreateBetAllocation;
using Derivco.GameRoulette.Application.Features.BetAllocation.Commands.UpdateBetAllocation;
using Derivco.GameRoulette.Application.Features.BetAllocation.Queries.GetBetAllocationDetails;
using Derivco.GameRoulette.Application.Features.BetAllocation.Queries.GetBetAllocations;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Derivco.GameRoulette.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BetAllocationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BetAllocationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<BetAllocationsController>
        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<List<BetAllocationDto>>> Get(bool isLoggedInBettor = false)
        {
            var betAllocations = await _mediator.Send(new GetBetAllocationListQuery());
            return Ok(betAllocations);
        }

        // GET api/<BetAllocationsController>/5
        [HttpGet("{id}")]
        [Produces("application/json")]
        public async Task<ActionResult<BetAllocationDetailsDto>> Get(int id)
        {
            var betAllocation = await _mediator.Send(new GetBetAllocationDetailQuery { Id = id });
            return Ok(betAllocation);
        }

        // POST api/<BetAllocationsController>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        public async Task<ActionResult> Post(CreateBetAllocationCommand betAllocation)
        {
            var response = await _mediator.Send(betAllocation);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        // PUT api/<BetAllocationsController>/5
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [Produces("application/json")]
        public async Task<ActionResult> Put(UpdateBetAllocationCommand betAllocation)
        {
            await _mediator.Send(betAllocation);
            return NoContent();
        }
    }
}
