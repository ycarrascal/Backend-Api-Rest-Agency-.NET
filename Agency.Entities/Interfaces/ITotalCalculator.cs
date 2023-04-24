using Agency.Entities.Models;


namespace Agency.Entities.Interfaces
{
    public interface ITotalCalculator
    {
        decimal GetTotalPriceCalcultor(List<Flight> flights);
    }
}
