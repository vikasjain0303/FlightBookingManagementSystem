using System;
using System.Collections.Generic;

#nullable disable

namespace UserManagementMicroService.Models
{
    public partial class GenderTypeMaster
    {
        public GenderTypeMaster()
        {
            PassengerDetails = new HashSet<PassengerDetail>();
        }

        public int GenderId { get; set; }
        public string GenderType { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public int? LastUpdatedBy { get; set; }

        public virtual ICollection<PassengerDetail> PassengerDetails { get; set; }
    }
}
