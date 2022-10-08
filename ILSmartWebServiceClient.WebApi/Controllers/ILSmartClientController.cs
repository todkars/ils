using ILSmartServiceReference;
using ILSmartWebServiceClient.Data;
using ILSmartWebServiceClient.Data.Database;
using ILSmarWebServiceClient.LIbrary;
using Microsoft.AspNetCore.Mvc;

namespace ILSmartWebServiceClient.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ILSmartClientController : ControllerBase
    {
        private readonly ILogger<ILSmartClientController> _logger;

        private readonly ILSmarWebServiceClientService _ilSmarWebServiceClientService;

        public ILSmartClientController(ILogger<ILSmartClientController> logger,
            ILSmartWebServiceClientRepository repositoryClass,
            ILSmarWebServiceClientService class1)
        {
            _ilSmarWebServiceClientService = class1;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetGovernmentData")]
        public async Task<GetGovernmentDataResponseBody> GetGovernmentData()
        {           
            return await _ilSmarWebServiceClientService.GetGovernmentDataAsync(new string[] { "MCRL" }, "0JT27-HUPP", "WEBSERVICETEST", "TESTU01");
        }

        [HttpGet]
        [Route("GetCageContact")]
        public async Task<GetCageContactResponseBody> GetCageContact()
        {
            return await _ilSmarWebServiceClientService.GetCageContactAsync("0JT27", "WEBSERVICETEST", "TESTU01");
        }

        [HttpGet]
        [Route("GetNiinsByPart")]
        public async Task<GetNiinsByPartResponseBody> GetNiinsByPart()
        {
            return await _ilSmarWebServiceClientService.GetNiinsByPartAsync("0JT27-HUPP", "WEBSERVICETEST", "TESTU01");
        }
    }
}