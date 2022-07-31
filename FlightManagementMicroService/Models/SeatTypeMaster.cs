using System;
using System.Collections.Generic;

#nullable disable

namespace FlightManagementMicroService.Models
{
    public partial class SeatTypeMaster
    {
        public SeatTypeMaster()
        {
            BookingDetails = new HashSet<BookingDetail>();
        }

        public int SeatTypeId { get; set; }
        public string SeatTypeName { get; set; }

        public virtual ICollection<BookingDetail> BookingDetails { get; set; }
    }
}
