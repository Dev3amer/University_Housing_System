using MediatR;
using Microsoft.AspNetCore.Mvc;
using UniversityHousingSystem.API.APIBases;
using UniversityHousingSystem.Core.Features.OldStudent.Commands.Models;
using UniversityHousingSystem.Core.Features.OldStudent.Queries.Models;
using UniversityHousingSystem.Data.AppMetaData;

namespace UniversityHousingSystem.API.Controllers
{
    [ApiController]
    public class OldStudentsController : AppController
    {
        public OldStudentsController(IMediator mediator) : base(mediator)
        {
        }

        #region Queries
        [HttpGet(Router.OldStudentRouting.list)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllOldStudentsAsync()
        {
            var result = await _mediator.Send(new GetAllOldStudentsQuery());
            return NewResult(result);
        }

        [HttpGet(Router.OldStudentRouting.GetById)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetOldStudentByIdAsync(int id)
        {
            var result = await _mediator.Send(new GetOldStudentByIdQuery() { OldStudentId = id });
            return NewResult(result);
        }

        [HttpGet(Router.OldStudentRouting.paginated)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetOldStudentsPaginatedList([FromQuery] GetOldStudentsPaginatedListQuery model)
        {
            var result = await _mediator.Send(model);
            return Ok(result);
        }
        #endregion
        #region Commands
        [HttpPost(Router.OldStudentRouting.Create)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateOldStudent([FromForm] CreateOldStudentCommand model)
        {
            var result = await _mediator.Send(model);
            return NewResult(result);
        }

        [HttpPut(Router.OldStudentRouting.Update)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateOldStudent([FromForm] UpdateOldStudentCommand model)
        {
            var result = await _mediator.Send(model);
            return NewResult(result);
        }

        [HttpDelete(Router.OldStudentRouting.FullDelete)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteOldStudent(int id)
        {
            var result = await _mediator.Send(new DeleteOldStudentCommand() { OldStudentId = id });
            return NewResult(result);
        }
        #endregion
    }
}
