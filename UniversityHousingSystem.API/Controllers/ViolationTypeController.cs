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
    [Route(Router.ViolationTypeRouting.Prefix)]
    public class ViolationTypeController : AppController
    {
        public ViolationTypeController(IMediator mediator) : base(mediator) { }

        #region Queries
        [Authorize]
        [HttpGet("list")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllViolationsTypesAsync()
        {
            var result = await _mediator.Send(new GetAllViolationTypeQuery());
            return NewResult(result);
        }
        [Authorize]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetViolationTypeByIdAsync(int id)
        {
            var result = await _mediator.Send(new GetViolationTypeByIdQuery(id)); // ✅ Use constructor
            return NewResult(result);
        }
        #endregion

        #region Commands
        [Authorize(Roles = "Admin,Employee")]
        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateViolationType([FromForm] CreateViolationTypeCommand model)
        {
            var result = await _mediator.Send(model);
            return NewResult(result);
        }
        [Authorize(Roles = "Admin,Employee")]
        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> EditViolationType([FromForm] UpdateViolationTypeCommand model)
        {
            var result = await _mediator.Send(model);
            return NewResult(result);
        }
        [Authorize(Roles = "Admin,Employee")]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteViolationType([FromRoute] int id)
        {
            var result = await _mediator.Send(new DeleteViolationTypeCommand { ViolationTypeId = id });
            return NewResult(result);
        }

        #endregion
    }
}

