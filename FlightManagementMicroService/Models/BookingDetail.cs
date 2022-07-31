using System;
using System.Collections.Generic;

#nullable disable

namespace FlightManagementMicroService.Models
{
    public partial class BookingDetail
    {
        public BookingDetail()
        {
            PassengerDetails = new HashSet<PassengerDetail>();
        }

        public int BookingId { get; set; }
        public int? FlightId { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public int? SeatTypeId { get; set; }
        public int? NoOfSeatsBook { get; set; }
        public string PnrNumber { get; set; }
        public int? DiscountId { get; set; }
        public int? AirLineId { get; set; }
        public int? SourceId { get; set; }
        public int? DestinationId { get; set; }
        public int? FlightScheduleDayId { get; set; }
        public DateTime? BookingDatetime { get; set; }
        public decimal? TotalPrice { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public int? LastUpdatedBy { get; set; }
        public bool? IsActive { get; set; }
        public string BookingStatus { get; set; }

        public virtual AirLineMaster AirLine { get; set; }
        public virtual AirportMaster Destination { get; set; }
        public virtual DiscountMaster Discount { get; set; }
        public virtual FlightMaster Flight { get; set; }
        public virtual FlightScheduleDay FlightScheduleDay { get; set; }
        public virtual SeatTypeMaster SeatType { get; set; }
        public virtual AirportMaster Source { get; set; }
        public virtual ICollection<PassengerDetail> PassengerDetails { get; set; }
    }
}
