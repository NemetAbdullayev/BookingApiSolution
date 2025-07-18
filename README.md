Booking API is a .NET Core Web API that allows users to retrieve homes available for a given date range. The data is stored in memory using 'ConcurrentDictionary'. 
•	How to run the application  . Clone the repository:
git clone https://github.com/NemetAbdullayev/BookingApiSolution.git
2. Run the application:
3. Open Swagger UI in browser:
Send a GET request to:
/api/available-homes?startDate=2025-07-15&endDate=2025-07-16
	
Response body
{
  "status": "OK",
  "homes": [
    {
      "homeId": "123",
      "homeName": "Home 1",
      "availableSlots": [
        "2025-07-15",
        "2025-07-16"
      ]
    }
  ]
}
4.Architecture

- Controllers: Handle HTTP requests and responses.
- Services: Contain the filtering logic and business rules.
- Repositories: Store in-memory home and slot data using ConcurrentDictionary.
- Models: Define the structure of data (Home, AvailableSlots).
  
5.Integration tests are included to validate the actual behavior of the `/api/available-homes` endpoint under real HTTP conditions using WebApplicationFactory.
- Ensure correct filtering of homes based on full date range availability.
- Validate proper HTTP status codes (200 OK, 400 Bad Request).
- Confirm the structure and content of the returned JSON.
   xUnit — unit testing framework
- Microsoft.AspNetCore.Mvc.Testing — for hosting the API in memory
- System.Text.Json.Nodes — for parsing and asserting JSON response
- public class AvailableHomesTests : IClassFixture<WebApplicationFactory<Program>>



