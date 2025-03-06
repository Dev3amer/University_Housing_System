using Microsoft.EntityFrameworkCore;
using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Infrastructure.Context;
using UniversityHousingSystem.Infrastructure.GenericBases;
using UniversityHousingSystem.Infrastructure.Migrations;
using UniversityHousingSystem.Infrastructure.Repositories;

namespace UniversityHousingSystem.Infrastructure.implementation
{
    public class RoomPhotoRepository : GenericRepositoryAsync<RoomPhoto>, IRoomPhotoRepository
    {
        private readonly AppDbContext _context;

        public RoomPhotoRepository(AppDbContext context)
            : base(context)  // Pass the context to the base class
        {
            _context = context;
        }

        public async Task DeleteAsync(RoomPhoto roomPhoto)
        {
            _context.RoomPhotos.Remove(roomPhoto);
            await _context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
