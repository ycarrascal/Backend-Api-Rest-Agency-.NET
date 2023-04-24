namespace Agency.Data.Services
{
    using Agency.Entities.Enun;
    using Agency.Entities.Interfaces;
    using Agency.Entities.Models;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class FligthsServices : IFlight
    {
        private readonly IConfig config;
        public FligthsServices(IConfig config)
        {
            this.config = config;
        }

        public async Task<List<Flight>> GetAllFlightAsync()
        {
            var apiSettings = new ApiSettings();
            try
            {
                HttpResponseMessage response = await this.config.Get(EnumApiResponse.ApiSettings.ToString(), apiSettings);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                List<Transport> transports = JsonConvert.DeserializeObject<List<Transport>>(responseBody);


                return JsonConvert.DeserializeObject<List<Flight>>(responseBody) ?? throw new ArgumentException("Error: responseBody is null");
            }
            catch (HttpRequestException e)
            {
                throw new HttpRequestException("Error HTTP: " + e.Message);
            }
        }
    }
}
