using MediatR;
using UniversityHousingSystem.Core.ResponseBases;

namespace UniversityHousingSystem.Core.Features.Employees.Commands.Models
{
    public class DeleteEmployeeCommand : IRequest<Response<bool>>
    {
        public int EmployeeId { get; set; }
    }
}
