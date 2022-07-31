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
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountMasterBusinessLayerService _discountMasterBusinessLayer;

        public DiscountController(IDiscountMasterBusinessLayerService discountMasterBusinessLayer)
        {
            this._discountMasterBusinessLayer = discountMasterBusinessLayer;
        }

        [HttpGet("getall")]
        public async Task<ActionResult<List<DiscountMaster>>> getallDiscountDetails()
        {
            List<DiscountMaster> userlist = new List<DiscountMaster>();

            userlist = _discountMasterBusinessLayer.getAllDiscountDetails();
            // var jsonresult = JsonSerializer.Serialize(userlist);
            return Ok(userlist);
        }
        [HttpPost("add")]
        public async Task<ActionResult<string>> addDiscountDetails(DiscountMasterViewModel userMasterViewModel)
        {
            try
            {
                var result = _discountMasterBusinessLayer.AddDiscountDetails(userMasterViewModel);
                if (result == true)
                {
                    return Ok("Discount added Successfully");

                }
                else
                {
                    return BadRequest("Discount not added Succesfully");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPut("update")]
        public async Task<ActionResult<string>> updateDiscountDeatils(DiscountMasterViewModel userMasterViewModel)
        {
            try
            {
                var result = _discountMasterBusinessLayer.UpdateDiscounDetailst(userMasterViewModel);
                if (result == true)
                {
                    return Ok(" Discount Update Successfully");

                }
                else
                {
                    return BadRequest("Discount not Updated Succesfully");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpDelete("delete")]
        public async Task<ActionResult<string>> deleteDiscountDeatils(int userid)
        {
            try
            {
                var result = _discountMasterBusinessLayer.DeleteDiscountDetails(userid);
                if (result == true)
                {
                    return Ok("Discount Deleted Successfully");

                }
                else
                {
                    return BadRequest("Discount not deleted Succesfully");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
