using BookingManagementMicroservice.BusinessLayerInterfaces;
using BookingManagementMicroservice.DataAccessLayerInterfaces;
using BookingManagementMicroservice.Models;
using BookingManagementMicroservice.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingManagementMicroservice.BusinessLogic
{
    public class BookingDetailsBusinessLayerService: IBookingDetailsBusinessLayerService
    {

        private readonly IBookingDataAccessLayerSerivce IBookingMasterDataAccessLayerService;

        public BookingDetailsBusinessLayerService(IBookingDataAccessLayerSerivce _IBookingMasterDataAccessLayerService)
        {
            this.IBookingMasterDataAccessLayerService = _IBookingMasterDataAccessLayerService;
        }

        public List<BookingDetail> getAllBookingDetails()
        {
            List<BookingDetail> userlist = new List<BookingDetail>();

            userlist = IBookingMasterDataAccessLayerService.getAllBookingDetail();
            return userlist;
        }
        public bool AddBookingDetails(BookingDetailsViewModel userMasterViewModel)
        {
            try
            {
                // UserMaster usermaster = new UserMaster();
                // usermaster = userMasterViewModel;
                var result = IBookingMasterDataAccessLayerService.AddBookingDetail(userMasterViewModel);
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool UpdateBookingDetails(BookingDetailsViewModel userMasterViewModel)
        {
            try
            {
                // UserMaster usermaster = new UserMaster();
                // usermaster = userMasterViewModel;
                var result = IBookingMasterDataAccessLayerService.UpdateBookingDetail(userMasterViewModel);
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool DeleteBookingDetails(string pnrNumber)
        {
            try
            {
                // UserMaster usermaster = new UserMaster();
                // usermaster = userMasterViewModel;
                BookingDetailsViewModel userMasterViewModel = new BookingDetailsViewModel();
                userMasterViewModel.PnrNumber = pnrNumber;
                userMasterViewModel.IsActive = false;
                var result = IBookingMasterDataAccessLayerService.UpdateBookingDetail(userMasterViewModel);
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<BookingDetailsViewModel> BookinghistoryDetails(string userEmailId)
        {
            try { 
            List<BookingDetailsViewModel> bookingdetailList = new List<BookingDetailsViewModel>();

            bookingdetailList = IBookingMasterDataAccessLayerService.BookinghistoryDetails(userEmailId);
                if (bookingdetailList != null)
                {
                    return bookingdetailList;
                }
                else {
                    return null;
                }
                
            }
            catch(Exception ex)
            {
                return null;
            }

            
        }
        public BookingDetailsViewModel findBookingPnrDetails(string pnrNumber)
        {
            try
            {
                BookingDetailsViewModel bookingdetailList = new BookingDetailsViewModel();

                bookingdetailList = IBookingMasterDataAccessLayerService.findBookingPnrDetails(pnrNumber);
                if (bookingdetailList != null)
                {
                    return bookingdetailList;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                return null;
            }


        }
    }
}
