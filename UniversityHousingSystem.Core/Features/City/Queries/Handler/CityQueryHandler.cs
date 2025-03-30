using MediatR;
using UniversityHousingSystem.Core.Features.Events.Queries.Models;
using UniversityHousingSystem.Core.Features.Events.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;
using UniversityHousingSystem.Service.Abstractions;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UniversityHousingSystem.Core.Features.Governorate.Queries.Results;
using UniversityHousingSystem.Core.Features.Governorate.Queries.Models;

namespace UniversityHousingSystem.Core.Features.Governorate.Queries.Handler
{
    public class CityQueryHandler : ResponseHandler,
        IRequestHandler<GetAllCityQuery, Response<List<GetAllCityResponse>>>
    {
        private readonly ICityService _cityService;

        public CityQueryHandler(ICityService cityService)
        {
            _cityService = cityService;
        }

        public async Task<Response<List<GetAllCityResponse>>> Handle(GetAllCityQuery request, CancellationToken cancellationToken)
        {
            var cities = await _cityService.GetAllAsync(); // Use GetAllAsync()

            if (cities == null || !cities.Any())
            {
                return NotFound<List<GetAllCityResponse>>("No cities found for the specified country.");
            }

            var response = cities.Select(g => new GetAllCityResponse
            {
                CityId = g.CityId,
                NameEn = g.NameEn,
                NameAr = g.NameAr
            }).ToList();

            return Success(response);
        }
    }
}
