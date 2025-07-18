using BookingApi.Models;

namespace BookingApi.Repositories.Abstract
{
    public interface IHomeRepository
    {
        Task<List<Home>> GetAllHomesAsync();

    }
}
