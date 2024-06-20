using Flights_Mock_API.Models;

namespace Flights_Mock_API.Data;

public class DbContext
{
    public List<FlightModel> data = new()
    {
        new FlightModel
        {
            FlightNumber = 1277,
            ArrivalIata = "VCP",
            PlaneRab = "LKJGCV",
            Sales = 25,
            Schedule = "12/08/2024",
            Status = true
        },
        new FlightModel
        {
            FlightNumber = 1300,
            ArrivalIata = "GRU",
            PlaneRab = "JKSLDJ",
            Sales = 12,
            Schedule = "12/07/2024",
            Status = true
        },
        new FlightModel
        {
            FlightNumber = 1355,
            ArrivalIata = "GRU",
            PlaneRab = "LKJGCV",
            Sales = 0,
            Schedule = "30/06/2024",
            Status = false
        },

        new FlightModel
        {
            FlightNumber = 1401,
            ArrivalIata = "GAL",
            PlaneRab = "CQRPOU",
            Sales = 45,
            Schedule = "20/10/2024",
            Status = true
        }
    };
}