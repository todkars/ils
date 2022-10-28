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
        private const string IlsUseTestUser = "IlsUseTestUser";
        private const string IlsUserId = "IlsUserId";
        private const string IlsUserPwd = "IlsUserPwd";
        private const string IlsTestUserId = "IlsTestUserId";
        private const string IlsTestUserPwd = "IlsTestUserPwd";

        IConfiguration _configuration;

        private readonly ILogger<ILSmartClientController> _logger;

        private readonly ILSmarWebServiceClientService _ilSmarWebServiceClientService;

        public ILSmartClientController(ILogger<ILSmartClientController> logger,
            ILSmartWebServiceClientRepository repositoryClass,
            ILSmarWebServiceClientService class1,
            IConfiguration configuration)
        {
            _ilSmarWebServiceClientService = class1;
            _logger = logger;
            _configuration = configuration;
        }

        [Route("[action]/{govtFilesToSearch}/{partNumber}")]
        [HttpGet]
        public async Task<GetGovernmentDataResponseBody> GetGovernmentData([FromRoute] string govtFilesToSearch, [FromRoute] string partNumber)
        {
            var userDetails = GetUserIdAndPassword();
            return await _ilSmarWebServiceClientService.GetGovernmentDataAsync(new string[] { govtFilesToSearch }, partNumber, userDetails.pwd, userDetails.userId);
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<List<GetGovernmentDataResponseBody>> GetGovernmentDataReportByNsnArray([FromBody] NsnInput multipleNsnInput)
        {
            List<GetGovernmentDataResponseBody> governmentDataReports = new List<GetGovernmentDataResponseBody>();

            foreach (var nsn in multipleNsnInput.NsnArray)
            {
                var userDetails = GetUserIdAndPassword();
                var ilsDataForNsn = await _ilSmarWebServiceClientService.GetGovernmentDataAsync(multipleNsnInput.GovtFilesToSearchArray, nsn, userDetails.pwd, userDetails.userId);
                governmentDataReports.Add(ilsDataForNsn);
            }

            return governmentDataReports;
        }

        private (string userId, string pwd) GetUserIdAndPassword()
        {
            bool ilsUseTestUser = _configuration.GetValue<bool>(IlsUseTestUser);
            string userId, pwd;
            if (ilsUseTestUser)
            {
                userId = _configuration.GetValue<string>(IlsTestUserId);
                pwd = _configuration.GetValue<string>(IlsTestUserPwd);
            }
            else
            {
                userId = _configuration.GetValue<string>(IlsUserId);
                pwd = _configuration.GetValue<string>(IlsUserPwd);
            }

            return (userId, pwd);
        }
    }
}