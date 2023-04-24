using Agency.Entities.Interfaces;
using Agency.Entities.Models;


namespace APIResfault.Application.Services
{
    public class PriceCalculatorService : ITotalCalculator
    {

        public PriceCalculatorService()
        {

        }

        public decimal GetTotalPriceCalcultor(List<Flight> flights)
        {
            return flights.Sum(flight => flight.Price);
        }

    }
}
