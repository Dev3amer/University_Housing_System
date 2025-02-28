using MediatR;
using UniversityHousingSystem.Core.ResponseBases;

namespace UniversityHousingSystem.Core.Features.Events.Commands.Models
{
    public class DeleteEventCommand : IRequest<Response<bool>>
    {
        public int EventId { get; set; }
    }
}
