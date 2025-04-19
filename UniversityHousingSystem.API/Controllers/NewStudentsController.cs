using MediatR;
using Microsoft.AspNetCore.Mvc;
using UniversityHousingSystem.API.APIBases;
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
    }
}
