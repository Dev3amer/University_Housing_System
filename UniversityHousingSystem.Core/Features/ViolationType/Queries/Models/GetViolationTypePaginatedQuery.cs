using MediatR;
using UniversityHousingSystem.Core.Features.Events.Queries.Results;
using UniversityHousingSystem.Core.Pagination;
using UniversityHousingSystem.Core.ResponseBases;
using UniversityHousingSystem.Data.Helpers.Enums;

namespace UniversityHousingSystem.Core.Features.Events.Queries.Models
{
    public class GetViolationTypePaginatedQuery : IRequest<PaginatedList<GetViolationTypePaginatedResponse>>
    {
        public string ViolationTypeName { get; set; } = default!;

    }
}
