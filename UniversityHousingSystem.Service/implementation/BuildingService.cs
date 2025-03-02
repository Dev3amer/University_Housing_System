using Microsoft.EntityFrameworkCore;
using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Data.Helpers.Enums;
using UniversityHousingSystem.Infrastructure.Repositories;
using UniversityHousingSystem.Service.Abstractions;

namespace UniversityHousingSystem.Service.Implementation
{
    public class BuildingService : IBuildingService
    {
        #region Fields
        private readonly IBuildingRepository _buildingRepository;
        #endregion

        #region Constructors
        public BuildingService(IBuildingRepository buildingRepository)
        {
            _buildingRepository = buildingRepository;
        }
        #endregion

        #region Methods

        // ✅ Get all buildings
        public async Task<IEnumerable<Building>> GetAllAsync()
        {
            return await _buildingRepository.GetTableNoTracking()
                .Include(b => b.Village)
                .Include(b => b.Rooms)
                .ToListAsync();
        }

        // ✅ Get buildings by type
        public async Task<IEnumerable<Building>> GetBuildingsByTypeAsync(EnBuildingType type)
        {
            return await _buildingRepository.GetTableNoTracking()
                .Where(b => b.Type == type)
                .Include(b => b.Village)
                .Include(b => b.Rooms)
                .ToListAsync();
        }

        // ✅ Get buildings with optional search and ordering
        public IQueryable<Building> GetAllQueryable(string? search, EnBuildingType? buildingOrderingEnum)
        {
            var queryableList = _buildingRepository.GetTableNoTracking()
                .Include(b => b.Village)
                .AsQueryable();

            // Apply search filter
            if (!string.IsNullOrEmpty(search))
            {
                queryableList = queryableList.Where(b => b.Name.Contains(search));
            }

            // Apply ordering
            if (buildingOrderingEnum.HasValue)
            {
                switch (buildingOrderingEnum.Value)
                {
                    case EnBuildingType.Normal:
                        queryableList = queryableList.OrderBy(b => b.Name);
                        break;
                    case EnBuildingType.Economic:
                        queryableList = queryableList.OrderByDescending(b => b.BuildingId);
                        break;
                    default:
                        queryableList = queryableList.OrderBy(b => b.Name);
                        break;
                }
            }

            return queryableList;
        }

        // ✅ Get a building by ID
        public async Task<Building?> GetAsync(int id)
        {
            return await _buildingRepository.GetTableNoTracking()
                .Include(b => b.Village)
                .Include(b => b.Rooms)
                .FirstOrDefaultAsync(b => b.BuildingId == id);
        }

        // ✅ Create a new building
        public async Task<Building> CreateAsync(Building newBuilding)
        {
            newBuilding.Name = newBuilding.Name.Trim();
            newBuilding.Description = newBuilding.Description?.Trim();

            return await _buildingRepository.AddAsync(newBuilding);
        }

        // ✅ Update an existing building
        public async Task<Building> UpdateAsync(Building buildingToUpdate)
        {
            buildingToUpdate.Name = buildingToUpdate.Name.Trim();
            buildingToUpdate.Description = buildingToUpdate.Description?.Trim();

            return await _buildingRepository.UpdateAsync(buildingToUpdate);
        }

        // ✅ Delete a building
        public async Task<bool> DeleteAsync(Building buildingToDelete)
        {
            _buildingRepository.BeginTransaction();
            try
            {
                await _buildingRepository.DeleteAsync(buildingToDelete);
                _buildingRepository.Commit();
                return true;
            }
            catch
            {
                _buildingRepository.RollBack();
                return false;
            }
        }

        #endregion
    }
}
