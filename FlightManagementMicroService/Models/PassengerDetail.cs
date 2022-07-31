using System;
using System.Collections.Generic;

#nullable disable

namespace FlightManagementMicroService.Models
{
    public partial class PassengerDetail
    {
        public int PassengerId { get; set; }
        public int? BookingId { get; set; }
        public string PassengerName { get; set; }
        public int? GenderId { get; set; }
        public int? MealTypeId { get; set; }
        public int? SeatNo { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public int? LastUpdatedBy { get; set; }

        public virtual BookingDetail Booking { get; set; }
        public virtual GenderTypeMaster Gender { get; set; }
        public virtual MealTypeMaster MealType { get; set; }
    }
}
