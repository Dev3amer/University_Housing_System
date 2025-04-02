using MediatR;
using UniversityHousingSystem.Core.Features.Events.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;
using UniversityHousingSystem.Data.Helpers.Enums;

namespace UniversityHousingSystem.Core.Features.Events.Commands.Models
{
    public class UpdateCollegeCommand : IRequest<Response<GetCollegeByIdResponse>>
    {
        public int CollegeId { get; set; }
        public string Name { get; set; } = default!;
      //  public List<string>? Departments { get; set; }

    }
}
