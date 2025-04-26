using MediatR;
using UniversityHousingSystem.Core.Features.Events.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;

namespace UniversityHousingSystem.Core.Features.Events.Queries.Models
{
    public class GetIssueTypeByIdQuery : IRequest<Response<GetIssueTypeByIdResponse>>
    {
        public int IssueTypeId { get; set; }

        public GetIssueTypeByIdQuery(int issueTypeId)
        {
            IssueTypeId = issueTypeId;
        }
    }
}
