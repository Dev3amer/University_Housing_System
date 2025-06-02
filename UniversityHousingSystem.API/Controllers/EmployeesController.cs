using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniversityHousingSystem.API.APIBases;
using UniversityHousingSystem.Core.Features.Employees.Commands.Models;
using UniversityHousingSystem.Core.Features.Employees.Queries.Models;
using Router = UniversityHousingSystem.Data.AppMetaData.Router;

namespace UniversityHousingSystem.API.Controllers
{
    [ApiController]
    [Authorize(Roles = "Admin")]
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
        [HttpPost(Router.EmployeeRouting.Create)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateEmployee([FromForm] CreateEmployeeCommand model)
        {
            var result = await _mediator.Send(model);
            return NewResult(result);
        }
        [HttpDelete(Router.EmployeeRouting.Delete)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var result = await _mediator.Send(new DeleteEmployeeCommand() { EmployeeId = id });
            return NewResult(result);
        }
        #endregion
    }
}
