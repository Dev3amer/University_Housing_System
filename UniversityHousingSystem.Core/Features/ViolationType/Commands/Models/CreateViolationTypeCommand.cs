using MediatR;
using UniversityHousingSystem.Core.Features.Events.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;
using UniversityHousingSystem.Data.Helpers.Enums;

namespace UniversityHousingSystem.Core.Features.CollegeDepartment.Commands.Models
{
    public class CreateViolationTypeCommand : IRequest<Response<GetViolationTypeByIdResponse>>
    {
        public string Description { get; set; }
        public EnViolationLevel ViolationLevel { get; set; }
        public decimal? RequiredAmount { get; set; }

        

    }
}
