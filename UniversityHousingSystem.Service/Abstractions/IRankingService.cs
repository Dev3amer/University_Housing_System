using UniversityHousingSystem.Data.Entities;

namespace UniversityHousingSystem.Service.Abstractions
{
    public interface IRankingService
    {
        public Task<double> CalculateNewStudentScore(NewStudent newStudent);
        public Task<double> CalculateOldStudentScore(OldStudent oldStudent);
    }

}