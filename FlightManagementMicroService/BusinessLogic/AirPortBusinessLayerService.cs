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
    public class AirPortBusinessLayerService: IAirPortBusinessLayerService
    {
        private readonly IAirPortDataAccessLayerService IairPortMasterDataAccessLayerService;

        public AirPortBusinessLayerService(IAirPortDataAccessLayerService _IAirPortMasterDataAccessLayerService)
        {
            this.IairPortMasterDataAccessLayerService = _IAirPortMasterDataAccessLayerService;
        }

        public List<AirportMaster> getAllAirPort()
        {
            List<AirportMaster> userlist = new List<AirportMaster>();

            userlist = IairPortMasterDataAccessLayerService.getAllAirPort();
            return userlist;
        }
        public bool AddAirPort(AirportMasterViewModel userMasterViewModel)
        {
            try
            {
               // UserMaster usermaster = new UserMaster();
                // usermaster = userMasterViewModel;
                var result = IairPortMasterDataAccessLayerService.AddAirPort(userMasterViewModel);
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool UpdateAirPort(AirportMasterViewModel userMasterViewModel)
        {
            try
            {
                // UserMaster usermaster = new UserMaster();
                // usermaster = userMasterViewModel;
                var result = IairPortMasterDataAccessLayerService.UpdateAirPort(userMasterViewModel);
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool DeleteAirPort(int airlineid)
        {
            try
            {
                // UserMaster usermaster = new UserMaster();
                // usermaster = userMasterViewModel;
                AirportMasterViewModel userMasterViewModel = new AirportMasterViewModel();
                userMasterViewModel.AirportId = airlineid;
                userMasterViewModel.IsActive = false;
                var result = IairPortMasterDataAccessLayerService.UpdateAirPort(userMasterViewModel);
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
