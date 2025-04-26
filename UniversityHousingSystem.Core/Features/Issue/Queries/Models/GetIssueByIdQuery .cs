using MediatR;
using UniversityHousingSystem.Core.Features.Events.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;

namespace UniversityHousingSystem.Core.Features.Events.Queries.Models
{
    public class GetIssueByIdQuery : IRequest<Response<GetIssueByIdResponse>>
    {
        public int Id { get; set; }
        public GetIssueByIdQuery(int id) => Id = id;
    }
}
