using System;
using System.Collections.Generic;

#nullable disable

namespace FlightManagementMicroService.Models
{
    public partial class AirportMaster
    {
        public AirportMaster()
        {
            BookingDetailDestinations = new HashSet<BookingDetail>();
            BookingDetailSources = new HashSet<BookingDetail>();
            FlightScheduleDestinations = new HashSet<FlightSchedule>();
            FlightScheduleSources = new HashSet<FlightSchedule>();
        }

        public int AirportId { get; set; }
        public string AirportName { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string AirportCode { get; set; }
        public string City { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public int? LastUpdatedBy { get; set; }

        public virtual ICollection<BookingDetail> BookingDetailDestinations { get; set; }
        public virtual ICollection<BookingDetail> BookingDetailSources { get; set; }
        public virtual ICollection<FlightSchedule> FlightScheduleDestinations { get; set; }
        public virtual ICollection<FlightSchedule> FlightScheduleSources { get; set; }
    }
}
