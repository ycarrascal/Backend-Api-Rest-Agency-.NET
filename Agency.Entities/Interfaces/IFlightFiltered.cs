using Agency.Entities.Models;
using Agency.Entities.Models.Request;


namespace Agency.Entities.Interfaces
{
    public interface IFlightFiltered
    {
        Task<List<Flight>> GetFilteredFlight(RequestJourney request);
    }
}
