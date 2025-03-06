using Microsoft.EntityFrameworkCore;
using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Data.Helpers.Enums;
using UniversityHousingSystem.Infrastructure.implementation;
using UniversityHousingSystem.Infrastructure.Repositories;
using UniversityHousingSystem.Service.Abstractions;

namespace UniversityHousingSystem.Service.Implementation
{
    public class BuildingService : IBuildingService
    {
        #region Fields
        private readonly IBuildingRepository _buildingRepository;
        private readonly IRoomRepository _roomRepository;
        #endregion

        #region Constructors
        public BuildingService(IBuildingRepository buildingRepository, IRoomRepository roomRepository )
        {
            _buildingRepository = buildingRepository;
            _roomRepository = roomRepository;
             
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
        //public async Task<bool> DeleteAsync(Building buildingToDelete)
        //{
        //    _buildingRepository.BeginTransaction();
        //    try
        //    {
        //        await _buildingRepository.DeleteAsync(buildingToDelete);
        //        _buildingRepository.Commit();
        //        return true;
        //    }
        //    catch
        //    {
        //        _buildingRepository.RollBack();
        //        return false;
        //    }
        //}
        //3/6


        public async Task<bool> DeleteAsync(Building buildingToDelete)
        {
            _buildingRepository.BeginTransaction(); // ✅ Start transaction
            try
            {
                // ✅ Step 1: Get all rooms in this building
                var rooms = await _roomRepository.GetTableAsTracking()
                                                 .Where(r => r.BuildingId == buildingToDelete.BuildingId)
                                                 .Include(r => r.Students) // ✅ Include Students
                                                 .Include(r => r.RoomPhotos) // ✅ Include Photos
                                                 .ToListAsync();

                if (rooms.Any())
                {
                    foreach (var room in rooms)
                    {
                        // ✅ Step 2: Disassociate students from the room
                        if (room.Students.Any())
                        {
                            foreach (var student in room.Students)
                            {
                                student.RoomId = null; // ❌ Remove room assignment (but don't delete student)
                            }
                        }

                        // ✅ Step 3: Delete the room (Photos will be removed via cascade delete)
                        await _roomRepository.DeleteAsync(room);
                    }
                }

                // ✅ Step 4: Delete the building after all rooms are gone
                await _buildingRepository.DeleteAsync(buildingToDelete);

                _buildingRepository.Commit(); // ✅ Commit transaction
                return true;
            }
            catch
            {
                _buildingRepository.RollBack(); // ❌ Rollback if something fails
                return false;
            }
        }


        #endregion
    }
}
