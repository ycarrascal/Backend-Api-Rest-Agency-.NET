

using Microsoft.AspNetCore.Mvc;
using Agency.Entities.Interfaces;
using Agency.Entities.Models.Request;
using FluentValidation;
using Agency.Bussiness.Validators;
using System;
using System.ComponentModel.DataAnnotations;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JourneyController : ControllerBase
    {
       
        private readonly IFlightFiltered FlightFiltered;
        private readonly ITotalCalculator totalCalculator;
        private readonly IBuildJson buildJson;
        private readonly ILogger<JourneyController> logger;
        private readonly IValidator<RequestJourney> validator;



        public JourneyController(
          
            ILogger<JourneyController> logger,
            IFlightFiltered flightFiltered,
            ITotalCalculator totalCalculator,
            IBuildJson buildJson,
            IValidator<RequestJourney> validator
            )
        {
           
            this.logger = logger;
            this.FlightFiltered = flightFiltered;
            this.totalCalculator = totalCalculator;
            this.buildJson = buildJson;
            this.validator = validator;
           
        }

 
        [HttpPost]
       
        public async Task<IActionResult> GetFlightsAsync([FromBody] RequestJourney request)
        {
            try
            {

                var validationResult = validator.Validate(request);
                if (!validationResult.IsValid){ return BadRequest(validationResult.Errors);}

                var flights = await this.FlightFiltered.GetFilteredFlight(request);
                var total = this.totalCalculator.GetTotalPriceCalcultor(flights);
                var journeyJson = this.buildJson.BuildJourney(request, total, flights);

                this.logger.LogInformation("Endpoint succses Flight[]");
                return Ok(journeyJson);
            }
            catch(Exception ex)
            {
                this.logger.LogError(ex, "Failed to get flights");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            
        }
   
    }
}
