using MediatR;
using UniversityHousingSystem.Core.Features.HighSchools.Queries.Models;
using UniversityHousingSystem.Core.Features.HighSchools.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;
using UniversityHousingSystem.Service.Abstractions;

namespace UniversityHousingSystem.Core.Features.HighSchools.Queries.Handler
{
    public class HighSchoolsQueryQueryHandler : ResponseHandler,
        IRequestHandler<GetAllHighSchoolsQuery, Response<List<GetAllHighSchoolsResponse>>>

    {
        private readonly IHighSchoolService _highSchoolService;

        public HighSchoolsQueryQueryHandler(IHighSchoolService highSchoolService)
        {
            _highSchoolService = highSchoolService;
        }

        public async Task<Response<List<GetAllHighSchoolsResponse>>> Handle(GetAllHighSchoolsQuery request, CancellationToken cancellationToken)
        {
            var highSchools = await _highSchoolService.GetAllAsync();

            var mappedHighSchoolsList = highSchools.Select(e => new GetAllHighSchoolsResponse()
            {
                HighSchoolId = e.HighSchoolId,
                Name = e.Name,
            }).ToList();

            return Success(mappedHighSchoolsList);
        }
    }
}
