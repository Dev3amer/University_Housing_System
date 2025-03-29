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
    [Route(Router.GovernorateRouting.Prefix)] // 🔹 Base route for rooms
    public class GovernorateController : AppController
    {
        public GovernorateController(IMediator mediator) : base(mediator) { }


        [HttpGet("List")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllGovernoratesAsync()
        {
            var result = await _mediator.Send(new GetAllGovernorateQuery());
            return NewResult(result);
        }


    }
} 



