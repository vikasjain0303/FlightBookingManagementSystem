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
    public class AirLineMasterBusinessLayerService: IAirlineMasterBusinessLayerService
    {
        private readonly IAirLineMasterDataAccessLayerService IairLineMasterDataAccessLayerService;

        public AirLineMasterBusinessLayerService(IAirLineMasterDataAccessLayerService _IairLineMasterDataAccessLayerService)
        {
            this.IairLineMasterDataAccessLayerService = _IairLineMasterDataAccessLayerService;
        }
        public List<AirLineMaster> getAllAirLine()
        {
            List<AirLineMaster> userlist = new List<AirLineMaster>();

            userlist = IairLineMasterDataAccessLayerService.getAllAirLine();
            return userlist;
        }
        public bool AddAirLine(AirLineMasterViewModel userMasterViewModel)
        {
            try
            {
                UserMaster usermaster = new UserMaster();
                // usermaster = userMasterViewModel;
                var result = IairLineMasterDataAccessLayerService.AddAirLine(userMasterViewModel);
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool UpdateAirLine(AirLineMasterViewModel userMasterViewModel)
        {
            try
            {
                // UserMaster usermaster = new UserMaster();
                // usermaster = userMasterViewModel;
                var result = IairLineMasterDataAccessLayerService.UpdateAirLine(userMasterViewModel);
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool DeleteAirLine(int airlineid)
        {
            try
            {
                // UserMaster usermaster = new UserMaster();
                // usermaster = userMasterViewModel;
                AirLineMasterViewModel userMasterViewModel = new AirLineMasterViewModel();
                userMasterViewModel.AirlineId = airlineid;
                userMasterViewModel.IsActive = false;
                var result = IairLineMasterDataAccessLayerService.UpdateAirLine(userMasterViewModel);
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
