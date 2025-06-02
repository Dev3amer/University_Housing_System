using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniversityHousingSystem.API.APIBases;
using UniversityHousingSystem.Core.Features.CollegeDepartment.Commands.Models;
using UniversityHousingSystem.Core.Features.Events.Queries.Models;
using UniversityHousingSystem.Data.AppMetaData;

namespace UniversityHousingSystem.API.Controllers
{
    [ApiController]
    [Route(Router.ViolationRouting.Prefix)]
    public class ViolationController : AppController
    {
        public ViolationController(IMediator mediator) : base(mediator) { }

        #region Queries
        [Authorize(Roles = "Admin,Employee")]
        [HttpGet("list")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllViolationsAsync()
        {
            var result = await _mediator.Send(new GetAllViolationsQuery());
            return NewResult(result);
        }
        [Authorize]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetViolationByIdAsync(int id)
        {
            var result = await _mediator.Send(new GetViolationByIdQuery(id));
            return NewResult(result);
        }
        #endregion

        #region Commands
        [Authorize(Roles = "Admin,Employee")]
        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateViolation([FromForm] CreateViolationCommand model)
        {
            var result = await _mediator.Send(model);
            return NewResult(result);
        }
        [Authorize(Roles = "Admin,Employee")]
        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> EditViolation([FromForm] UpdateViolationCommand model)
        {
            var result = await _mediator.Send(model);
            return NewResult(result);
        }
        [Authorize(Roles = "Admin,Employee")]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteViolation([FromRoute] int id)
        {
            var result = await _mediator.Send(new DeleteViolationCommand { ViolationId = id });
            return NewResult(result);
        }

        #endregion
    }
}

