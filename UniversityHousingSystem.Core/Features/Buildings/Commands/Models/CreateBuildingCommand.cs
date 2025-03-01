using MediatR;
using UniversityHousingSystem.Core.Features.Events.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;
using UniversityHousingSystem.Data.Helpers.Enums;

namespace UniversityHousingSystem.Core.Features.Events.Commands.Models
{
    public class CreateBuildingCommand : IRequest<Response<GetBuildingByIdResponse>>
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public string AddressInDetails { get; set; } = default!;
        public string? MapSearchText { get; set; }
        public EnBuildingType Type { get; set; }
        public int VillageId { get; set; }
    }
}
