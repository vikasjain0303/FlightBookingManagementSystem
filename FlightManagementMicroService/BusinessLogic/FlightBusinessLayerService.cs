using FlightManagementMicroService.BusinessLayerInterfaces;
using FlightManagementMicroService.DataAccessLayerInterfaces;
using FlightManagementMicroService.Models;
using FlightManagementMicroService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManagementMicroService.BusinessLogic
{
    public class FlightBusinessLayerService: IFlightBusinessLayerService
    {
        private readonly IFlightDataAccessLayerService IFlightMasterDataAccessLayerService;

        public FlightBusinessLayerService(IFlightDataAccessLayerService _IFlightMasterDataAccessLayerService)
        {
            this.IFlightMasterDataAccessLayerService = _IFlightMasterDataAccessLayerService;
        }

        public List<FlightMasterViewModel> getAllFlight()
        {
            List<FlightMasterViewModel> userlist = new List<FlightMasterViewModel>();

            userlist = IFlightMasterDataAccessLayerService.getAllFlight();
            return userlist;
        }
        public bool AddFlight(FlightMasterViewModel userMasterViewModel)
        {
            try
            {
                // UserMaster usermaster = new UserMaster();
                // usermaster = userMasterViewModel;
                var result = IFlightMasterDataAccessLayerService.AddFlight(userMasterViewModel);
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool UpdateFlight(FlightMasterViewModel userMasterViewModel)
        {
            try
            {
                // UserMaster usermaster = new UserMaster();
                // usermaster = userMasterViewModel;
                var result = IFlightMasterDataAccessLayerService.UpdateFlight(userMasterViewModel);
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool DeleteFlight(int flightid)
        {
            try
            {
                // UserMaster usermaster = new UserMaster();
                // usermaster = userMasterViewModel;
                FlightMasterViewModel userMasterViewModel = new FlightMasterViewModel();
                userMasterViewModel.FlightId = flightid;
                userMasterViewModel.IsActive = false;
                var result = IFlightMasterDataAccessLayerService.UpdateFlight(userMasterViewModel);
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
