using ILSmartServiceReference;
using ILSmartWebServiceClient.Data;
using ILSmartWebServiceClient.Data.Database;
using ILSmarWebServiceClient.LIbrary;
using Microsoft.AspNetCore.Mvc;

namespace ILSmartWebServiceClient.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        private readonly RepositoryClass _repositoryClass;

        private readonly Class1 _class1;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            RepositoryClass repositoryClass,
            Class1 class1)
        {
            _class1 = class1;
            _repositoryClass = repositoryClass;
            _logger = logger;
        }

        //[HttpGet(Name = "GetWeatherForecast")]
        [HttpGet]
        [Route("GetWeatherForecast")]
        public IEnumerable<WeatherForecast> GetWeatherForecast()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        [Route("GetPreferedVendorGroups")]
        //[HttpGet(Name = "GetPreferedVendorGroups")]
        public async Task<GetPreferredVendorGroupsResponseBody?> GetPreferedVendorGroups()
        {
            var res = _repositoryClass.GetProcurementdtos();
            return await _class1.GetPreferredVendorGroupsAsync();
        }
    }
}