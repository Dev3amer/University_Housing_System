using MediatR;
using UniversityHousingSystem.Core.Features.Events.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;
using UniversityHousingSystem.Data.Helpers.Enums;

namespace UniversityHousingSystem.Core.Features.CollegeDepartment.Commands.Models
{
    public class CreateViolationCommand : IRequest<Response<GetViolationByIdResponse>>
    {
        public DateTime ViolationDate { get; set; }

        public int ViolationTypeId { get; set; }
        public int StudentHistoryId { get; set; }

    }
}
