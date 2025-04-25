using MediatR;
using UniversityHousingSystem.Core.Features.Employees.Queries.Models;
using UniversityHousingSystem.Core.Features.Employees.Queries.Results;
using UniversityHousingSystem.Core.Pagination;
using UniversityHousingSystem.Core.ResponseBases;
using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Data.Resources;
using UniversityHousingSystem.Service.Abstractions;

namespace UniversityHousingSystem.Core.Features.Employees.Queries.Handlers
{
    public class EmployeesQueriesHandler : ResponseHandler,
        IRequestHandler<GetEmployeeByIdQuery, Response<GetEmployeeByIdResponse>>,
        IRequestHandler<GetEmployeesPaginatedListQuery, PaginatedList<GetEmployeesPaginatedListResponse>>
    {
        #region Fields
        private readonly IEmployeeService _employeeService;
        #endregion

        #region Constructor
        public EmployeesQueriesHandler(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        #endregion
        #region Methods
        public async Task<Response<GetEmployeeByIdResponse>> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var employee = await _employeeService.GetAsync(request.EmployeeId);

            if (employee == null)
                return NotFound<GetEmployeeByIdResponse>(string.Format(SharedResourcesKeys.NotFound, nameof(Employee)));

            var employeeResponse = new GetEmployeeByIdResponse()
            {
                EmployeeId = employee.EmployeeId,
                FirstName = employee.FirstName,
                SecondName = employee.SecondName,
                ThirdName = employee.ThirdName,
                FourthName = employee.FourthName
            };
            return Success(employeeResponse);
        }

        public async Task<PaginatedList<GetEmployeesPaginatedListResponse>> Handle(GetEmployeesPaginatedListQuery request, CancellationToken cancellationToken)
        {
            var employeesListQueryable = _employeeService.GetAllQueryable(request.Search);

            var paginatedList = await employeesListQueryable.Select(e => new GetEmployeesPaginatedListResponse
            {
                EmployeeId = e.EmployeeId,
                FirstName = e.FirstName,
                SecondName = e.SecondName,
                ThirdName = e.ThirdName,
                FourthName = e.FourthName
            }).ToPaginatedListAsync(request.PageNumber, request.PageSize);

            return paginatedList;
        }
        #endregion
    }
}
