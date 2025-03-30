using MediatR;
using Microsoft.AspNetCore.Mvc;
using UniversityHousingSystem.API.APIBases;
using UniversityHousingSystem.Core.Features.Events.Commands.Models;
using UniversityHousingSystem.Core.Features.Events.Queries.Models;
using UniversityHousingSystem.Core.Features.Governorate.Queries.Models;
using UniversityHousingSystem.Data.AppMetaData;

namespace UniversityHousingSystem.API.Controllers
{
    [ApiController]
    [Route(Router.CityRouting.Prefix)] // 🔹 Base route for rooms
    public class CityController : AppController
    {
        public CityController(IMediator mediator) : base(mediator) { }


        [HttpGet("List")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllCitiesAsync()
        {
            var result = await _mediator.Send(new GetAllCityQuery());
            return NewResult(result);
        }


    }
} 



