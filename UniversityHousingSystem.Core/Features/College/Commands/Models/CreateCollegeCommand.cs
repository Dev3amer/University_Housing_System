using MediatR;
using UniversityHousingSystem.Core.Features.Events.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;
using UniversityHousingSystem.Data.Helpers.Enums;

namespace UniversityHousingSystem.Core.Features.Events.Commands.Models
{
    public class CreateCollegeCommand : IRequest<Response<GetCollegeByIdResponse>>
    {
        //  public int GuardianId { get; set; }
        public string Name { get; set; } = default!;
      //  public List<string>? Departments { get; set; }
    }
}
