using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManagementMicroService.ViewModels
{
    public class AirportMasterViewModel
    {

        public int AirportId { get; set; }
        public string AirportName { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string AirportCode { get; set; }
        public string City { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public int? LastUpdatedBy { get; set; }
    }
}
