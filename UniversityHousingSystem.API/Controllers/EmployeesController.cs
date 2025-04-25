using MediatR;
using Microsoft.AspNetCore.Mvc;
using UniversityHousingSystem.API.APIBases;
using UniversityHousingSystem.Core.Features.Employees.Queries.Models;
using Router = UniversityHousingSystem.Data.AppMetaData.Router;

namespace UniversityHousingSystem.API.Controllers
{
    [ApiController]
    public class EmployeesController : AppController
    {
        public EmployeesController(IMediator mediator) : base(mediator)
        {

        }
        #region Queries
        [HttpGet(Router.EmployeeRouting.GetById)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var result = await _mediator.Send(new GetEmployeeByIdQuery() { EmployeeId = id });
            return NewResult(result);
        }
        [HttpGet(Router.EmployeeRouting.paginated)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetEmployeesPaginatedList([FromQuery] GetEmployeesPaginatedListQuery model)
        {
            var result = await _mediator.Send(model);
            return Ok(result);
        }
        #endregion
        #region Commands
        // [HttpPost("api/employees")]
        // public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeCommand command)
        // {
        //     var response = await _mediator.Send(command);
        //     return response.ToActionResult();
        // }
        #endregion
    }
}
