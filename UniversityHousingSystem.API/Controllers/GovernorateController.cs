using MediatR;
using Microsoft.AspNetCore.Mvc;
using UniversityHousingSystem.API.APIBases;
using UniversityHousingSystem.Core.Features.Governorate.Queries.Models;
using UniversityHousingSystem.Data.AppMetaData;

namespace UniversityHousingSystem.API.Controllers
{
    [ApiController]
    public class GovernorateController : AppController
    {
        public GovernorateController(IMediator mediator) : base(mediator) { }

        [HttpGet(Router.GovernorateRouting.Cities)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllCitiesByGovernorateIdAsync(int governorateId)
        {
            var result = await _mediator.Send(new GetAllCitiesByGovernorateIdQuery() { GovernorateId = governorateId });
            return NewResult(result);
        }
    }
}



