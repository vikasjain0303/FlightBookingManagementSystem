using System;
using System.Collections.Generic;

#nullable disable

namespace UserManagementMicroService.Models
{
    public partial class AirLineMaster
    {
        public AirLineMaster()
        {
            BookingDetails = new HashSet<BookingDetail>();
            FlightMasters = new HashSet<FlightMaster>();
        }

        public int AirlineId { get; set; }
        public string AirlineName { get; set; }
        public string AirlineCode { get; set; }
        public string ContactNo { get; set; }
        public string Logo { get; set; }
        public string Address { get; set; }
        public string EmailId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public int? LastUpdatedBy { get; set; }

        public virtual ICollection<BookingDetail> BookingDetails { get; set; }
        public virtual ICollection<FlightMaster> FlightMasters { get; set; }
    }
}
