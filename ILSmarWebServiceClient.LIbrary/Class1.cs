using ILSmartServiceReference;

namespace ILSmarWebServiceClient.LIbrary
{
    public class Class1
    {
        private readonly ISyncReply _syncReplyClient;

        public Class1(ISyncReply syncReplyClient)
        {
            _syncReplyClient = syncReplyClient;
        }
        public async Task<GetPreferredVendorGroupsResponseBody?> GetPreferredVendorGroupsAsync()
        {
           
            var res = await _syncReplyClient.GetPreferredVendorGroupsAsync("WEBSERVICETEST", "TESTU01");

            return res;
        }
    }
}