using FlightManagementMicroService.Models;
using FlightManagementMicroService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManagementMicroService.BusinessLayerInterfaces
{
    public interface IDiscountMasterBusinessLayerService
    {
        List<DiscountMaster> getAllDiscountDetails();
        bool AddDiscountDetails(DiscountMasterViewModel userMasterViewModel);
        bool UpdateDiscounDetailst(DiscountMasterViewModel userMasterViewModel);
        bool DeleteDiscountDetails(int AirLineId);
    }
}
