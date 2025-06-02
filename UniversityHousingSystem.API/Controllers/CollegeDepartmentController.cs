using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using UniversityHousingSystem.API.APIBases;
using UniversityHousingSystem.Core.Features.CollegeDepartment.Commands.Models;
using UniversityHousingSystem.Core.Features.Events.Queries.Models;
using UniversityHousingSystem.Data.AppMetaData;

namespace UniversityHousingSystem.API.Controllers
{
    [ApiController]
    [Route(Router.CollegeDepartmentRouting.Prefix)]
    public class CollegeDepartmentController : AppController
    {
        public CollegeDepartmentController(IMediator mediator) : base(mediator) { }

        #region Queries

        [HttpGet("list")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllCollegesDepartmentAsync()
        {
            var result = await _mediator.Send(new GetAllCollegesDepartmentQuery());
            return NewResult(result);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCollegeDepartmentByIdAsync(
        [FromRoute, SwaggerSchema(Format = "byte")] byte id)
        {
            var result = await _mediator.Send(new GetCollegeDepartmentByIdQuery(id));
            return NewResult(result);
        }

        #endregion

        #region Commands
        [Authorize(Roles = "Admin,Employee")]
        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateCollegeDepartment([FromForm] CreateCollegeDepartmentCommand model)
        {
            var result = await _mediator.Send(model);
            return NewResult(result);
        }
        [Authorize(Roles = "Admin,Employee")]
        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> EditCollegeDepartment([FromForm] UpdateCollegeDepartmentCommand model)
        {
            var result = await _mediator.Send(model);
            return NewResult(result);
        }
        [Authorize(Roles = "Admin,Employee")]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteCollegeDepartment([FromRoute] byte id)
        {
            var result = await _mediator.Send(new DeleteCollegeDepartmentCommand { CollegeDepartmentId = id });
            return NewResult(result);
        }

        #endregion
    }
}

