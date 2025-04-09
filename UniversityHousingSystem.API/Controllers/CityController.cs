using MediatR;
using Microsoft.AspNetCore.Mvc;
using UniversityHousingSystem.API.APIBases;
using UniversityHousingSystem.Core.Features.City.Queries.Models;
using UniversityHousingSystem.Data.AppMetaData;

namespace UniversityHousingSystem.API.Controllers
{
    [ApiController]
    public class CityController : AppController
    {
        public CityController(IMediator mediator) : base(mediator) { }

        [HttpGet(Router.CityRouting.Villages)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllVillagesAsync(int cityId)
        {
            var result = await _mediator.Send(new GetAllVillagesByCityIdQuery() { CityId = cityId });
            return NewResult(result);
        }

    }
}



