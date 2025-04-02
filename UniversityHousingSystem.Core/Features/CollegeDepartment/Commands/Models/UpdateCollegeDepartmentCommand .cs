using MediatR;
using UniversityHousingSystem.Core.Features.Events.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;
using UniversityHousingSystem.Data.Helpers.Enums;

namespace UniversityHousingSystem.Core.Features.Events.Commands.Models
{
    public class UpdateCollegeDepartmentCommand : IRequest<Response<GetCollegeDepartmentByIdResponse>>
    {
        public byte CollegeDepartmentId { get; set; }
        public string Name { get; set; } = default!;
        public int CollegeId { get; set; }


    }
}
