using System;
using System.Collections.Generic;

namespace ILSmartWebServiceClient.Data.Database
{
    public partial class Generaldto
    {
        public string Nsn { get; set; } = null!;
        public string Part { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string? Schedulebcode { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
    }
}
