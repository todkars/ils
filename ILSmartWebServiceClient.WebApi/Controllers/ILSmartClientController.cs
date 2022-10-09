using ILSmartServiceReference;
using ILSmartWebServiceClient.Data;
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

        [Route("[action]/{govtFilesToSearch}/{partNumber}")]
        [HttpGet]
        public async Task<GetGovernmentDataResponseBody> GetGovernmentData([FromRoute] string govtFilesToSearch, [FromRoute] string partNumber)
        {
            return await _ilSmarWebServiceClientService.GetGovernmentDataAsync(new string[] { govtFilesToSearch }, partNumber, "WEBSERVICETEST", "TESTU01");
        }

        [Route("[action]/{cage}")]
        [HttpGet]
        public async Task<GetCageContactResponseBody> GetCageContact([FromRoute] string cage)
        {
            return await _ilSmarWebServiceClientService.GetCageContactAsync(cage, "WEBSERVICETEST", "TESTU01");
        }

        [Route("[action]/{partNumber}")]
        [HttpGet]
        public async Task<GetNiinsByPartResponseBody> GetNiinsByPart([FromRoute] string partNumber)
        {
            return await _ilSmarWebServiceClientService.GetNiinsByPartAsync(partNumber, "WEBSERVICETEST", "TESTU01");
        }
    }
}