using FlightManagementMicroService.Models;
using FlightManagementMicroService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManagementMicroService.BusinessLayerInterfaces
{
   public interface IAirlineMasterBusinessLayerService
    {
        List<AirLineMaster> getAllAirLine();
        bool AddAirLine(AirLineMasterViewModel userMasterViewModel);
        bool UpdateAirLine(AirLineMasterViewModel userMasterViewModel);
        bool DeleteAirLine(int AirLineId);
    }
}
