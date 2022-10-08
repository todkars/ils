using ILSmartWebServiceClient.Data.Database;

namespace ILSmartWebServiceClient.Data
{
    public class ILSmartWebServiceClientRepository
    {
        private readonly ILSmartWebServiceClientDbContext iLSmartWebServiceClientDbContext;

        public ILSmartWebServiceClientRepository(ILSmartWebServiceClientDbContext dbContext)
        {
            iLSmartWebServiceClientDbContext = dbContext;
        }

        public List<Procurementdto> GetProcurementdtos()
        {
            return iLSmartWebServiceClientDbContext.Procurementdtos.ToList();
        }
    }
}