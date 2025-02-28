using MediatR;
using UniversityHousingSystem.Core.Features.Events.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;

namespace MovieReservationSystem.Core.Features.Movies.Commands.Models
{
    public class EditEventCommand : IRequest<Response<GetEventByIdResponse>>
    {
        public int EventId { get; set; }
        public string Title { get; set; } = default!;
        public DateTime Date { get; set; }
        public string? Description { get; set; }
        public string CreatedBy { get; set; } = default!;
    }
}
