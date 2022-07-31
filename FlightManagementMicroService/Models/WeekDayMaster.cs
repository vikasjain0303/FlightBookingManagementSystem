using System;
using System.Collections.Generic;

#nullable disable

namespace FlightManagementMicroService.Models
{
    public partial class WeekDayMaster
    {
        public WeekDayMaster()
        {
            FlightScheduleDays = new HashSet<FlightScheduleDay>();
        }

        public int WeekDayId { get; set; }
        public string WeekdayName { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public int? LastUpdatedBy { get; set; }

        public virtual ICollection<FlightScheduleDay> FlightScheduleDays { get; set; }
    }
}
