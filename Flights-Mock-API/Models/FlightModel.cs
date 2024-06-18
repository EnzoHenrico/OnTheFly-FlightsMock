using Newtonsoft.Json;

namespace Flights_Mock_API.Models;

public class FlightModel
{
    [JsonProperty("flight_number")] public int FlightNumber { get; set; }
    [JsonProperty("arrival_airport_iata")] public string ArrivalAirportIata { get; set; }
    [JsonProperty("plane_rab_code")] public string PlaneRabCode { get; set; }
    [JsonProperty("scheduled_date")] public string ScheduledDate { get; set; }
    [JsonProperty("available_seats")] public int Sales { get; set; }
    [JsonProperty("status")] public bool Status { get; set; }
}