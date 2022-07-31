using System;
using System.Collections.Generic;

#nullable disable

namespace UserManagementMicroService.Models
{
    public partial class FlightSchedule
    {
        public FlightSchedule()
        {
            FlightScheduleDays = new HashSet<FlightScheduleDay>();
        }

        public int FlightScheduleId { get; set; }
        public int? FlightId { get; set; }
        public int? SourceId { get; set; }
        public int? DestinationId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public int? LastUpdatedBy { get; set; }
        public string WeekdaysIds { get; set; }

        public virtual AirportMaster Destination { get; set; }
        public virtual FlightMaster Flight { get; set; }
        public virtual AirportMaster Source { get; set; }
        public virtual ICollection<FlightScheduleDay> FlightScheduleDays { get; set; }
    }
}
