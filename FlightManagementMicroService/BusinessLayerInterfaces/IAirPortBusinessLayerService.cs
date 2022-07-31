using FlightManagementMicroService.Models;
using FlightManagementMicroService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManagementMicroService.BusinessLayerInterfaces
{
   public interface IAirPortBusinessLayerService
    {
        List<AirportMaster> getAllAirPort();
        bool AddAirPort(AirportMasterViewModel userMasterViewModel);
        bool UpdateAirPort(AirportMasterViewModel userMasterViewModel);
        bool DeleteAirPort(int AirLineId);
    }
}
