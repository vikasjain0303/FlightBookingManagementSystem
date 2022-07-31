using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingManagementMicroservice.ViewModels
{
    public class PassengerDetailsViewModel
    {
        public int PassengerId { get; set; }
        public int? BookingId { get; set; }
        public string PassengerName { get; set; }
        public int? GenderId { get; set; }
        public int? MealTypeId { get; set; }
        public int? SeatNo { get; set; }
        public bool? IsActive { get; set; }
    }
}
