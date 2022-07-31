using BookingManagementMicroservice.BusinessLayerInterfaces;
using BookingManagementMicroservice.Models;
using BookingManagementMicroservice.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingManagementMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingDetailsBusinessLayerService _IbookingDetailsBusinessLayerService;

        public BookingController(IBookingDetailsBusinessLayerService IbookingDetailsBusinessLayerService)
        {
            this._IbookingDetailsBusinessLayerService = IbookingDetailsBusinessLayerService;
        }

        [HttpGet("getall")]
        public async Task<ActionResult<List<BookingDetail>>> BookingDetails()
        {
            List<BookingDetail> userlist = new List<BookingDetail>();

            userlist = _IbookingDetailsBusinessLayerService.getAllBookingDetails();
            // var jsonresult = JsonSerializer.Serialize(userlist);
            return Ok(userlist);
        }
        [HttpPost("add")]
        public async Task<ActionResult<string>> addBookingDetails(BookingDetailsViewModel userMasterViewModel)
        {
            try
            {
                var result = _IbookingDetailsBusinessLayerService.AddBookingDetails(userMasterViewModel);
                if (result == true)
                {
                    return Ok("Booking done Successfully");

                }
                else
                {
                    return BadRequest("Booking not done Succesfully");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("update")]
        public async Task<ActionResult<string>> updateBookingDeatils(BookingDetailsViewModel userMasterViewModel)
        {
            try
            {
                var result = _IbookingDetailsBusinessLayerService.UpdateBookingDetails(userMasterViewModel);
                if (result == true)
                {
                    return Ok("booking updated Successfully");

                }
                else
                {
                    return BadRequest("booking not Updated Succesfully");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<string>> deleteBookingDetails(string pnrnumber)
        {
            try
            {
                var result = _IbookingDetailsBusinessLayerService.DeleteBookingDetails(pnrnumber);
                if (result == true)
                {
                    return Ok("booking cancel Successfully");

                }
                else
                {
                    return BadRequest("booking not cancel Succesfully");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("bookinghistory")]
        public async Task<ActionResult<List<BookingDetailsViewModel>>> bookinghistoryDetails(string useremailid)
        {
            try
            {
                var result = _IbookingDetailsBusinessLayerService.BookinghistoryDetails(useremailid);
                if (result != null)
                {
                    return Ok(result);

                }
                else
                {
                    return BadRequest(" No booking details Found");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet("findbookingpnr")]
        public async Task<ActionResult<BookingDetailsViewModel>> findPnrDetails(string pnrnumber)
        {
            try
            {
                var result = _IbookingDetailsBusinessLayerService.findBookingPnrDetails(pnrnumber);
                if (result != null)
                {
                    return Ok(result);

                }
                else
                {
                    return BadRequest(" No booking details Found");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
