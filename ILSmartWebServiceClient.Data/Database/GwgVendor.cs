using System;
using System.Collections.Generic;

namespace ILSmartWebServiceClient.Data.Database
{
    public partial class GwgVendor
    {
        public int Id { get; set; }
        public string? Cage { get; set; }
        public string? Vendor { get; set; }
        public DateOnly? JoiningDate { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateOnly? VendorTillDate { get; set; }
    }
}
