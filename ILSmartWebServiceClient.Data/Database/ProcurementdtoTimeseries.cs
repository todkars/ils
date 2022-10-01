using System;
using System.Collections.Generic;

namespace ILSmartWebServiceClient.Data.Database
{
    public partial class ProcurementdtoTimeseries
    {
        public int Id { get; set; }
        public int? Apicalldate { get; set; }
        public string? Awarddate { get; set; }
        public string? Cage { get; set; }
        public string? Contractno { get; set; }
        public string? Nsn { get; set; }
        public string? Quantity { get; set; }
        public string? Sos { get; set; }
        public string? Unitofmeasure { get; set; }
        public string? Unitprice { get; set; }
        public string? Vendor { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
    }
}
