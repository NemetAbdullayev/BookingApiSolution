using BookingApi.Models;

namespace BookingApi.Services.Abstract
{
    public interface IHomeAvailabilityService
    {
        Task<List<Home>> GetAvailableHomesAsync(DateOnly startDate, DateOnly endDate);
    }
}
