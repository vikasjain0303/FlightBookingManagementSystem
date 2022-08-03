using FlightManagementMicroService.Models;
using FlightManagementMicroService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManagementMicroService.BusinessLayerInterfaces
{
   public  interface IFlightScheduleBusinessLayerService
    {
        List<FlightScheduleViewModelcs> getAllFlightSchedule();
        bool AddFlightSchedule(FlightScheduleViewModelcs userMasterViewModel);
        bool UpdateFlightSchedule(FlightScheduleViewModelcs userMasterViewModel);
        bool DeleteFlightSchedule(int AirLineId);
        List<FindFlightsScheduleViewModel> FindFlightSchedule(FindFlightsScheduleViewModel findFlightsScheduleViewModel);

    }
}
