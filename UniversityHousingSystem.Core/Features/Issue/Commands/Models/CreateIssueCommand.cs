using MediatR;
using UniversityHousingSystem.Core.Features.Events.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;

namespace UniversityHousingSystem.Core.Features.Events.Commands.Models
{
    public class CreateIssueCommand : IRequest<Response<GetIssueByIdResponse>>
    {
        public string Description { get; set; } = default!;
        public int IssueTypeId { get; set; }

    }
}
