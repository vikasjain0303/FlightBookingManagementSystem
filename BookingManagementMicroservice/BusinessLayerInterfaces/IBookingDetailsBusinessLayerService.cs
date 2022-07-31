using BookingManagementMicroservice.Models;
using BookingManagementMicroservice.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingManagementMicroservice.BusinessLayerInterfaces
{
   public interface IBookingDetailsBusinessLayerService
    {
        List<BookingDetail> getAllBookingDetails();
        bool AddBookingDetails(BookingDetailsViewModel userMasterViewModel);
        bool UpdateBookingDetails(BookingDetailsViewModel userMasterViewModel);
        bool DeleteBookingDetails(string pnrNumber);
        List<BookingDetailsViewModel> BookinghistoryDetails(string userEmailId);
        BookingDetailsViewModel findBookingPnrDetails(string pnrNumber);
    }
}
