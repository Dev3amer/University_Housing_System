using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Data.Helpers.Enums;
using UniversityHousingSystem.Service.Abstractions;

namespace UniversityHousingSystem.Service.implementation
{
    public class StudentHousingService : IStudentHousingService
    {
        public void AssignStudentsToRooms(IEnumerable<Student> acceptedStudents, ICollection<Room> allRooms)
        {
            var groupedByPreference = acceptedStudents
                .Where(s => s.FavRoom.HasValue)
                .GroupBy(s => s.FavRoom.Value)
                .ToList();

            HashSet<int> assignedStudentIds = new();

            // Assign by preferred room
            foreach (var group in groupedByPreference)
            {
                int roomId = group.Key;
                Room? room = allRooms.FirstOrDefault(r => r.RoomId == roomId);
                if (room == null || !RoomAllowsGender(room, group.First().Gender)) continue;

                var currentOccupants = room.Students?.Count ?? 0;
                int availableSpots = room.Capacity - currentOccupants;
                if (availableSpots <= 0) continue;

                var candidates = group.Where(s => !assignedStudentIds.Contains(s.StudentId)).ToList();

                if (candidates.Count <= availableSpots)
                {
                    foreach (var student in candidates)
                    {
                        AssignStudentToRoom(student, room);
                        assignedStudentIds.Add(student.StudentId);
                    }
                }
                else
                {
                    var selected = SelectMostCompatibleGroup(candidates, availableSpots);
                    foreach (var student in selected)
                    {
                        AssignStudentToRoom(student, room);
                        assignedStudentIds.Add(student.StudentId);
                    }
                }
            }

            // Assign remaining students to any available room of same gender
            var unassignedStudents = acceptedStudents
                .Where(s => !assignedStudentIds.Contains(s.StudentId))
                .ToList();

            foreach (var student in unassignedStudents)
            {
                Room? bestRoom = FindBestAvailableRoom(student, allRooms);
                if (bestRoom != null)
                {
                    AssignStudentToRoom(student, bestRoom);
                    assignedStudentIds.Add(student.StudentId);
                }
            }
        }

        private void AssignStudentToRoom(Student student, Room room)
        {
            student.RoomId = room.RoomId;
            room.Students ??= new List<Student>();
            room.Students.Add(student);
        }

        private bool RoomAllowsGender(Room room, EnGender gender)
        {
            var building = room.Building;
            if (building == null || building.Sex != gender)
                return false; // Building doesn't allow this gender

            if (room.Students == null || room.Students.Count == 0)
                return true; // Empty room in correct-gender building

            return room.Students.All(s => s.Gender == gender);
        }

        private List<Student> SelectMostCompatibleGroup(List<Student> students, int groupSize)
        {
            var bestGroup = new List<Student>();
            int bestScore = int.MinValue;

            var combinations = GetCombinations(students, groupSize);

            foreach (var group in combinations)
            {
                int score = GetGroupCompatibilityScore(group);
                if (score > bestScore)
                {
                    bestScore = score;
                    bestGroup = group.ToList();
                }
            }

            return bestGroup;
        }

        private int GetGroupCompatibilityScore(IEnumerable<Student> group)
        {
            int score = 0;
            var list = group.ToList();
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    score += CalculatePairCompatibility(list[i], list[j]);
                }
            }
            return score;
        }

        private int CalculatePairCompatibility(Student s1, Student s2)
        {
            int score = 0;
            if (s1.AcademicYear == s2.AcademicYear) score += 2;
            if (s1.CollegeId == s2.CollegeId) score += 2;
            if (s1.Gender == s2.Gender) score += 1;
            if (s1.CityId == s2.CityId) score += 1;
            return score;
        }

        private IEnumerable<List<T>> GetCombinations<T>(List<T> list, int length)
        {
            if (length == 0) yield return new List<T>();
            else
            {
                for (int i = 0; i <= list.Count - length; i++)
                {
                    foreach (var tail in GetCombinations(list.Skip(i + 1).ToList(), length - 1))
                    {
                        var result = new List<T> { list[i] };
                        result.AddRange(tail);
                        yield return result;
                    }
                }
            }
        }

        private Room? FindBestAvailableRoom(Student student, ICollection<Room> allRooms)
        {
            Room? favRoom = allRooms.FirstOrDefault(r => r.RoomId == student.FavRoom);
            int? favVillageId = favRoom?.Building?.VillageId;
            int? favBuildingId = favRoom?.BuildingId;

            var sameBuildingRooms = allRooms.Where(r =>
                r.BuildingId == favBuildingId &&
                r.Building.Sex == student.Gender &&
                (r.Students?.Count ?? 0) < r.Capacity &&
                RoomAllowsGender(r, student.Gender)).ToList();

            if (sameBuildingRooms.Any())
                return sameBuildingRooms.OrderBy(r => r.Students?.Count ?? 0).First();

            var sameVillageRooms = allRooms.Where(r =>
                r.Building.VillageId == favVillageId &&
                r.Building.Sex == student.Gender &&
                (r.Students?.Count ?? 0) < r.Capacity &&
                RoomAllowsGender(r, student.Gender)).ToList();

            if (sameVillageRooms.Any())
                return sameVillageRooms.OrderBy(r => r.Students?.Count ?? 0).First();

            return allRooms.FirstOrDefault(r =>
                r.Building.Sex == student.Gender &&
                (r.Students?.Count ?? 0) < r.Capacity &&
                RoomAllowsGender(r, student.Gender));
        }
    }
}
