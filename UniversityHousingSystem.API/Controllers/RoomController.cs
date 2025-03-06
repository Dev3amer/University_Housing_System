using MediatR;
using Microsoft.AspNetCore.Mvc;
using UniversityHousingSystem.API.APIBases;
using UniversityHousingSystem.Core.Features.Events.Commands.Models;
using UniversityHousingSystem.Core.Features.Events.Queries.Models;
using UniversityHousingSystem.Data.AppMetaData;

namespace UniversityHousingSystem.API.Controllers
{
    [ApiController]
    [Route(Router.RoomRouting.Prefix)] // 🔹 Base route for rooms
    public class RoomController : AppController
    {
        public RoomController(IMediator mediator) : base(mediator) { }


        [HttpGet("List")]
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

        

  

        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateRoom([FromForm] CreateRoomCommand model)
        {
            var result = await _mediator.Send(model);
            return NewResult(result);
        }

        [HttpPut("Update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> EditRoom([FromForm] UpdateRoomCommand model)
        {
            var result = await _mediator.Send(model);
            return NewResult(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteRoom([FromRoute] int id)
        {
            var result = await _mediator.Send(new DeleteRoomCommand(id)); // ✅ Use constructor
            return NewResult(result);
        }
        [HttpGet("Paginated")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetRoomsPaginated([FromQuery] GetRoomsPaginatedQuery query)
        {
            var result = await _mediator.Send(query);
            return NewResult(result);
        }
        [HttpGet("FreeRooms")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFreeRoomsAsync([FromQuery] GetFreeRoomsQuery query)
        {
            var result = await _mediator.Send(query);
            return NewResult(result);
        }

    }
} 



