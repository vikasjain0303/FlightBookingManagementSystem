using FlightManagementMicroService.Models;
using FlightManagementMicroService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManagementMicroService.DataAccessLayerInterfaces
{
   public interface IFlightDataAccessLayerService
    {
        List<FlightMasterViewModel> getAllFlight();
        bool AddFlight(FlightMasterViewModel userMasterViewModel);
        bool UpdateFlight(FlightMasterViewModel userMasterViewModel);
    }
}
