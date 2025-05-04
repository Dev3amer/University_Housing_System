using MediatR;
using Microsoft.AspNetCore.Mvc;
using UniversityHousingSystem.API.APIBases;
using UniversityHousingSystem.Core.Features.NewStudent.Commands.Models;
using UniversityHousingSystem.Core.Features.NewStudent.Queries.Models;
using UniversityHousingSystem.Data.AppMetaData;

namespace UniversityHousingSystem.API.Controllers
{
    [ApiController]
    public class NewStudentsController : AppController
    {
        public NewStudentsController(IMediator mediator) : base(mediator)
        {
        }

        #region Queries
        [HttpGet(Router.NewStudentRouting.list)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllNewStudentsAsync()
        {
            var result = await _mediator.Send(new GetAllNewStudentsQuery());
            return NewResult(result);
        }

        [HttpGet(Router.NewStudentRouting.GetById)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetNewStudentByIdAsync(int id)
        {
            var result = await _mediator.Send(new GetNewStudentByIdQuery() { NewStudentId = id });
            return NewResult(result);
        }

        [HttpGet(Router.NewStudentRouting.paginated)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetNewStudentsPaginatedList([FromQuery] GetNewStudentsPaginatedListQuery model)
        {
            var result = await _mediator.Send(model);
            return Ok(result);
        }
        #endregion
        #region Commands
        [HttpPost(Router.NewStudentRouting.Create)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> NewStudentStudent([FromForm] CreateNewStudentCommand model)
        {
            var result = await _mediator.Send(model);
            return NewResult(result);
        }

        [HttpPut(Router.NewStudentRouting.Update)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateNewStudent([FromForm] UpdateNewStudentCommand model)
        {
            var result = await _mediator.Send(model);
            return NewResult(result);
        }

        [HttpDelete(Router.NewStudentRouting.FullDelete)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteNewStudent(int id)
        {
            var result = await _mediator.Send(new DeleteNewStudentWithDependanciesCommand() { NewStudentId = id });
            return NewResult(result);
        }
        #endregion
    }
}
