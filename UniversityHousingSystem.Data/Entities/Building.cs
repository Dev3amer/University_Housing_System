using UniversityHousingSystem.Data.Helpers.Enums;

namespace UniversityHousingSystem.Data.Entities
{
    public class Building
    {
        public int BuildingId { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }

        public string AddressInDetails { get; set; } = default!;
        public string? MapIFrame { get; set; }
        public EnBuildingType Type { get; set; }

        // Foreign Keys
        public int VillageId { get; set; }

        // Navigation Property
        public Village Village { get; set; } = default!;
        public ICollection<Room> Rooms { get; set; } = new HashSet<Room>();
    }
}
