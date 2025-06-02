using MediatR;
using UniversityHousingSystem.Core.ResponseBases;

namespace UniversityHousingSystem.Core.Features.Authentication.Queries.Models
{
    public class GetAccessTokenValidityQuery : IRequest<Response<string>>
    {
        public string AccessToken { get; set; } = default!;
    }
}