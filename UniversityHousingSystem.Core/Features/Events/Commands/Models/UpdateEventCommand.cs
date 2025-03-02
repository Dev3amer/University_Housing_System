using MediatR;
using UniversityHousingSystem.Core.Features.Events.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;

namespace UniversityHousingSystem.Core.Features.Events.Commands.Models
{
    public class UpdateEventCommand : IRequest<Response<GetEventByIdResponse>>
    {
        public int EventId { get; set; }
        public string Title { get; set; } = default!;
        public DateTime Date { get; set; }
        public string? Description { get; set; }
    }
}
