using MediatR;
using Microsoft.AspNetCore.Mvc;
using UniversityHousingSystem.API.APIBases;
using UniversityHousingSystem.Core.Features.HighSchools.Queries.Models;
using UniversityHousingSystem.Data.AppMetaData;

namespace UniversityHousingSystem.API.Controllers
{
    [ApiController]
    public class highSchoolsController : AppController
    {
        public highSchoolsController(IMediator mediator) : base(mediator)
        {

        }

        #region Queries
        [HttpGet(Router.HighSchoolRouting.List)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllHighSchoolsAsync()
        {
            var result = await _mediator.Send(new GetAllHighSchoolsQuery());
            return NewResult(result);
        }
        #endregion

    }
}
