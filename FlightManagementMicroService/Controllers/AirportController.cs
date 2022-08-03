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
    public class AirportController : ControllerBase
    {

        private readonly IAirPortBusinessLayerService _IairPortBusinessLayerService;

        public AirportController(IAirPortBusinessLayerService IairPortBusinessLayerService)
        {
            this._IairPortBusinessLayerService = IairPortBusinessLayerService;
        }

        [HttpGet("getall")]
        public async Task<ActionResult<List<AirportMaster>>> getallAirportDetails()
        {
            List<AirportMaster> userlist = new List<AirportMaster>();

            userlist = _IairPortBusinessLayerService.getAllAirPort();
            // var jsonresult = JsonSerializer.Serialize(userlist);
            return Ok(userlist);
        }
        [HttpPost("add")]
        public async Task<ActionResult<string>> addAirportDetails(AirportMasterViewModel userMasterViewModel)
        {
            try
            {
                var result = _IairPortBusinessLayerService.AddAirPort(userMasterViewModel);
                if (result == true)
                {
                    return Ok();

                }
                else
                {
                    return BadRequest("Airport not added Succesfully");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPut("update")]
        public async Task<ActionResult<string>> updateAirportDeatils(AirportMasterViewModel userMasterViewModel)
        {
            try
            {
                var result = _IairPortBusinessLayerService.UpdateAirPort(userMasterViewModel);
                if (result == true)
                {
                    return Ok("Airport Successfully");

                }
                else
                {
                    return BadRequest("Airport not Updated Succesfully");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpDelete("delete")]
        public async Task<ActionResult<string>> deleteAirportDeatils(int userid)
        {
            try
            {
                var result = _IairPortBusinessLayerService.DeleteAirPort(userid);
                if (result == true)
                {
                    return Ok("Airport Deleted Successfully");

                }
                else
                {
                    return BadRequest("Airport not deleted Succesfully");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
