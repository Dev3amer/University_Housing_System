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

            // GraphHopper API URL - note the coordinate order is lat,lng (opposite of OSRM)
            string url = $"https://graphhopper.com/api/1/route?point={fromCoords.Value.lat},{fromCoords.Value.lng}&point={toCoords.Value.lat},{toCoords.Value.lng}&profile=car&calc_points=false&key=99381777-669d-40c4-8dd3-1c7528d431b8";

            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
                return null;

            var content = await response.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(content);

            // Check if the request was successful
            if (doc.RootElement.TryGetProperty("message", out var messageElement))
            {
                // Error occurred
                return null;
            }

            // Check if paths array exists and has elements
            if (!doc.RootElement.TryGetProperty("paths", out var pathsElement) ||
                pathsElement.GetArrayLength() == 0)
                return null;

            // Get distance from the first path
            var distanceInMeters = doc
                .RootElement
                .GetProperty("paths")[0]
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
            {
                request = new HttpRequestMessage(HttpMethod.Get, $"https://nominatim.openstreetmap.org/search?format=json&q={Uri.EscapeDataString(address.Substring(0, (address.IndexOf(",") + 1)))}");
            }

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
