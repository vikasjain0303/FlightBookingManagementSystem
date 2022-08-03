using FlightManagementMicroService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManagementMicroService.ViewModels
{
    public class FlightScheduleViewModelcs
    {

        //public FlightScheduleViewModelcs()
        //{
        //    FlightScheduleDays = new HashSet<FlightScheduleDay>();
        //}
        public int FlightScheduleId { get; set; }
        public int? FlightId { get; set; }
        public string FlightCode { get; set; }
        public string AirlineName { get; set; }
        public string SourceName { get; set; }
        public int? SourceId { get; set; }
        public int? DestinationId { get; set; }
        public string DestinationName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? IsActive { get; set; }
        //public int? CreatedBy { get; set; }
        //public DateTime? CreatedOn { get; set; }
        //public DateTime? LastUpdatedOn { get; set; }
        //public int? LastUpdatedBy { get; set; }
        public string WeekdaysIds { get; set; }
        public string WeekdaysNames { get; set; }

        //flightscheduleday
        public int? FlightScheduleDayId { get; set; }
        //public string DeparturetDateTime { get; set; }
        //public string ArrivalDateTime { get; set; }
        //public DateTime? DepartureDate { get; set; }
        //public DateTime? ArivalDate { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }
        public int? TotalSeatBusinessClass { get; set; }
        public int? TotalSeatRegularClass { get; set; }
        public int? VacantSeatBusinessClass { get; set; }
        public int? VacantSeatRegularClass { get; set; }
        public int? RowNo { get; set; }
        public decimal? TicketCost { get; set; }
        public int? MealTypeId { get; set; }
        //public HashSet<FlightScheduleDay> FlightScheduleDays { get; private set; }

        //public  ICollection<FlightScheduleDay> FlightScheduleDays { get; set; }

        //public int? WeekDayId { get; set; }


    }


}
