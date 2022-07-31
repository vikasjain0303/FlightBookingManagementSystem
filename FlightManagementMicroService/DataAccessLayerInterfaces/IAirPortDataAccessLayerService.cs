using FlightManagementMicroService.Models;
using FlightManagementMicroService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManagementMicroService.DataAccessLayerInterfaces
{
   public interface IAirPortDataAccessLayerService
    {
        List<AirportMaster> getAllAirPort();
        bool AddAirPort(AirportMasterViewModel userMasterViewModel);
        bool UpdateAirPort(AirportMasterViewModel userMasterViewModel);
    }
}
