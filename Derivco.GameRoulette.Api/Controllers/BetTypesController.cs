using Derivco.GameRoulette.Application.Features.BetType.Commands.CreateBetType;
using Derivco.GameRoulette.Application.Features.BetType.Commands.UpdateBetType;
using Derivco.GameRoulette.Application.Features.BetType.Queries.GetAllBetTypes;
using Derivco.GameRoulette.Application.Features.BetType.Queries.GetBetTypeDetails;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Derivco.GameRoulette.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BetTypesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BetTypesController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        // GET: api/<BetTypesController>
        [HttpGet]
        public async Task<List<BetTypeDto>> Get()
        {
            var betTypes = await _mediator.Send(new GetBetTypesQuery());
            return betTypes;
        }

        // GET api/<BetTypesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BetTypeDetailsDto>> Get(int id)
        {
            var betType = await _mediator.Send(new GetBetTypeDetailsQuery(id));
            return Ok(betType);
        }

        // POST api/<BetTypesController>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateBetTypeCommand betType)
        {
            var response = await _mediator.Send(betType);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        // PUT api/<BetTypesController>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdateBetTypeCommand betType)
        {
            await _mediator.Send(betType);
            return NoContent();
        }
    }
}
