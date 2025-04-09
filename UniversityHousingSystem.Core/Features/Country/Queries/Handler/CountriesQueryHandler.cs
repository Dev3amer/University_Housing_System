using MediatR;
using UniversityHousingSystem.Core.Features.Country.Queries.Models;
using UniversityHousingSystem.Core.Features.Country.Queries.Results;
using UniversityHousingSystem.Core.Features.Village.Queries.Models;
using UniversityHousingSystem.Core.ResponseBases;
using UniversityHousingSystem.Service.Abstractions;

namespace UniversityHousingSystem.Core.Features.Country.Queries.Handler
{
    public class CountriesQueryHandler : ResponseHandler,
        IRequestHandler<GetAllCountriesQuery, Response<List<GetAllCountriesResponse>>>,
        IRequestHandler<GetAllGovernoratesByCountryIdQuery, Response<List<GetAllGovernoratesByCountryIdResponse>>>
    {
        private readonly ICountryService _countryService;
        private readonly IGovernorateService _governorateService;
        public CountriesQueryHandler(ICountryService countryService, IGovernorateService governorateService)
        {
            _countryService = countryService;
            _governorateService = governorateService;
        }

        public async Task<Response<List<GetAllCountriesResponse>>> Handle(GetAllCountriesQuery request, CancellationToken cancellationToken)
        {
            var countries = await _countryService.GetAllAsync();

            if (countries == null || !countries.Any())
            {
                return NotFound<List<GetAllCountriesResponse>>("No Countries found");
            }

            var response = countries.Select(v => new GetAllCountriesResponse
            {
                CountryId = v.CountryId,
                NameEn = v.NameEn,
                NameAr = v.NameAr
            }).ToList();

            return Success(response);
        }

        public async Task<Response<List<GetAllGovernoratesByCountryIdResponse>>> Handle(GetAllGovernoratesByCountryIdQuery request, CancellationToken cancellationToken)
        {
            var governorates = await _governorateService.GetAllByCountryIdAsync(request.CountryId);

            if (governorates == null || !governorates.Any())
            {
                return NotFound<List<GetAllGovernoratesByCountryIdResponse>>("No governorates found for the specified country.");
            }

            var response = governorates.Select(g => new GetAllGovernoratesByCountryIdResponse
            {
                GovernorateId = g.GovernorateId,
                NameEn = g.NameEn,
                NameAr = g.NameAr
            }).ToList();

            return Success(response);
        }
    }
}
