using System.Net;

namespace UniversityHousingSystem.Core.ResponseBases
{
    public class Response<T>
    {
        public Response()
        {

        }

        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
        public bool Succeeded { get; set; }
        public object? Meta { get; set; }
        public List<string>? Errors { get; set; }
        public T? Data { get; set; }
    }
}
