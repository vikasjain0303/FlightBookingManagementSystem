using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManagementMicroService.ViewModels
{
    public class DiscountMasterViewModel
    {
        public int DiscountId { get; set; }
        public string DiscountCode { get; set; }
        public decimal? MaximumDiscount { get; set; }
        public bool? IsActive { get; set; }

    }
}
