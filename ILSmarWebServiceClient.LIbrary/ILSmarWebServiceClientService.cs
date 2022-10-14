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

        public async Task<GetGovernmentDataResponseBody> GetGovernmentDataAsync(string[] govtFilesToSearch, string partNumber, string password, string userId)
        {
            GetGovernmentDataResponseBody res = await _syncReplyClient.GetGovernmentDataAsync(govtFilesToSearch, partNumber, password, userId);

            return res;
        }
    }
}