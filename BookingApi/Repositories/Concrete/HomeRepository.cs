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
            var home1 = new Home
            {
                HomeId = "123",
                HomeName = "Home 1",
                AvailableSlots = new HashSet<DateOnly>
            {
                new DateOnly(2025,7,15),
                new DateOnly(2025,7,16),
                new DateOnly(2025,7,17)
            }
            };

            var home2 = new Home
            {
                HomeId = "456",
                HomeName = "Home 2",
                AvailableSlots = new HashSet<DateOnly>
            {
                new DateOnly(2025,7,17),
                new DateOnly(2025,7,18)
            }
            };

            _homes.TryAdd(home1.HomeId, home1);
            _homes.TryAdd(home2.HomeId, home2);
        }

        public Task<List<Home>> GetAllHomesAsync()
        {
            return Task.FromResult(_homes.Values.ToList());
        }
    }
}