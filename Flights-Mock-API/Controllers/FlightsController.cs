using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flights_Mock_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Protocol;

namespace Flights_Mock_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly List<FlightModel> _flightsList = new();

        public FlightsController()
        {
            _flightsList.Add(new FlightModel
            {
                FlightNumber = 1277,
                ArrivalAirportIata = "VCP",
                PlaneRabCode = "LKJGCV",
                Sales = 25,
                ScheduledDate = "12/08/2024",
                Status = true
            });
            
            _flightsList.Add(new FlightModel
            {
                FlightNumber = 1300,
                ArrivalAirportIata = "GRU",
                PlaneRabCode = "JKSLDJ",
                Sales = 12,
                ScheduledDate = "12/07/2024",
                Status = true
            });
            
            _flightsList.Add(new FlightModel
            {
                FlightNumber = 1355,
                ArrivalAirportIata = "GRU",
                PlaneRabCode = "LKJGCV",
                Sales = 0,
                ScheduledDate = "30/06/2024",
                Status = false
            });
            
            _flightsList.Add(new FlightModel
            {
                FlightNumber = 1401,
                ArrivalAirportIata = "GAL",
                PlaneRabCode = "CQRPOU",
                Sales = 45,
                ScheduledDate = "20/10/2024",
                Status = true
            });
        }
        
        // GET: api/Flights
        [HttpGet]
        public string Get()
        {
            return JsonConvert.SerializeObject(_flightsList, Formatting.Indented);
        }

        // GET: api/Flights/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Flights
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Flights/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Flights/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
