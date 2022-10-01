using System;
using System.Collections.Generic;

namespace ILSmartWebServiceClient.Data.Database
{
    public partial class SrvaDatum
    {
        public SrvaDatum()
        {
            ForcastData = new HashSet<ForcastDatum>();
        }

        public int Id { get; set; }
        public string? Fsc { get; set; }
        public string? Niin { get; set; }
        public string? Nsn { get; set; }
        public string? Ui { get; set; }
        public string? SrvaDataForMonth { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public string? Supplychain { get; set; }
        public string? Itemdescription { get; set; }
        public int? _1 { get; set; }

        public virtual ICollection<ForcastDatum> ForcastData { get; set; }
    }
}
