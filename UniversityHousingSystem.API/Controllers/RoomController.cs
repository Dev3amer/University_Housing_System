using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniversityHousingSystem.API.APIBases;
using UniversityHousingSystem.Core.Features.Events.Commands.Models;
using UniversityHousingSystem.Core.Features.Events.Queries.Models;
using UniversityHousingSystem.Data.AppMetaData;

namespace UniversityHousingSystem.API.Controllers
{
    [ApiController]
    [Route(Router.RoomRouting.Prefix)]
    public class RoomController : AppController
    {
        public RoomController(IMediator mediator) : base(mediator) { }


        [HttpGet("list")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllRoomsAsync()
        {
            var result = await _mediator.Send(new GetAllRoomsQuery());
            return NewResult(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetRoomByIdAsync(int id)
        {
            var result = await _mediator.Send(new GetRoomByIdQuery(id));
            return NewResult(result);
        }
        [Authorize(Roles = "Admin,Employee")]
        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateRoom([FromForm] CreateRoomCommand model)
        {
            var result = await _mediator.Send(model);
            return NewResult(result);
        }
        [Authorize(Roles = "Admin,Employee")]
        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> EditRoom([FromForm] UpdateRoomCommand model)
        {
            var result = await _mediator.Send(model);
            return NewResult(result);
        }
        [Authorize(Roles = "Admin,Employee")]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteRoom([FromRoute] int id)
        {
            var result = await _mediator.Send(new DeleteRoomCommand(id)); // ✅ Use constructor
            return NewResult(result);
        }
        [HttpGet("paginated")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetRoomsPaginated([FromQuery] GetRoomsPaginatedQuery query)
        {
            var result = await _mediator.Send(query);
            return NewResult(result);
        }
        [HttpGet("freeRooms")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFreeRoomsAsync([FromQuery] GetFreeRoomsQuery query)
        {
            var result = await _mediator.Send(query);
            return NewResult(result);
        }

    }
}



