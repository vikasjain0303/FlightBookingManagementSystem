using FlightManagementMicroService.DataAccessLayerInterfaces;
using FlightManagementMicroService.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManagementMicroService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {

        private readonly ICommonDataAccessLayer _IcommonDataAccessLayer;

        public CommonController(ICommonDataAccessLayer IcommonDataAccessLayer)
        {
            this._IcommonDataAccessLayer = IcommonDataAccessLayer;
        }
        [HttpGet("getallInstruments")]
        public async Task<ActionResult<List<InstrumentTypeMasterViewModel>>> getallInstrumentDetails()
        {
            List<InstrumentTypeMasterViewModel> userlist = new List<InstrumentTypeMasterViewModel>();

            userlist = _IcommonDataAccessLayer.getAllInstrument();
            // var jsonresult = JsonSerializer.Serialize(userlist);
            return Ok(userlist);
        }

        [HttpGet("getallmeal")]
        public async Task<ActionResult<List<MealTypeMasterViewModel>>> getallMealTypeDetails()
        {
            List<MealTypeMasterViewModel> userlist = new List<MealTypeMasterViewModel>();

            userlist = _IcommonDataAccessLayer.getAllmeal();
            // var jsonresult = JsonSerializer.Serialize(userlist);
            return Ok(userlist);
        }
        [HttpGet("getallGender")]
        public async Task<ActionResult<List<GenderTypeMasterViewModel>>> getallGenderTypeDetails()
        {
            List<GenderTypeMasterViewModel> userlist = new List<GenderTypeMasterViewModel>();

            userlist = _IcommonDataAccessLayer.getAllGender();
            // var jsonresult = JsonSerializer.Serialize(userlist);
            return Ok(userlist);
        }
        [HttpGet("getallSeat")]
        public async Task<ActionResult<List<SeatTypeMasterViewModel>>> getallSeatTypeDetails()
        {
            List<SeatTypeMasterViewModel> userlist = new List<SeatTypeMasterViewModel>();

            userlist = _IcommonDataAccessLayer.getAllSeat();
            // var jsonresult = JsonSerializer.Serialize(userlist);
            return Ok(userlist);
        }

        [HttpGet("getallWeekday")]
        public async Task<ActionResult<List<WeekDayTypeMasterViewModel>>> getallWeekdayTypeDetails()
        {
            List<WeekDayTypeMasterViewModel> userlist = new List<WeekDayTypeMasterViewModel>();

            userlist = _IcommonDataAccessLayer.getAllWeekday();
            // var jsonresult = JsonSerializer.Serialize(userlist);
            return Ok(userlist);
        }
    }
}
