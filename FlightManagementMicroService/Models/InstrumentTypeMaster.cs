using System;
using System.Collections.Generic;

#nullable disable

namespace FlightManagementMicroService.Models
{
    public partial class InstrumentTypeMaster
    {
        public InstrumentTypeMaster()
        {
            FlightMasters = new HashSet<FlightMaster>();
        }

        public int InstrumentId { get; set; }
        public string InstrumentName { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public int? LastUpdatedBy { get; set; }

        public virtual ICollection<FlightMaster> FlightMasters { get; set; }
    }
}
