using System;
using System.Collections.Generic;

#nullable disable

namespace BookingManagementMicroservice.Models
{
    public partial class DiscountMaster
    {
        public DiscountMaster()
        {
            BookingDetails = new HashSet<BookingDetail>();
        }

        public int DiscountId { get; set; }
        public string DiscountCode { get; set; }
        public decimal? MaximumDiscount { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public int? LastUpdatedBy { get; set; }

        public virtual ICollection<BookingDetail> BookingDetails { get; set; }
    }
}
