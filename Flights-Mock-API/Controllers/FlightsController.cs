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
        private List<FlightModel> _flightsList = new();

        public FlightsController()
        {
            _flightsList.Add(new FlightModel
            {
                FlightNumber = 1277,
                ArrivalIata = "VCP",
                PlaneRab = "LKJGCV",
                Sales = 25,
                Schedule = "12/08/2024",
                Status = true
            });
            
            _flightsList.Add(new FlightModel
            {
                FlightNumber = 1300,
                ArrivalIata = "GRU",
                PlaneRab = "JKSLDJ",
                Sales = 12,
                Schedule = "12/07/2024",
                Status = true
            });
            
            _flightsList.Add(new FlightModel
            {
                FlightNumber = 1355,
                ArrivalIata = "GRU",
                PlaneRab = "LKJGCV",
                Sales = 0,
                Schedule = "30/06/2024",
                Status = false
            });
            
            _flightsList.Add(new FlightModel
            {
                FlightNumber = 1401,
                ArrivalIata = "GAL",
                PlaneRab = "CQRPOU",
                Sales = 45,
                Schedule = "20/10/2024",
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
        [HttpGet("{flightNumber}", Name = "Get")]
        public ActionResult<string> Get(int flightNumber)
        {
            var flight = _flightsList.SingleOrDefault(flight => flight.FlightNumber == flightNumber);
            
            if (flight == null)
            {
                return NotFound();
            }
            return JsonConvert.SerializeObject(flight, Formatting.Indented);
        }

        // POST: api/Flights
        [HttpPost]
        public ActionResult<FlightModel> Post([FromBody] FlightModel flight)
        {
            _flightsList.Add(flight);
            return CreatedAtAction("Get", new { flightNumber = flight.FlightNumber }, flight);
        }

        // PUT: api/Flights/5
        [HttpPatch("{flightNumber}")]
        public ActionResult Put(int flightNumber, [FromBody] bool status)
        {
            var flight = _flightsList.SingleOrDefault(flight => flight.FlightNumber == flightNumber);

            if (flight == null)
            {
                return NotFound();
            }
            
            flight.Status = status;
            return NoContent(); 
        }
    }
}
