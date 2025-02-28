using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieReservationSystem.Data.AppMetaData;
using UniversityHousingSystem.API.APIBases;
using UniversityHousingSystem.Core.Features.Events.Commands.Models;
using UniversityHousingSystem.Core.Features.Events.Queries.Models;

namespace UniversityHousingSystem.API.Controllers
{
    [ApiController]
    public class EventsController : AppController
    {
        public EventsController(IMediator mediator) : base(mediator)
        {

        }

        #region Queries
        [HttpGet(Router.EventRouting.list)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllEventAsync()
        {
            var result = await _mediator.Send(new GetAllEventsQuery());
            return NewResult(result);
        }

        [HttpGet(Router.EventRouting.coming)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetComingEventsAsync()
        {
            var result = await _mediator.Send(new GetComingEventsQuery());
            return NewResult(result);
        }
        [HttpGet(Router.EventRouting.paginated)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetEventsPaginatedList([FromQuery] GetEventsPaginatedListQuery model)
        {
            var result = await _mediator.Send(model);
            return Ok(result);
        }

        [HttpGet(Router.EventRouting.GetById)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetEventByIdAsync(int id)
        {
            var result = await _mediator.Send(new GetEventByIdQuery() { EventId = id });
            return NewResult(result);
        }
        #endregion
        #region Commands
        [HttpPost(Router.EventRouting.Create)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateMovie([FromForm] CreateEventCommand model)
        {
            var result = await _mediator.Send(model);
            return NewResult(result);
        }
        #endregion
    }
}
