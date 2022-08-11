using FlightManagementMicroService.BusinessLayerInterfaces;
using FlightManagementMicroService.Models;
using FlightManagementMicroService.ViewModels;
using Microsoft.AspNetCore.Authorization;
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
    public class AirLineController : ControllerBase
    {
        private readonly IAirlineMasterBusinessLayerService _IairLineBusinessLayerService;

        public AirLineController(IAirlineMasterBusinessLayerService IairLineBusinessLayerService)
        {
            this._IairLineBusinessLayerService = IairLineBusinessLayerService;
        }

        [HttpGet("getall"), Authorize(Roles = "1")]
        public async Task<ActionResult<List<AirLineMaster>>> getallAirLineDetails()
        {
            List<AirLineMaster> userlist = new List<AirLineMaster>();

            userlist = _IairLineBusinessLayerService.getAllAirLine();
            // var jsonresult = JsonSerializer.Serialize(userlist);
            return Ok(userlist);
        }
        [HttpPost("add"), Authorize(Roles = "1")]
        public async Task<ActionResult<string>> addAirLineDetails(AirLineMasterViewModel userMasterViewModel)
        {
            try
            {
                var result = _IairLineBusinessLayerService.AddAirLine(userMasterViewModel);
                if (result == true)
                {
                    return Ok();

                }
                else
                {
                    return BadRequest("Error");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Error");
            }
        }
        [HttpPut("update")]
        public async Task<ActionResult<string>> updateAirLineDeatils(AirLineMasterViewModel userMasterViewModel)
        {
            try
            {
                var result = _IairLineBusinessLayerService.UpdateAirLine(userMasterViewModel);
                if (result == true)
                {
                    return Ok(" AirLine Updated Successfully");

                }
                else
                {
                    return BadRequest("AirLine not Updated Succesfully");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpDelete("delete"), Authorize(Roles = "1")]
        public async Task<ActionResult<string>> deleteAirLineDeatils(int airlineId)
        {
            try
            {
                var result = _IairLineBusinessLayerService.DeleteAirLine(airlineId);
                if (result == true)
                {
                    return Ok();

                }
                else
                {
                    return BadRequest("AirLine not deleted Succesfully");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }

}
