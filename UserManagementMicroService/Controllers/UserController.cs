using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using UserManagementMicroService.BusinessLayerInterfaces;
using UserManagementMicroService.Models;
using UserManagementMicroService.ViewModels;

namespace UserManagementMicroService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBusinessLayerService _IuserBusinessLayerService;

        public UserController(IUserBusinessLayerService IuserBusinessLayerService)
        {
            this._IuserBusinessLayerService = IuserBusinessLayerService;
        }

        [HttpGet("userdetails"), Authorize(Roles = "1")]
       
        public async Task<ActionResult<List<UserMaster>>> UserDetails()
        {
            List<UserMaster> userlist = new List<UserMaster>();

            userlist = _IuserBusinessLayerService.getAllUser();
            // var jsonresult = JsonSerializer.Serialize(userlist);
            return Ok(userlist);
        }
        [HttpPost("AddUser")]
        public async Task<ActionResult<string>> AddUser(UserMasterViewModel userMasterViewModel)
        {
            try
            {
                var result = _IuserBusinessLayerService.Adduser(userMasterViewModel);
                if (result == true)
                {
                    return Ok();

                }
                else
                {
                    return BadRequest("user not added Succesfully");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPut("Updateuser")]
        public async Task<ActionResult<string>> Updateuser(UserMasterViewModel userMasterViewModel)
        {
            try
            {
                var result = _IuserBusinessLayerService.Updateuser(userMasterViewModel);
                if (result == true)
                {
                    return Ok("User Updated Successfully");

                }
                else
                {
                    return BadRequest("user not Updated Succesfully");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpDelete("Deleteuser")]
        public async Task<ActionResult<string>> Deleteuser(int userid)
        {
            try
            {
                var result = _IuserBusinessLayerService.Deleteuser(userid);
                if (result == true)
                {
                    return Ok("User Deleted Successfully");

                }
                else
                {
                    return BadRequest("user not deleted Succesfully");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [HttpPost("Login")]
        public async Task<ActionResult<string>> UserLogin(UserLoginViewModel userMasterViewModel)
        {
            try
            {
                var result = _IuserBusinessLayerService.userLogin(userMasterViewModel);
                if (result !=null)
                {
                    return Ok(result);

                }
                else
                {
                    return BadRequest("user not Login Succesfully");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
