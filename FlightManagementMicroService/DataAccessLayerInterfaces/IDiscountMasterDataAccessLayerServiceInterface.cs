using FlightManagementMicroService.Models;
using FlightManagementMicroService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManagementMicroService.DataAccessLayerInterfaces
{
    public interface IDiscountMasterDataAccessLayerServiceInterface
    {
        List<DiscountMaster> getAllDiscountdetails();
        bool AddDiscountDetails(DiscountMasterViewModel userMasterViewModel);
        bool UpdateDiscounDetailst(DiscountMasterViewModel userMasterViewModel);
    }
}
