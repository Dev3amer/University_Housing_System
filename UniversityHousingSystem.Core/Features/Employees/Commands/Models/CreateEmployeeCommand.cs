using MediatR;
using UniversityHousingSystem.Core.Features.Employees.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;

namespace UniversityHousingSystem.Core.Features.Employees.Commands.Models
{
    public class CreateEmployeeCommand : IRequest<Response<GetEmployeeByIdResponse>>
    {
        public string FirstName { get; set; } = default!;
        public string SecondName { get; set; } = default!;
        public string ThirdName { get; set; } = default!;
        public string FourthName { get; set; } = default!;
        public string UserName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
    }
}
