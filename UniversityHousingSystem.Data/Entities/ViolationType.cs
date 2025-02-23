using UniversityHousingSystem.Data.Helpers.Enums;

namespace UniversityHousingSystem.Data.Entities
{
    public class ViolationType
    {
        public int ViolationTypeId { get; set; }
        public string? Description { get; set; }
        public EnViolationLevel ViolationLevel { get; set; } = default!;
        public decimal? RequiredAmount { get; set; }

        // Navigation Property
        public ICollection<Violation>? Violations { get; set; }
    }
}
