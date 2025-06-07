using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniversityHousingSystem.API.APIBases;
using UniversityHousingSystem.Core.Features.RegistrationPeriod.Commands.Models;
using UniversityHousingSystem.Core.Features.RegistrationPeriods.Commands.Models;
using UniversityHousingSystem.Core.Features.RegistrationPeriods.Queries.Models;
using UniversityHousingSystem.Data.AppMetaData;

namespace UniversityHousingSystem.API.Controllers
{
    [ApiController]
    public class RegistrationPeriodController : AppController
    {
        public RegistrationPeriodController(IMediator mediator) : base(mediator)
        {

        }

        #region Queries
        [HttpGet(Router.PeriodsRouting.list)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllPeriodsAsync()
        {
            var result = await _mediator.Send(new GetAllRegistrationPeriodsQuery());
            return NewResult(result);
        }
        [HttpGet(Router.PeriodsRouting.GetById)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPeriodByIdAsync(int id)
        {
            var result = await _mediator.Send(new GetRegistrationPeriodByIdQuery() { RegistrationPeriodId = id });
            return NewResult(result);
        }
        #endregion
        #region Commands
        [Authorize(Roles = "Admin,Employee")]
        [HttpPost(Router.PeriodsRouting.Create)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateRegistrationPeriod([FromForm] CreateRegistrationPeriodCommand model)
        {
            var result = await _mediator.Send(model);
            return NewResult(result);
        }

        [Authorize(Roles = "Admin,Employee")]
        [HttpPost(Router.PeriodsRouting.Close)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ClosePeriodByIdAsync(int id)
        {
            var result = await _mediator.Send(new CloseRegistrationPeriodCommand() { PeriodId = id });
            return NewResult(result);
        }

        [Authorize(Roles = "Admin,Employee")]
        [HttpPut(Router.PeriodsRouting.Update)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateRegistrationPeriod([FromForm] UpdateRegistrationPeriodCommand model)
        {
            var result = await _mediator.Send(model);
            return NewResult(result);
        }
        [Authorize(Roles = "Admin,Employee")]
        [HttpDelete(Router.PeriodsRouting.Delete)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteRegistrationPeriod(int id)
        {
            var result = await _mediator.Send(new DeleteRegistrationPeriodCommand() { RegistrationPeriodId = id });
            return NewResult(result);
        }
        #endregion
    }
}
