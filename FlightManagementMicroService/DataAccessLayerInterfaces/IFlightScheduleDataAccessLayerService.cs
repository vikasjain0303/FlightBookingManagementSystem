using FlightManagementMicroService.Models;
using FlightManagementMicroService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManagementMicroService.DataAccessLayerInterfaces
{
   public interface IFlightScheduleDataAccessLayerService
    {
        List<FlightSchedule> getAllFlightSchedule();
        bool AddFlightSchedule(FlightSchedule userMasterViewModel);
        bool UpdateFlightSchedule(FlightScheduleViewModelcs userMasterViewModel);
        List<FindFlightsScheduleViewModel> FindFlightSchedule(FindFlightsScheduleViewModel findFlightsScheduleViewModel);
    }
}
