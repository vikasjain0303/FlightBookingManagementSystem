using FlightManagementMicroService.Models;
using FlightManagementMicroService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManagementMicroService.BusinessLayerInterfaces
{
   public interface IFlightBusinessLayerService
    {
        List<FlightMaster> getAllFlight();
        bool AddFlight(FlightMasterViewModel userMasterViewModel);
        bool UpdateFlight(FlightMasterViewModel userMasterViewModel);
        bool DeleteFlight(int AirLineId);
    }
}
