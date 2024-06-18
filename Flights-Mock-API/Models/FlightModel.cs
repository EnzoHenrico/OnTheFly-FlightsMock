using Newtonsoft.Json;

namespace Flights_Mock_API.Models;

public class FlightModel
{
    [JsonProperty("flight_number")] public int FlightNumber { get; set; }
    [JsonProperty("arrival_iata")] public string ArrivalIata { get; set; }
    [JsonProperty("plane_rab")] public string PlaneRab { get; set; }
    [JsonProperty("sales")] public int Sales { get; set; }
    [JsonProperty("status")] public bool Status { get; set; }
    [JsonProperty("schedule")] public string Schedule { get; set; }
}