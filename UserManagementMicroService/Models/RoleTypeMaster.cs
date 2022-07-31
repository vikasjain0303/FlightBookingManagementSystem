using System;
using System.Collections.Generic;

#nullable disable

namespace UserManagementMicroService.Models
{
    public partial class RoleTypeMaster
    {
        public RoleTypeMaster()
        {
            UserMasters = new HashSet<UserMaster>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public int? LastUpdatedBy { get; set; }

        public virtual ICollection<UserMaster> UserMasters { get; set; }
    }
}
