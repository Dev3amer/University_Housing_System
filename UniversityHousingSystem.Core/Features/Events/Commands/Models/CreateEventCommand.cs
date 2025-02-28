using MediatR;
using UniversityHousingSystem.Core.Features.Events.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;

namespace UniversityHousingSystem.Core.Features.Events.Commands.Models
{
    public class CreateEventCommand : IRequest<Response<GetEventByIdResponse>>
    {
        public string Title { get; set; } = default!;
        public DateTime Date { get; set; }
        public string? Description { get; set; }
        public string CreatedBy { get; set; } = default!;
    }
}
