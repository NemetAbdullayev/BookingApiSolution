BookingApiSolution is a solution that contains a .NET 8 Web API for retrieving available homes based on a date range. Data is stored in memory using ConcurrentDictionary, and the filtering logic is implemented asynchronously and tested with integration tests.
1.  Clone the repository:
 Open a terminal or Git Bash and run:
git clone https://github.com/NemetAbdullayev/BookingApiSolution.git
2. Open the Solution in Visual Studio
• Open Visual Studio 2022.
• Go to File > Open > Project/Solution.
• Navigate to the cloned folder and open: BookingApiSolution.sln
   3. Set the Startup Project
• In Solution Explorer, right-click on the 'BookingApi' project.
• Select 'Set as Startup Project'.
4. Run the Application
• Press F5 or click the green 'Run' button.
• The API will launch in your default browser.
5. Open Swagger UI in browser:
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
6.Architecture
- Controllers: Handle HTTP requests and responses.
- Services: Contain the filtering logic and business rules.
- Repositories: Store in-memory home and slot data using ConcurrentDictionary.
- Models: Define the structure of data (Home, AvailableSlots).
  
7.Integration tests are included to validate the actual behavior of the `/api/available-homes` endpoint under real HTTP conditions using WebApplicationFactory.
- Ensure correct filtering of homes based on full date range availability.
- Validate proper HTTP status codes (200 OK, 400 Bad Request).
- Confirm the structure and content of the returned JSON.
   xUnit — unit testing framework
- Microsoft.AspNetCore.Mvc.Testing — for hosting the API in memory
- System.Text.Json.Nodes — for parsing and asserting JSON response
- public class AvailableHomesTests : IClassFixture<WebApplicationFactory<Program>>

  8.How to Run the Tests
  Open the Test Explorer window (Test > Test Explorer).
  Find the tests under the BookingApi.Tests
  Click 'Run All Tests In View' to execute the tests



