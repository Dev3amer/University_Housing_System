using System.Text.Json;
using UniversityHousingSystem.Service.Abstractions.Helpers;

namespace UniversityHousingSystem.Service.implementation.Helpers
{
    public class DistanceService : IDistanceService
    {
        private readonly HttpClient _httpClient;

        public DistanceService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<double?> GetDrivingDistanceInKmAsync(string fromAddress, string toAddress)
        {
            var fromCoords = await GeocodeAsync(fromAddress);
            var toCoords = await GeocodeAsync(toAddress);

            if (fromCoords is null)
            {
                fromAddress = fromAddress.Substring(fromAddress.IndexOf(",") + 1).Trim();
                fromCoords = await GeocodeAsync(fromAddress);
            }


            if (fromCoords == null || toCoords == null)
                return null;

            string url = $"https://router.project-osrm.org/route/v1/driving/{fromCoords.Value.lng},{fromCoords.Value.lat};{toCoords.Value.lng},{toCoords.Value.lat}?overview=false";

            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
                return null;

            var content = await response.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(content);

            if (doc.RootElement.GetProperty("code").GetString() != "Ok")
                return null;

            var distanceInMeters = doc
                .RootElement
                .GetProperty("routes")[0]
                .GetProperty("distance")
                .GetDouble();

            return distanceInMeters / 1000.0;
        }

        private async Task<(double lat, double lng)?> GeocodeAsync(string address)
        {
            string url = $"https://nominatim.openstreetmap.org/search?format=json&q={Uri.EscapeDataString(address)}";

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("User-Agent", "YourAppName/1.0");

            var response = await _httpClient.SendAsync(request);
            if (!response.IsSuccessStatusCode)
                return null;

            var content = await response.Content.ReadAsStringAsync();
            var json = JsonDocument.Parse(content);

            var results = json.RootElement;
            if (results.GetArrayLength() == 0)
                return null;

            var first = results[0];
            double lat = double.Parse(first.GetProperty("lat").GetString());
            double lng = double.Parse(first.GetProperty("lon").GetString());

            return (lat, lng);
        }
    }

}
