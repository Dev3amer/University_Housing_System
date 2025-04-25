using MediatR;
using UniversityHousingSystem.Core.Features.Employees.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;

namespace UniversityHousingSystem.Core.Features.Employees.Queries.Models
{
    public class GetEmployeeByIdQuery : IRequest<Response<GetEmployeeByIdResponse>>
    {
        public int EmployeeId { get; set; }
    }
}
