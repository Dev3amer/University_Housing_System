using MediatR;
using Microsoft.AspNetCore.Http;
using UniversityHousingSystem.Core.Features.Events.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;
using UniversityHousingSystem.Data.Helpers.Enums;

namespace UniversityHousingSystem.Core.Features.Events.Commands.Models
{
    public class UpdateIssueCommand : IRequest<Response<GetIssueByIdResponse>>
    {
        public int IssueId { get; set; }
        public string Description { get; set; } = default!;
        public string? Response { get; set; }
        public DateTime? ResponseDate { get; set; }
        public int IssueTypeId { get; set; }
        public int StudentId { get; set; }
        public int? EmployeeId { get; set; }

    }
}
