
namespace Agency.Entities.Models
{
    public class Journey
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public double Price { get; set; }
        public List<FlightDTO> Flights { get; set; }
    
     }
}
