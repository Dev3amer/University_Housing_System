using MediatR;
using UniversityHousingSystem.Core.Features.Events.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;
using UniversityHousingSystem.Data.Helpers.Enums;

namespace UniversityHousingSystem.Core.Features.Events.Commands.Models
{
    public class DeleteIssueCommand : IRequest<Response<bool>> // ✅ Corrected to return string response
    {
        public int IssueId { get; set; }

        public DeleteIssueCommand(int roomId)
        {
            IssueId = roomId;
        }
    }
}
