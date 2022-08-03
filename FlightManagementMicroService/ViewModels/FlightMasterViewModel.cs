using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManagementMicroService.ViewModels
{
    public class FlightMasterViewModel
    {
        public int FlightId { get; set; }
        public string FlightCode { get; set; }
        public int? AirlineId { get; set; }
        public  string AirLineName { get; set; }
        public string InstrumentTypeName { get; set; }
        public int? InstrumentId { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public int? LastUpdatedBy { get; set; }
    }
}
