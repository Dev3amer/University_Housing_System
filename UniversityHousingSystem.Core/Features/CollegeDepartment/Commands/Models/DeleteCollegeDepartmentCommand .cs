using MediatR;
using UniversityHousingSystem.Core.Features.Events.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;
using UniversityHousingSystem.Data.Helpers.Enums;

namespace UniversityHousingSystem.Core.Features.Events.Commands.Models
{
    public class DeleteCollegeDepartmentCommand : IRequest<Response<bool>>
    {
        public byte CollegeDepartmentId { get; set; }
    }
}
