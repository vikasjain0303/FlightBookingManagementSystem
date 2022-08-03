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
    public class FlightScheduleController : ControllerBase
    {
        private readonly IFlightScheduleBusinessLayerService _IflightScheduleBusinessLayerService;

        public FlightScheduleController(IFlightScheduleBusinessLayerService IflightScheduleBusinessLayerService)
        {
            this._IflightScheduleBusinessLayerService = IflightScheduleBusinessLayerService;
        }

        [HttpGet("getall")]
        public async Task<ActionResult<List<FlightScheduleViewModelcs>>> getAllFlightScheduleDetails()
        {
            List<FlightScheduleViewModelcs> userlist = new List<FlightScheduleViewModelcs>();

            userlist = _IflightScheduleBusinessLayerService.getAllFlightSchedule();
            // var jsonresult = JsonSerializer.Serialize(userlist);
            return Ok(userlist);
        }
        [HttpPost("add")]
        public async Task<ActionResult<string>> AddFlightScheduleDetails(FlightScheduleViewModelcs userMasterViewModel)
        {
            try
            {
                var result = _IflightScheduleBusinessLayerService.AddFlightSchedule(userMasterViewModel);
                if (result == true)
                {
                    return Ok("FlightsSchedule added Successfully");

                }
                else
                {
                    return BadRequest("FlightsSchedule not added Succesfully");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPut("update")]
        public async Task<ActionResult<string>> UpdateFlightsScheduleDeatils(FlightScheduleViewModelcs userMasterViewModel)
        {
            try
            {
                var result = _IflightScheduleBusinessLayerService.UpdateFlightSchedule(userMasterViewModel);
                if (result == true)
                {
                    return Ok("FlightsSchedule Successfully");

                }
                else
                {
                    return BadRequest("FlightsSchedule not Updated Succesfully");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpDelete("delete")]
        public async Task<ActionResult<string>> DeleteFlightsScheduleDeatils(int userid)
        {
            try
            {
                var result = _IflightScheduleBusinessLayerService.DeleteFlightSchedule(userid);
                if (result == true)
                {
                    return Ok("FlightsSchedule Deleted Successfully");

                }
                else
                {
                    return BadRequest("FlightsSchedule not deleted Succesfully");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("find")]
        public async Task<ActionResult<List<FindFlightsScheduleViewModel>>> findFlightsScheduleDeatils(DateTime Journeydate ,int SourceId, int DestinationId)
        {
            try
            {
                FindFlightsScheduleViewModel findFlightsScheduleViewModel = new FindFlightsScheduleViewModel();

                findFlightsScheduleViewModel.Journeydate = Journeydate;
                findFlightsScheduleViewModel.SourceId = SourceId;
                findFlightsScheduleViewModel.DestinationId = DestinationId;
                var result = _IflightScheduleBusinessLayerService.FindFlightSchedule(findFlightsScheduleViewModel);
                if (result != null)
                {
                    return Ok(result);

                }
                else
                {
                    return BadRequest("Flight Schedule not deleted Succesfully");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
