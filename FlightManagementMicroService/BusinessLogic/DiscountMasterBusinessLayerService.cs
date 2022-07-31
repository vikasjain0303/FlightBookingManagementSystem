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
    public class DiscountMasterBusinessLayerService: IDiscountMasterBusinessLayerService
    {
        private readonly IDiscountMasterDataAccessLayerServiceInterface IdiscountMasterDataAccessLayerService;

        public DiscountMasterBusinessLayerService(IDiscountMasterDataAccessLayerServiceInterface _IdiscountMasterDataAccessLayerService)
        {
            this.IdiscountMasterDataAccessLayerService = _IdiscountMasterDataAccessLayerService;
        }
        public List<DiscountMaster> getAllDiscountDetails()
        {
            List<DiscountMaster> userlist = new List<DiscountMaster>();

            userlist = IdiscountMasterDataAccessLayerService.getAllDiscountdetails();
            return userlist;
        }
        public bool AddDiscountDetails(DiscountMasterViewModel userMasterViewModel)
        {
            try
            {
                DiscountMaster usermaster = new DiscountMaster();
                // usermaster = userMasterViewModel;
                var result = IdiscountMasterDataAccessLayerService.AddDiscountDetails(userMasterViewModel);
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool UpdateDiscounDetailst(DiscountMasterViewModel userMasterViewModel)
        {
            try
            {
                // UserMaster usermaster = new UserMaster();
                // usermaster = userMasterViewModel;
                var result = IdiscountMasterDataAccessLayerService.UpdateDiscounDetailst(userMasterViewModel);
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool DeleteDiscountDetails(int discountId)
        {
            try
            {
                // UserMaster usermaster = new UserMaster();
                // usermaster = userMasterViewModel;
                DiscountMasterViewModel userMasterViewModel = new DiscountMasterViewModel();
                userMasterViewModel.DiscountId = discountId;
                userMasterViewModel.IsActive = false;
                var result = IdiscountMasterDataAccessLayerService.UpdateDiscounDetailst(userMasterViewModel);
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
