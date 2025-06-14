﻿namespace UniversityHousingSystem.Data.Entities
{
    public class RegistrationPeriod
    {
        public int Id { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public bool IsClosed { get; set; }
        public decimal RegistrationFees { get; set; }
        public int AvailableMaleSpaces { get; set; }
        public int AvailableFemaleSpaces { get; set; }
        public ICollection<Student>? Students { get; set; }
    }
}
