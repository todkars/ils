using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Security.Policy;

namespace ILSmartWebServiceClient.WebApi
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }

    public class GovernmentDataReport
    {
        public string NSN { get; set; }

        public string NSNDescription { get; set; }

        public string AMSC { get; set; }

        public string FirstAwardDate { get; set; }

        public string LastAwardDate { get; set; }

        public decimal? LastAwardPrice { get; set; }

        public string LastAwardQty { get; set; }

        public int TotalContracts { get; set; }

        public int TotalQuantity { get; set; }

        public int TotalWins { get; set; }

        public int RecentWins { get; set; }

        public int WinsPercentage { get; set; }

        public int LosesPercentage { get; set; }

        public int RecentWinsPercentage {get; set;}

        public int Dla2YrDemand { get; set; }

        public string DLAOffice { get; set; }

        public int PotentialSales { get; set; }


    }
}