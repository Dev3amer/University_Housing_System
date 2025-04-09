using MediatR;
using Microsoft.AspNetCore.Mvc;
using UniversityHousingSystem.API.APIBases;
using UniversityHousingSystem.Core.Features.Country.Queries.Models;
using UniversityHousingSystem.Core.Features.Village.Queries.Models;
using UniversityHousingSystem.Data.AppMetaData;

namespace UniversityHousingSystem.API.Controllers
{
    [ApiController]
    public class CountriesController : AppController
    {
        public CountriesController(IMediator mediator) : base(mediator) { }


        [HttpGet(Router.CountryRouting.List)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllCountriesAsync()
        {
            var result = await _mediator.Send(new GetAllCountriesQuery());
            return NewResult(result);
        }

        [HttpGet(Router.CountryRouting.Governorates)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllGovernoratesByCountryIdAsync(int countryId)
        {
            var result = await _mediator.Send(new GetAllGovernoratesByCountryIdQuery() { CountryId = countryId });
            return NewResult(result);
        }

    }
}



