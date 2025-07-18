using BookingApi.Models;
using BookingApi.Repositories.Abstract;
using BookingApi.Services.Abstract;

namespace BookingApi.Services.Concrete
{
    public class HomeAvailabilityService : IHomeAvailabilityService
    {
        private readonly IHomeRepository _homeRepository;

        public HomeAvailabilityService(IHomeRepository homeRepository)
        {
            _homeRepository = homeRepository;
        }

        public async Task<List<Home>> GetAvailableHomesAsync(DateOnly startDate, DateOnly endDate)
        {
            var requestedDates = Enumerable.Range(0, (endDate.DayNumber - startDate.DayNumber + 1))
                .Select(i => startDate.AddDays(i))
                .ToHashSet();

            var allHomes = await _homeRepository.GetAllHomesAsync();

            return allHomes
                .Where(home => requestedDates.All(date => home.AvailableSlots.Contains(date)))
                .Select(home => new Home
                {
                    HomeId = home.HomeId,
                    HomeName = home.HomeName,
                    AvailableSlots = home.AvailableSlots.Where(date => requestedDates.Contains(date)).ToHashSet()
                })
                .ToList();
        }
    }
}