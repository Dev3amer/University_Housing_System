using MediatR;
using Microsoft.AspNetCore.Identity;
using UniversityHousingSystem.Core.Features.Events.Commands.Models;
using UniversityHousingSystem.Core.Features.Events.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;
using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Data.Entities.Identity;
using UniversityHousingSystem.Data.Resources;
using UniversityHousingSystem.Service.Abstractions;

namespace UniversityHousingSystem.Core.Features.Events.Commands.Handler
{
    public class BuildingCommandHandler : ResponseHandler,
      IRequestHandler<CreateBuildingCommand, Response<GetBuildingByIdResponse>>,
      IRequestHandler<UpdateBuildingCommand, Response<GetBuildingByIdResponse>>,
      IRequestHandler<DeleteBuildingCommand, Response<bool>>
    {
        #region Fields
        private readonly IBuildingService _buildingService;
        private readonly ICurrentUserService _currentUserService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IVillageService _villageService;
        #endregion

        #region Constructor
        public BuildingCommandHandler(
            IBuildingService buildingService,
            ICurrentUserService currentUserService,
            UserManager<ApplicationUser> userManager,
            IVillageService villageService)
        {
            _buildingService = buildingService;
            _currentUserService = currentUserService;
            _userManager = userManager;
            _villageService = villageService;
        }
        #endregion

        #region Handlers

        public async Task<Response<GetBuildingByIdResponse>> Handle(CreateBuildingCommand request, CancellationToken cancellationToken)
        {
            var village = await _villageService.GetByIdAsync(request.VillageId);
            if (village == null)
                return BadRequest<GetBuildingByIdResponse>(string.Format(SharedResourcesKeys.NotFound, nameof(Village)));

            var newBuilding = new Building
            {
                Name = request.Name,
                Description = request.Description,
                AddressInDetails = request.AddressInDetails,
                MapSearchText = request.MapSearchText,
                Type = request.Type,
                VillageId = village.VillageId
            };

            var createdBuilding = await _buildingService.CreateAsync(newBuilding);

            var response = new GetBuildingByIdResponse
            {
                BuildingId = createdBuilding.BuildingId,
                Name = createdBuilding.Name,
                Description = createdBuilding.Description,
                Address = createdBuilding.AddressInDetails,
                MapSearchText = createdBuilding.MapSearchText,
                Type = createdBuilding.Type.ToString(),
                VillageName = village.NameEn
            };

            return Created(response, string.Format(SharedResourcesKeys.Created, nameof(Building)));
        }

        public async Task<Response<GetBuildingByIdResponse>> Handle(UpdateBuildingCommand request, CancellationToken cancellationToken)
        {
            var existingBuilding = await _buildingService.GetAsync(request.BuildingId);
            if (existingBuilding == null)
                return BadRequest<GetBuildingByIdResponse>(string.Format(SharedResourcesKeys.NotFound, nameof(Building)));

            var village = await _villageService.GetByIdAsync(request.VillageId);
            if (village == null)
                return BadRequest<GetBuildingByIdResponse>(string.Format(SharedResourcesKeys.NotFound, nameof(Village)));

            existingBuilding.Name = request.Name;
            existingBuilding.Description = request.Description;
            existingBuilding.AddressInDetails = request.AddressInDetails;
            existingBuilding.MapSearchText = request.MapSearchText;
            existingBuilding.Type = request.Type;
            existingBuilding.VillageId = request.VillageId;

            var updatedBuilding = await _buildingService.UpdateAsync(existingBuilding);

            var response = new GetBuildingByIdResponse
            {
                BuildingId = updatedBuilding.BuildingId,
                Name = updatedBuilding.Name,
                Description = updatedBuilding.Description,
                Address = updatedBuilding.AddressInDetails,
                MapSearchText = updatedBuilding.MapSearchText,
                Type = updatedBuilding.Type.ToString(),
                VillageName = village.NameEn
            };

            return Success(response, string.Format(SharedResourcesKeys.Updated, nameof(Building)));
        }

        public async Task<Response<bool>> Handle(DeleteBuildingCommand request, CancellationToken cancellationToken)
        {
            var searchedBuilding = await _buildingService.GetAsync(request.BuildingId);
            if (searchedBuilding == null)
                return BadRequest<bool>(string.Format(SharedResourcesKeys.NotFound, nameof(Building)));

            var isDeleted = await _buildingService.DeleteAsync(searchedBuilding);
            return isDeleted
                ? Deleted<bool>(string.Format(SharedResourcesKeys.Deleted, nameof(Building)))
                : InternalServerError<bool>();
        }

        #endregion
    }
}

