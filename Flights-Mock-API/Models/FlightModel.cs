﻿using Newtonsoft.Json;

namespace Flights_Mock_API.Models;

public class FlightModel
{
    [JsonProperty("flightNumber")] public int FlightNumber { get; set; }
    [JsonProperty("arrivalIata")] public string ArrivalIata { get; set; }
    [JsonProperty("planeRab")] public string PlaneRab { get; set; }
    [JsonProperty("sales")] public int Sales { get; set; }
    [JsonProperty("status")] public bool Status { get; set; }
    [JsonProperty("schedule")] public string Schedule { get; set; }
}