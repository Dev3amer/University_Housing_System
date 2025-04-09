using MediatR;
using UniversityHousingSystem.Core.Features.Governorate.Queries.Models;
using UniversityHousingSystem.Core.Features.Governorate.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;
using UniversityHousingSystem.Service.Abstractions;

namespace UniversityHousingSystem.Core.Features.Governorate.Queries.Handler
{
    public class GovernorateQueryHandler : ResponseHandler,
        IRequestHandler<GetAllCitiesByGovernorateIdQuery, Response<List<GetAllCitiesByGovernorateIdResponse>>>
    {
        private readonly ICityService _cityService;

        public GovernorateQueryHandler(ICityService cityService)
        {
            _cityService = cityService;
        }

        public async Task<Response<List<GetAllCitiesByGovernorateIdResponse>>> Handle(GetAllCitiesByGovernorateIdQuery request, CancellationToken cancellationToken)
        {
            var cities = await _cityService.GetAllByGovernorateIdAsync(request.GovernorateId);

            if (cities == null || !cities.Any())
            {
                return NotFound<List<GetAllCitiesByGovernorateIdResponse>>("No cities found for the specified Governorate.");
            }

            var response = cities.Select(g => new GetAllCitiesByGovernorateIdResponse
            {
                CityId = g.CityId,
                NameEn = g.NameEn,
                NameAr = g.NameAr
            }).ToList();

            return Success(response);
        }
    }
}
