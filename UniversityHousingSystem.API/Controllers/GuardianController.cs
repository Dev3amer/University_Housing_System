using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniversityHousingSystem.API.APIBases;
using UniversityHousingSystem.Core.Features.Events.Queries.Models;
using UniversityHousingSystem.Core.Features.Guardian.Queries.Models;
using UniversityHousingSystem.Data.AppMetaData;

namespace UniversityHousingSystem.API.Controllers
{
    [ApiController]
    public class GuardianController : AppController
    {
        public GuardianController(IMediator mediator) : base(mediator) { }

        #region Queries
        [Authorize(Roles = "Admin,Employee")]
        [HttpGet(Router.GuardianRouting.List)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllGuardiansAsync()
        {
            var result = await _mediator.Send(new GetAllGuardiansQuery());
            return NewResult(result);
        }
        [Authorize(Roles = "Admin,Employee")]
        [HttpGet(Router.GuardianRouting.GetByNationalId)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetGuardianByNationalIdIdAsync(string nationalId)
        {
            var result = await _mediator.Send(new GetGuardianByNationalIdQuery(nationalId));
            return NewResult(result);
        }
        [Authorize(Roles = "Admin,Employee")]
        [HttpGet(Router.GuardianRouting.paginated)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetGuardiansPaginatedList([FromQuery] GetGuardiansPaginatedListQuery model)
        {
            var result = await _mediator.Send(model);
            return Ok(result);
        }

        #endregion
    }
}

