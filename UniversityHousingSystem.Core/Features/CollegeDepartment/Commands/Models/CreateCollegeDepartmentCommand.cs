using MediatR;
using UniversityHousingSystem.Core.Features.Events.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;
using UniversityHousingSystem.Data.Helpers.Enums;

namespace UniversityHousingSystem.Core.Features.CollegeDepartment.Commands.Models
{
    public class CreateCollegeDepartmentCommand : IRequest<Response<GetCollegeDepartmentByIdResponse>>
    {
        public string Name { get; set; } = default!;
        public int CollegeId { get; set; }

    }
}
