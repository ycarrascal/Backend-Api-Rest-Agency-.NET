using Agency.Entities.Enun;
using Agency.Entities.Interfaces;
using Agency.Entities.Models;
using Agency.Entities.Models.Request;
using Newtonsoft.Json;

namespace APIResfault.Application.Services
{
    public class BuildJsonService : IBuildJson
    {
        public BuildJsonService()
        {
        }
        public string BuildJourney(RequestJourney request, decimal total, List<Flight> flights)
        {

            var flightDTOList = flights.Select(flight => new FlightDTO
            {
                Origin = flight.DepartureStation,
                Destination = flight.ArrivalStation,
                Price = (double)flight.Price,
                Transport = new Transport
                {
                    FlightCarrier = flight.FlightCarrier,
                    FlightNumber = flight.FlightNumber,
                }
            }).ToList();

            var journey = new Journey
            {
                Origin = request.DepartureStation,
                Destination = request.ArrivalStation,
                Price = (double)total,
                Flights = flightDTOList
            };
           
            var JourneyResponse = new JourneyResponse
            {
                Journey = journey
            };
            return JsonConvert.SerializeObject(JourneyResponse, Formatting.Indented);
        }

    }
}

