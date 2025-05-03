using Microsoft.EntityFrameworkCore;
using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Infrastructure.Repositories;
using UniversityHousingSystem.Service.Abstractions;
using UniversityHousingSystem.Service.Abstractions.Helpers;

namespace UniversityHousingSystem.Service.implementation
{
    public class RankingService : IRankingService
    {
        private readonly IDistanceService _distanceService;
        private readonly IVillageRepository _villageRepository;

        public RankingService(IDistanceService distanceService, IVillageRepository villageRepository)
        {
            _distanceService = distanceService;
            _villageRepository = villageRepository;
        }

        public async Task<double> CalculateNewStudentScore(NewStudent newStudent)
        {
            double score = 0;

            var student = newStudent.Student;

            // 1. Housing history fallback
            score += 30;

            // 2. Distance
            score += await CalculateDistanceScore(student);

            // 3. Special needs
            if (student.HasSpecialNeeds)
                score += 70;

            // 4. High School Grade
            score += (double)newStudent.HighSchoolPercentage * 0.3;

            // 5. Age
            int age = CalculateAge(student.BirthDate);
            score += Math.Max(0, 100 - age);

            return score;
        }

        public async Task<double> CalculateOldStudentScore(OldStudent oldStudent)
        {
            double score = 0;

            var student = oldStudent.Student;

            // 1. Housing history
            score += oldStudent.PreviousYearHosting ? 100 : 50;

            // 2. Distance
            score += await CalculateDistanceScore(student);

            // 3. Special needs
            if (student.HasSpecialNeeds)
                score += 70;

            // 4. GPA
            if (!oldStudent.PreviousYearHosting)
                score += (double)oldStudent.GradePercentage * 0.5;

            return score;
        }

        private async Task<double> CalculateDistanceScore(Student student)
        {
            var village = await _villageRepository.GetTableNoTracking()
                .Include(v => v.City)
                .ThenInclude(c => c.Governorate)
                .FirstOrDefaultAsync(v => v.VillageId == student.Village.VillageId);

            string studentAddress = student.Country.CountryId != 50
                ? student.Country.NameEn
                : village.NameAr + ", " + village.City.Governorate.NameAr;

            var universityAddress = "بنها, مصر";
            var distance = await _distanceService.GetDrivingDistanceInKmAsync(studentAddress, universityAddress);
            return Math.Min(distance.Value, 100);
        }

        private int CalculateAge(DateOnly birthDate)
        {
            var today = DateTime.Today;
            var age = today.Year - birthDate.Year;
            if (birthDate.ToDateTime(new TimeOnly(0, 0)) > today.AddYears(-age)) age--;
            return age;
        }
    }
}
