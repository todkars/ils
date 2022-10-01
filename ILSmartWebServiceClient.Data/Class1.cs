using ILSmartWebServiceClient.Data.Database;
using Microsoft.EntityFrameworkCore;

namespace ILSmartWebServiceClient.Data
{
    public class RepositoryClass
    {
        private readonly ILSmartWebServiceClientDbContext iLSmartWebServiceClientDbContext;

        public RepositoryClass(ILSmartWebServiceClientDbContext dbContext)
        {
            iLSmartWebServiceClientDbContext = dbContext;
        }

        public List<Procurementdto> GetProcurementdtos()
        {
            return iLSmartWebServiceClientDbContext.Procurementdtos.ToList();
        }
    }
}