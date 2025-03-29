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
    public class GovernorateQueryHandler : ResponseHandler,
        IRequestHandler<GetAllGovernorateQuery, Response<List<GetAllGovernorateResponse>>>
    {
        private readonly IGovernorateService _governorateService;

        public GovernorateQueryHandler(IGovernorateService governorateService)
        {
            _governorateService = governorateService;
        }

        public async Task<Response<List<GetAllGovernorateResponse>>> Handle(GetAllGovernorateQuery request, CancellationToken cancellationToken)
        {
            var governorates = await _governorateService.GetAllAsync(); // Use GetAllAsync()

            if (governorates == null || !governorates.Any())
            {
                return NotFound<List<GetAllGovernorateResponse>>("No governorates found for the specified country.");
            }

            var response = governorates.Select(g => new GetAllGovernorateResponse
            {
                GovernorateId = g.GovernorateId,
                NameEn = g.NameEn,
                NameAr = g.NameAr
            }).ToList();

            return Success(response);
        }
    }
}
