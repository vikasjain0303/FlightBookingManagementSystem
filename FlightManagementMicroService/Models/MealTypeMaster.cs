using System;
using System.Collections.Generic;

#nullable disable

namespace FlightManagementMicroService.Models
{
    public partial class MealTypeMaster
    {
        public MealTypeMaster()
        {
            FlightScheduleDays = new HashSet<FlightScheduleDay>();
            PassengerDetails = new HashSet<PassengerDetail>();
        }

        public int MealTypeId { get; set; }
        public string MealTypeName { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public int? LastUpdatedBy { get; set; }

        public virtual ICollection<FlightScheduleDay> FlightScheduleDays { get; set; }
        public virtual ICollection<PassengerDetail> PassengerDetails { get; set; }
    }
}
