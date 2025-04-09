using MediatR;
using UniversityHousingSystem.Core.Features.City.Queries.Models;
using UniversityHousingSystem.Core.Features.City.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;
using UniversityHousingSystem.Service.Abstractions;

namespace UniversityHousingSystem.Core.Features.Governorate.Queries.Handler
{
    public class CityQueryHandler : ResponseHandler,
        IRequestHandler<GetAllVillagesByCityIdQuery, Response<List<GetAllVillagesByCityIdResponse>>>

    {
        private readonly IVillageService _villageService;

        public CityQueryHandler(IVillageService villageService)
        {
            _villageService = villageService;
        }

        public async Task<Response<List<GetAllVillagesByCityIdResponse>>> Handle(GetAllVillagesByCityIdQuery request, CancellationToken cancellationToken)
        {
            var villages = await _villageService.GetVillagesByCityIdAsync(request.CityId);

            if (villages == null || !villages.Any())
            {
                return NotFound<List<GetAllVillagesByCityIdResponse>>("No Villages found for the specified country.");
            }

            var response = villages.Select(v => new GetAllVillagesByCityIdResponse
            {
                VillageId = v.VillageId,
                NameEn = v.NameEn,
                NameAr = v.NameAr
            }).ToList();

            return Success(response);
        }
    }
}
