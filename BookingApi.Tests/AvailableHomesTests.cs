using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net;
using System.Text.Json.Nodes;

namespace BookingApi.Tests
{
    public class AvailableHomesTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public AvailableHomesTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task ShouldReturnHome1_ForDates_2025_07_15_to_2025_07_16()
        {
            var url = "/api/available-homes?startDate=2025-07-15&endDate=2025-07-16";

            var response = await _client.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var body = await response.Content.ReadAsStringAsync();
            var json = JsonNode.Parse(body);
            var homes = json?["homes"]?.AsArray();

            Assert.NotNull(homes);
            Assert.Single(homes);
            Assert.Equal("123", homes[0]?["homeId"]?.ToString());
            Assert.Equal("Home 1", homes[0]?["homeName"]?.ToString());
        }

        [Fact]
        public async Task ShouldReturnEmpty_WhenDateRangeNotFullyCovered()
        {
            var url = "/api/available-homes?startDate=2025-07-15&endDate=2025-07-18";

            var response = await _client.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var body = await response.Content.ReadAsStringAsync();
            var json = JsonNode.Parse(body);
            var homes = json?["homes"]?.AsArray();

            Assert.NotNull(homes);
            Assert.Empty(homes);
        }

        [Fact]
        public async Task ShouldReturnBadRequest_IfStartDateGreaterThanEndDate()
        {
            var url = "/api/available-homes?startDate=2025-07-18&endDate=2025-07-15";

            var response = await _client.GetAsync(url);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }

}