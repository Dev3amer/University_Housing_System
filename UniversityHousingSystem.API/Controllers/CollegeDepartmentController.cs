using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using UniversityHousingSystem.API.APIBases;
using UniversityHousingSystem.Core.Features.CollegeDepartment.Commands.Models;
using UniversityHousingSystem.Core.Features.Events.Queries.Models;
using UniversityHousingSystem.Data.AppMetaData;

namespace UniversityHousingSystem.API.Controllers
{
    [ApiController]
    [Route(Router.CollegeDepartmentRouting.Prefix)] // 🔹 Base route added
    public class CollegeDepartmentController : AppController
    {
        public CollegeDepartmentController(IMediator mediator) : base(mediator) { }

        #region Queries

        [HttpGet("List")]
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
            var result = await _mediator.Send(new GetCollegeDepartmentByIdQuery(id)); // ✅ Use constructor
            return NewResult(result);
        }

  

        #endregion

        #region Commands

        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateCollegeDepartment([FromForm] CreateCollegeDepartmentCommand model)
        {
            var result = await _mediator.Send(model);
            return NewResult(result);
        }

        [HttpPut("Update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> EditCollegeDepartment([FromForm] UpdateCollegeDepartmentCommand model)
        {
            var result = await _mediator.Send(model);
            return NewResult(result);
        }

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

