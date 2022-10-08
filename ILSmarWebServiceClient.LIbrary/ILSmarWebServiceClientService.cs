using ILSmartServiceReference;

namespace ILSmarWebServiceClient.LIbrary
{
    public class ILSmarWebServiceClientService
    {
        private readonly ISyncReply _syncReplyClient;

        public ILSmarWebServiceClientService(ISyncReply syncReplyClient)
        {
            _syncReplyClient = syncReplyClient;
        }
        public async Task<GetPreferredVendorGroupsResponseBody?> GetPreferredVendorGroupsAsync(string password, string userId)
        {
           
            GetPreferredVendorGroupsResponseBody res = await _syncReplyClient.GetPreferredVendorGroupsAsync(password, userId);

            return res;
        }

        public async Task<GetGovernmentDataResponseBody> GetGovernmentDataAsync(string[] govtFilesToSearch, string partNumber, string password, string userId)
        {
            GetGovernmentDataResponseBody res = await _syncReplyClient.GetGovernmentDataAsync(govtFilesToSearch, partNumber, password, userId);

            return res;
        }

        public async Task<GetCageContactResponseBody> GetCageContactAsync(string cage, string password, string userId)
        {
            GetCageContactResponseBody res = await _syncReplyClient.GetCageContactAsync(cage, password, userId);

            return res;
        }

        public async Task<GetNiinsByPartResponseBody> GetNiinsByPartAsync(string partNumber, string password, string userId)
        {
            GetNiinsByPartResponseBody res = await _syncReplyClient.GetNiinsByPartAsync(partNumber, password, userId);

            return res;
        }
    }
}