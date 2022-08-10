using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagementMicroService.ViewModels
{
    public class Tokens
    {
        public string Token { get; set; }

        public int UserId { get; set; }
        public int? RoleId { get; set; }
    }
}
