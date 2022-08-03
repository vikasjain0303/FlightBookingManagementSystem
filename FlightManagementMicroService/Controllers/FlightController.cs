using FlightManagementMicroService.BusinessLayerInterfaces;
using FlightManagementMicroService.Models;
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
    public class FlightController : ControllerBase
    {
        private readonly IFlightBusinessLayerService _IflightBusinessLayerService;

        public FlightController(IFlightBusinessLayerService IflightBusinessLayerService)
        {
            this._IflightBusinessLayerService = IflightBusinessLayerService;
        }

        [HttpGet("getall")]
        public async Task<ActionResult<List<FlightMasterViewModel>>> getallFlightDetails()
        {
            List<FlightMasterViewModel> userlist = new List<FlightMasterViewModel>();

            userlist = _IflightBusinessLayerService.getAllFlight();
            // var jsonresult = JsonSerializer.Serialize(userlist);
            return Ok(userlist);
        }
        [HttpPost("add")]
        public async Task<ActionResult<string>> addFlightDetails(FlightMasterViewModel userMasterViewModel)
        {
            try
            {
                var result = _IflightBusinessLayerService.AddFlight(userMasterViewModel);
                if (result == true)
                {
                    return Ok();

                }
                else
                {
                    return BadRequest("Flight not added Succesfully");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPut("update")]
        public async Task<ActionResult<string>> updateFlightDeatils(FlightMasterViewModel userMasterViewModel)
        {
            try
            {
                var result = _IflightBusinessLayerService.UpdateFlight(userMasterViewModel);
                if (result == true)
                {
                    return Ok("Flight Successfully");

                }
                else
                {
                    return BadRequest("Flight not Updated Succesfully");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpDelete("delete")]
        public async Task<ActionResult<string>> deleteFlightDeatils(int userid)
        {
            try
            {
                var result = _IflightBusinessLayerService.DeleteFlight(userid);
                if (result == true)
                {
                    return Ok("Flight Deleted Successfully");

                }
                else
                {
                    return BadRequest("Flight not deleted Succesfully");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        
    }
}
