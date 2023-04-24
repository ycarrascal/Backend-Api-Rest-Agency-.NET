using Agency.Entities.Models.Request;
using Agency.Entities.Models;


namespace Agency.Entities.Interfaces
{
    public interface IBuildJson
    {
        string BuildJourney(RequestJourney request, decimal total, List<Flight> flights);
    }
}
