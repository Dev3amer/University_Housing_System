using MediatR;
using UniversityHousingSystem.Core.Features.Events.Queries.Models;
using UniversityHousingSystem.Core.Features.Events.Queries.Results;
using UniversityHousingSystem.Core.Pagination;
using UniversityHousingSystem.Core.ResponseBases;
using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Data.Resources;
using UniversityHousingSystem.Service.Abstractions;

namespace UniversityHousingSystem.Core.Features.Buildings.Queries.Handler
{
    public class BuildingQueryHandler : ResponseHandler,
        IRequestHandler<GetAllBuildingsQuery, Response<List<GetAllBuildingResponse>>>,
        IRequestHandler<GetBuildingByIdQuery, Response<GetBuildingByIdResponse>>,
        IRequestHandler<GetBuildingsPaginatedQuery, PaginatedList<GetBuildingsPaginatedResponse>>



    {
        #region Fields
        private readonly IBuildingService _buildingService;
        #endregion
        #region Constructor
        public BuildingQueryHandler(IBuildingService buildingService)
        {
            _buildingService = buildingService;
        }
        #endregion
        #region handlers
        public async Task<Response<List<GetAllBuildingResponse>>> Handle(GetAllBuildingsQuery request, CancellationToken cancellationToken)
        {
            var buildingsList = await _buildingService.GetAllAsync();

            var mappedBuildingsList = buildingsList.Select(b => new GetAllBuildingResponse()
            {
                BuildingId = b.BuildingId,
                Name = b.Name,
                Type = b.Type.ToString(),
                Address = b.AddressInDetails
            }).ToList();

            return Success(mappedBuildingsList);
        }
        public async Task<Response<GetBuildingByIdResponse>> Handle(GetBuildingByIdQuery request, CancellationToken cancellationToken)
        {
            var building = await _buildingService.GetAsync(request.BuildingId);

            if (building is null)
                return NotFound<GetBuildingByIdResponse>(string.Format(SharedResourcesKeys.NotFound, nameof(Building)));

            var mappedBuilding = new GetBuildingByIdResponse()
            {
                BuildingId = building.BuildingId,
                Name = building.Name,
                Description = building.Description,
                Address = building.AddressInDetails,
                MapSearchText = building.MapSearchText,
                Type = building.Type.ToString(),
                VillageName = building.Village.NameEn
            };

            return Success(mappedBuilding);
        }

        public async Task<PaginatedList<GetBuildingsPaginatedResponse>> Handle(GetBuildingsPaginatedQuery request, CancellationToken cancellationToken)
        {
            var buildingsQueryable = _buildingService.GetAllQueryable(request.Search, request.BuildingType);

            var paginatedList = await buildingsQueryable.Select(b => new GetBuildingsPaginatedResponse
            {
                BuildingId = b.BuildingId,
                Name = b.Name,
                Type = b.Type.ToString(),
                Address = b.AddressInDetails
            }).ToPaginatedListAsync(request.PageNumber, request.PageSize);

            return paginatedList;
        }



        #endregion
    }
}
