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

        [Route("[action]/{govtFilesToSearchArray}/{nsn}")]
        [HttpGet]
        public async Task<List<GovernmentDataReport>> GetGovernmentDataReportByNsn([FromRoute] string[] govtFilesToSearchArray, [FromRoute] string nsn)
        {
            var ilsDataForNsn = await TransFormIlsData(govtFilesToSearchArray[0].Split(","), nsn);

            return ilsDataForNsn;
        }

        [Route("[action]/{govtFilesToSearchArray}/{nsnArraay}")]
        [HttpGet]
        public async Task<List<GovernmentDataReport>> GetGovernmentDataReportByNsnArray([FromRoute] string[] govtFilesToSearchArray, [FromRoute] string[] nsnArraay)
        {
            List<GovernmentDataReport> governmentDataReports = new List<GovernmentDataReport>();

            foreach (string partNumber in nsnArraay[0].Split(","))
            {
                governmentDataReports.AddRange(await TransFormIlsData(govtFilesToSearchArray[0].Split(","), partNumber));
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

        private async Task<List<GovernmentDataReport>> TransFormIlsData(string[] govtFilesToSearch, string partNumber)
        {
            List<GovernmentDataReport> governmentDataReports = new List<GovernmentDataReport>();

            var userDetails = GetUserIdAndPassword();
            var ilsDataForNsn = await _ilSmarWebServiceClientService.GetGovernmentDataAsync(govtFilesToSearch, partNumber, userDetails.pwd, userDetails.userId);

            foreach (var governmentDataSearchResults in ilsDataForNsn.GovernmentSearchResults)
            {
                var nsn = governmentDataSearchResults.Fsc + governmentDataSearchResults.Niin;
                var phData = governmentDataSearchResults.ProcurementHistoryData;
                var nsnInfo = governmentDataSearchResults.NsnInfo;
                var dlaData = governmentDataSearchResults.DlaData;


                var yr1Dla = dlaData.DlaItems.ToArray()[0];
                var yr2Dla = dlaData.DlaItems.ToArray()[1];

                var yr1Qty = Convert.ToInt32(yr1Dla.Jan) + Convert.ToInt32(yr1Dla.Feb) + Convert.ToInt32(yr1Dla.Mar)
                             + Convert.ToInt32(yr1Dla.Apr) + Convert.ToInt32(yr1Dla.May) + Convert.ToInt32(yr1Dla.Jun)
                             + Convert.ToInt32(yr1Dla.Jul) + Convert.ToInt32(yr1Dla.Aug) + Convert.ToInt32(yr1Dla.Sep)
                             + Convert.ToInt32(yr1Dla.Oct) + Convert.ToInt32(yr1Dla.Nov) + Convert.ToInt32(yr1Dla.Dec);

                var yr2Qty = Convert.ToInt32(yr2Dla.Jan) + Convert.ToInt32(yr2Dla.Feb) + Convert.ToInt32(yr2Dla.Mar)
                             + Convert.ToInt32(yr2Dla.Apr) + Convert.ToInt32(yr2Dla.May) + Convert.ToInt32(yr2Dla.Jun)
                             + Convert.ToInt32(yr2Dla.Jul) + Convert.ToInt32(yr2Dla.Aug) + Convert.ToInt32(yr2Dla.Sep)
                             + Convert.ToInt32(yr2Dla.Oct) + Convert.ToInt32(yr2Dla.Nov) + Convert.ToInt32(yr2Dla.Dec);

                var twoYearsDlaDemand = yr1Qty + yr2Qty;

                var phCount = phData.ProcurementEntry.Length;

                var phLatest = phData.ProcurementEntry[0];
                var phFirst = phData.ProcurementEntry[phCount - 1];


                var govDataRes = new GovernmentDataReport()
                {
                    NSN = nsn,
                    NSNDescription = governmentDataSearchResults.ItemName,
                    LastAwardDate = phLatest.AwardDate.HasValue ? phLatest.AwardDate.Value.Year.ToString() : string.Empty,
                    FirstAwardDate = phFirst.AwardDate.HasValue ? phFirst.AwardDate.Value.Year.ToString() : string.Empty,
                    Dla2YrDemand = twoYearsDlaDemand,
                    LastAwardPrice = phLatest.TotalPrice,
                    LastAwardQty = phLatest.Quantity,
                    AMSC = string.Empty,
                    DLAOffice = string.Empty,
                    PotentialSales = 0,
                    LosesPercentage = 0,
                    RecentWins = 0,
                    RecentWinsPercentage = 0,
                    TotalQuantity = Convert.ToInt32(phLatest.Quantity) + Convert.ToInt32(phFirst.Quantity),
                    TotalWins = 0,
                    WinsPercentage = 0,
                    TotalContracts = dlaData.DlaItems.Length,
                };

                governmentDataReports.Add(govDataRes);
            }



            return governmentDataReports;
        }
    }
}