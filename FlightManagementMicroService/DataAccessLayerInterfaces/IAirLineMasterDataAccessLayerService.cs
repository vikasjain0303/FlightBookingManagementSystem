using FlightManagementMicroService.Models;
using FlightManagementMicroService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManagementMicroService.DataAccessLayerInterfaces
{
   public interface IAirLineMasterDataAccessLayerService
    {
        List<AirLineMaster> getAllAirLine();
        bool AddAirLine(AirLineMasterViewModel userMasterViewModel);
        bool UpdateAirLine(AirLineMasterViewModel userMasterViewModel);
    }
}
