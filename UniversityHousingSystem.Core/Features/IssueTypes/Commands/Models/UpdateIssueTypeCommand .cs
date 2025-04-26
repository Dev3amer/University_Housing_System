using MediatR;
using UniversityHousingSystem.Core.Features.Events.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;
using UniversityHousingSystem.Data.Helpers.Enums;

namespace UniversityHousingSystem.Core.Features.CollegeDepartment.Commands.Models
{
    public class UpdateIssueTypeCommand : IRequest<Response<GetIssueTypeByIdResponse>>
    {
        public int IssueTypeId { get; set; }
        public string TypeName { get; set; } = default!;
    }
}
