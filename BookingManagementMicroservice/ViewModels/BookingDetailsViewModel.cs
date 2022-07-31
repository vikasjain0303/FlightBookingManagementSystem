using BookingManagementMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingManagementMicroservice.ViewModels
{
    public class BookingDetailsViewModel
    {
        public BookingDetailsViewModel()
        {
            PassengerDetails = new HashSet<PassengerDetailsViewModel>();
        }

        public int BookingId { get; set; }
        public int? FlightId { get; set; }
        public int? UserId { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public int? NoOfSeatsBook { get; set; }
        public string PnrNumber { get; set; }
        public int? AirLineId { get; set; }
        public int? SourceId { get; set; }
        public int? DestinationId { get; set; }
        public int? FlightScheduleDayId { get; set; }
        public DateTime? BookingDatetime { get; set; }
        public int? SeatTypeId { get; set; }

        public decimal? TotalPrice { get; set; }
        //public int? CreatedBy { get; set; }
        //public DateTime? CreatedOn { get; set; }
        //public DateTime? LastUpdatedOn { get; set; }
        //public int? LastUpdatedBy { get; set; }
        public bool? IsActive { get; set; }
        public string BookingStatus { get; set; }

        public virtual ICollection<PassengerDetailsViewModel> PassengerDetails { get; set; }

    }
}
