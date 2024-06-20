using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flights_Mock_API.Data;
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
        private List<FlightModel> _flightsList;

        public FlightsController(DbContext dbContext)
        {
            _flightsList = dbContext.data;
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

        // POST: api/Flights/Add
        [HttpPost("Add")]
        public ActionResult<FlightModel> Post([FromBody] FlightDtoModel flight)
        {
            var newFlight = new FlightModel
            {
                ArrivalIata = flight.ArrivalIata,
                FlightNumber = new Random().Next(1000, 2000),
                PlaneRab = flight.PlaneRab,
                Sales = flight.Sales,
                Schedule = flight.Schedule,
                Status = flight.Status
            };
            
            _flightsList.Add(newFlight);
            return CreatedAtAction("Get", new { flightNumber = newFlight.FlightNumber }, newFlight);
        }
        
        [HttpPatch("CheckSeats/{id}/{operation}/{newSeats}")]
        public string PatchSeats(int? id, string? operation, int? newSeats)
        {
            
            bool _opCheck;
            if(operation != "Cancel" && operation != "Sell")
            {
                _opCheck = false;
            }
            else
            {
                _opCheck = true;
            }
            if (id == null || newSeats < 0 || _opCheck != true)
            {
                return "Unavaliable Id, Operation or Seat Numbers";
            }
            
            var flight = _flightsList.FirstOrDefault(p => p.FlightNumber == id);
            if (flight == null)
            {
                return "The flight doesn't exists";
            }

            if (flight.Status == false)
            {
                return $"The Flight isn't avaliable for some reason, try /ChangeStatus/{id}";
            }

            // Checking the avaliable seats
            int _num = 0;
            switch (operation)
            {
                case "Cancel":
                    flight.Sales += (newSeats ?? 0);
                    break;
                case "Sell":
                    flight.Sales -= (newSeats ?? 0);
                    break;
            }

            return "ok";
        }
    }
}
