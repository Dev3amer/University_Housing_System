using MediatR;
using Microsoft.AspNetCore.Mvc;
using UniversityHousingSystem.API.APIBases;
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
        #endregion

    }
}
