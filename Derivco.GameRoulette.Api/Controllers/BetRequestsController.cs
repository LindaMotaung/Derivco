using Derivco.GameRoulette.Application.Features.BetRequest.Commands.CreateBetRequest;
using Derivco.GameRoulette.Application.Features.BetRequest.Commands.UpdateBetRequest;
using Derivco.GameRoulette.Application.Features.BetRequest.Queries.GetBetRequestDetail;
using Derivco.GameRoulette.Application.Features.BetRequest.Queries.GetBetRequestsList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Derivco.GameRoulette.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BetRequestsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BetRequestsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<BetRequestsController>
        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<List<BetRequestListDto>>> Get(bool isLoggedInBettor = false)
        {
            var betRequests = await _mediator.Send(new GetBetRequestListQuery());
            return Ok(betRequests);
        }

        // GET api/<BetRequestsController>/5
        [HttpGet("{id}")]
        [Produces("application/json")]
        public async Task<ActionResult<BetRequestDetailsDto>> Get(int id)
        {
            var betRequest = await _mediator.Send(new GetBetRequestDetailQuery { Id = id });
            return Ok(betRequest);
        }

        // POST api/<BetRequestsController>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        public async Task<ActionResult> Post(CreateBetRequestCommand betRequest)
        {
            var response = await _mediator.Send(betRequest);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        // PUT api/<BetRequestsController>/5
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [Produces("application/json")]
        public async Task<ActionResult> Put(UpdateBetRequestCommand betRequest)
        {
            await _mediator.Send(betRequest);
            return NoContent();
        }
    }
}
