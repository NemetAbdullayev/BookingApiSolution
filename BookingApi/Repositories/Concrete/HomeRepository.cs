using BookingApi.Models;
using BookingApi.Repositories.Abstract;
using System.Collections.Concurrent;

namespace BookingApi.Repositories.Concrete
{
    public class HomeRepository : IHomeRepository
    {
        private readonly ConcurrentDictionary<string, Home> _homes = new();

        public HomeRepository()
        {
            var homes = new[]
            {
                new Home
                {
                    HomeId = "123",
                    HomeName = "Home 1",
                    AvailableSlots = new HashSet<DateOnly>
                    {
                        new(2025, 7, 15),
                        new(2025, 7, 16),
                        new(2025, 7, 17)
                    }
                },
                new Home
                {
                    HomeId = "456",
                    HomeName = "Home 2",
                    AvailableSlots = new HashSet<DateOnly>
                    {
                        new(2025, 7, 17),
                        new(2025, 7, 18)
                    }
                }
            };

            foreach (var home in homes)
                _homes.TryAdd(home.HomeId, home);
        }

        public Task<List<Home>> GetAllHomesAsync()
        {
            return Task.FromResult(_homes.Values.ToList());
        }
    }
}