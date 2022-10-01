using System;
using System.Collections.Generic;

namespace ILSmartWebServiceClient.Data.Database
{
    public partial class ForcastDatum
    {
        public int Id { get; set; }
        public int SrvaDataId { get; set; }
        public int? DlaForcastMonth { get; set; }
        public int? DlaForcastYear { get; set; }
        public int? DlaForcastValue { get; set; }
        public int? DlaForcastTotalValue { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual SrvaDatum SrvaData { get; set; } = null!;
    }
}
