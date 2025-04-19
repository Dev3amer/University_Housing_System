using MediatR;
using UniversityHousingSystem.Core.Features.Events.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;
using UniversityHousingSystem.Data.Helpers.Enums;

namespace UniversityHousingSystem.Core.Features.CollegeDepartment.Commands.Models
{
    public class DeleteCollegeDepartmentCommand : IRequest<Response<bool>>
    {
        public int CollegeDepartmentId { get; set; }
    }
}
