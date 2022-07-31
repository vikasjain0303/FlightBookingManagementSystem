using System;
using System.Collections.Generic;

#nullable disable

namespace UserManagementMicroService.Models
{
    public partial class FlightScheduleDay
    {
        public FlightScheduleDay()
        {
            BookingDetails = new HashSet<BookingDetail>();
        }

        public int FlightScheduleDayId { get; set; }
        public int? FlightScheduleId { get; set; }
        public DateTime? DepartureDate { get; set; }
        public DateTime? ArivalDate { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }
        public int? TotalSeatBusinessClass { get; set; }
        public int? TotalSeatRegularClass { get; set; }
        public int? VacantSeatBusinessClass { get; set; }
        public int? VacantSeatRegularClass { get; set; }
        public int? RowNo { get; set; }
        public decimal? TicketCost { get; set; }
        public int? MealTypeId { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public int? LastUpdatedBy { get; set; }
        public int? WeekdayId { get; set; }

        public virtual FlightSchedule FlightSchedule { get; set; }
        public virtual MealTypeMaster MealType { get; set; }
        public virtual WeekDayMaster Weekday { get; set; }
        public virtual ICollection<BookingDetail> BookingDetails { get; set; }
    }
}
