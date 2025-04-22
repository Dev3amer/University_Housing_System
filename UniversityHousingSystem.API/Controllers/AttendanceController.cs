using MediatR;
using Microsoft.AspNetCore.Mvc;
using UniversityHousingSystem.API.APIBases;
using UniversityHousingSystem.Core.Features.Attendance.Commands.Models;
using UniversityHousingSystem.Data.AppMetaData;

namespace UniversityHousingSystem.API.Controllers
{
    [ApiController]
    public class AttendanceController : AppController
    {
        public AttendanceController(IMediator mediator) : base(mediator)
        {

        }

        #region Commands
        [HttpPost(Router.AttendanceRouting.Create)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> CreateAttendance([FromForm] CreateStudentAttendance model)
        {
            var result = await _mediator.Send(model);
            return NewResult(result);
        }
        #endregion
    }
}
