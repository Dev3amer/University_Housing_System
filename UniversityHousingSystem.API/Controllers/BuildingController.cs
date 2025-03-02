using MediatR;
using Microsoft.AspNetCore.Mvc;
using UniversityHousingSystem.API.APIBases;
using UniversityHousingSystem.Core.Features.Events.Commands.Models;
using UniversityHousingSystem.Core.Features.Events.Queries.Models;
using UniversityHousingSystem.Data.AppMetaData;

namespace UniversityHousingSystem.API.Controllers
{
    [ApiController]
    [Route(Router.BuildingRouting.Prefix)] // 🔹 Base route added
    public class BuildingController : AppController
    {
        public BuildingController(IMediator mediator) : base(mediator) { }

        #region Queries

        [HttpGet("List")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllBuildingsAsync()
        {
            var result = await _mediator.Send(new GetAllBuildingsQuery());
            return NewResult(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBuildingByIdAsync(int id)
        {
            var result = await _mediator.Send(new GetBuildingByIdQuery(id)); // ✅ Use constructor
            return NewResult(result);
        }

        [HttpGet("Paginated")] // 🔹 Fixed missing route
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetBuildingsPaginatedList([FromQuery] GetBuildingsPaginatedQuery model)
        {
            var result = await _mediator.Send(model);
            return Ok(result);
        }

        #endregion

        #region Commands

        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateBuilding([FromForm] CreateBuildingCommand model)
        {
            var result = await _mediator.Send(model);
            return NewResult(result);
        }

        [HttpPut("Update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> EditBuilding([FromForm] UpdateBuildingCommand model)
        {
            var result = await _mediator.Send(model);
            return NewResult(result);
        }

        [HttpDelete("{id}")] // 🔹 Explicit {id} parameter
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteBuilding([FromRoute] int id)
        {
            var result = await _mediator.Send(new DeleteBuildingCommand { BuildingId = id });
            return NewResult(result);
        }

        #endregion
    }
}

