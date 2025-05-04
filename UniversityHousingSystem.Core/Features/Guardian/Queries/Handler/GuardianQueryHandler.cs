using MediatR;
using UniversityHousingSystem.Core.Features.Events.Queries.Models;
using UniversityHousingSystem.Core.Features.Events.Queries.Results;
using UniversityHousingSystem.Core.Features.Guardian.Queries.Models;
using UniversityHousingSystem.Core.Features.Guardian.Queries.Results;
using UniversityHousingSystem.Core.Pagination;
using UniversityHousingSystem.Core.ResponseBases;
using UniversityHousingSystem.Data.Resources;
using UniversityHousingSystem.Service.Abstractions;

namespace UniversityHousingSystem.Core.Features.Buildings.Queries.Handler
{
    public class GuardianQueryHandler : ResponseHandler,
        IRequestHandler<GetAllGuardiansQuery, Response<List<GetAllGuardiansResponse>>>,
        IRequestHandler<GetGuardianByIdQuery, Response<GetGuardianByIdResponse>>,
        IRequestHandler<GetGuardiansPaginatedListQuery, PaginatedList<GetGuardiansPaginatedListResponse>>
    {
        #region Fields
        private readonly IGuardianService _guardianService;
        #endregion
        #region Constructor
        public GuardianQueryHandler(IGuardianService guardianService)
        {
            _guardianService = guardianService;
        }
        #endregion
        #region handlers
        public async Task<Response<List<GetAllGuardiansResponse>>> Handle(GetAllGuardiansQuery request, CancellationToken cancellationToken)
        {
            var GuardiansList = await _guardianService.GetAllAsync();

            var mappedGuardiansList = GuardiansList.Select(b => new GetAllGuardiansResponse()
            {
                GuardianId = b.GuardianId,
                FirstName = b.FirstName,
                SecondName = b.SecondName,
                ThirdName = b.ThirdName,
                FourthName = b.FourthName,
                Job = b.Job,
                NationalId = b.NationalId,
                Phone = b.Phone,
                GuardianRelation = b.GuardianRelation
            }).ToList();

            return Success(mappedGuardiansList);
        }
        public async Task<Response<GetGuardianByIdResponse>> Handle(GetGuardianByIdQuery request, CancellationToken cancellationToken)
        {
            var guardian = await _guardianService.GetAsync(request.GuardianId);

            if (guardian is null)
                return NotFound<GetGuardianByIdResponse>(string.Format(SharedResourcesKeys.NotFound, nameof(Guardian)));

            var mappedGuardiansList = new GetGuardianByIdResponse()
            {
                GuardianId = guardian.GuardianId,
                FirstName = guardian.FirstName,
                SecondName = guardian.SecondName,
                ThirdName = guardian.ThirdName,
                FourthName = guardian.FourthName,
                Job = guardian.Job,
                NationalId = guardian.NationalId,
                Phone = guardian.Phone,
                GuardianRelation = guardian.GuardianRelation
            };

            return Success(mappedGuardiansList);
        }

        public async Task<PaginatedList<GetGuardiansPaginatedListResponse>> Handle(GetGuardiansPaginatedListQuery request, CancellationToken cancellationToken)
        {
            var guardiansListQueryable = _guardianService.GetAllQueryable();

            var paginatedList = await guardiansListQueryable.Select(e => new GetGuardiansPaginatedListResponse
            {
                GuardianId = e.GuardianId,
                FirstName = e.FirstName,
                SecondName = e.SecondName,
                ThirdName = e.ThirdName,
                FourthName = e.FourthName,
                Job = e.Job,
                NationalId = e.NationalId,
                Phone = e.Phone,
                GuardianRelation = e.GuardianRelation
            }).ToPaginatedListAsync(request.PageNumber, request.PageSize);

            return paginatedList;
        }
        #endregion
    }
}
