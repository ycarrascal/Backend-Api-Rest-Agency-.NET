using Agency.Entities.Models;

namespace Agency.Entities.Interfaces
{
    public interface IFlight
    {
        Task<List<Flight>> GetAllFlightAsync();
    }
}
