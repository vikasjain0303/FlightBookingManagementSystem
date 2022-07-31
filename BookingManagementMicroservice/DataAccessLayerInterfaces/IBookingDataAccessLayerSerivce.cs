using BookingManagementMicroservice.Models;
using BookingManagementMicroservice.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingManagementMicroservice.DataAccessLayerInterfaces
{
   public interface IBookingDataAccessLayerSerivce
    {
        List<BookingDetail> getAllBookingDetail();
        bool AddBookingDetail(BookingDetailsViewModel userMasterViewModel);
        bool UpdateBookingDetail(BookingDetailsViewModel userMasterViewModel);
        List<BookingDetailsViewModel> BookinghistoryDetails(string userEmailId);
        BookingDetailsViewModel findBookingPnrDetails(string pnrNumber);
    }
}
