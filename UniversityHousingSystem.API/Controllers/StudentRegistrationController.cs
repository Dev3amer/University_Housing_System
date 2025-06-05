using MediatR;
using Microsoft.AspNetCore.Mvc;
using UniversityHousingSystem.API.APIBases;
using UniversityHousingSystem.Core.Features.StudentRegistration.Commands.Models;

namespace UniversityHousingSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentRegistrationController : AppController
    {
        public StudentRegistrationController(IMediator mediator) : base(mediator)
        {

        }
        #region Commands
        [HttpPost("request-code")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RequestRegistrationCode([FromForm] SendRegistrationCodeToEmail model)
        {
            var result = await _mediator.Send(model);
            return NewResult(result);
        }
        #endregion
    }
}
