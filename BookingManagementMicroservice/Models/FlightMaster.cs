using System;
using System.Collections.Generic;

#nullable disable

namespace BookingManagementMicroservice.Models
{
    public partial class FlightMaster
    {
        public FlightMaster()
        {
            BookingDetails = new HashSet<BookingDetail>();
            FlightSchedules = new HashSet<FlightSchedule>();
        }

        public int FlightId { get; set; }
        public string FlightCode { get; set; }
        public int? AirlineId { get; set; }
        public int? InstrumentId { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public int? LastUpdatedBy { get; set; }

        public virtual AirLineMaster Airline { get; set; }
        public virtual InstrumentTypeMaster Instrument { get; set; }
        public virtual ICollection<BookingDetail> BookingDetails { get; set; }
        public virtual ICollection<FlightSchedule> FlightSchedules { get; set; }
    }
}
