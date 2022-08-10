using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UserManagementMicroService.DataAccessLayerInterfaces;
using UserManagementMicroService.Models;
using UserManagementMicroService.ViewModels;

namespace UserManagementMicroService.DataAccessLayer
{
    public class UserDataAccesslayerService: IUserDataAccessLayerService
    {

       UserMaster userRecords =new UserMaster();

        private readonly IConfiguration configuration;
        private readonly FlightBookingDBContext db;
        public UserDataAccesslayerService(FlightBookingDBContext _db, IConfiguration _configuration)
        {
            this.db = _db;
            this.configuration = _configuration;
        }
        public List<UserMaster> getAllUsers()
        {
            List<UserMaster> userlist = new List<UserMaster>();
            userlist= db.UserMasters.Where(x => x.IsActive == true).ToList();
          // userlist= db.UserMasters.ToList();
            return userlist;
        }
        public Tokens Authenticate(UserMasterViewModel users, bool IsRegister)
        {
            if (IsRegister)
            {
                if (db.UserMasters.Any(x => x.UserName == users.UserName))
                {
                    return null;
                }

                UserMaster tbllogin = new UserMaster();
                tbllogin.UserName = users.UserName;
                tbllogin.Password = users.Password;
                tbllogin.EmailId = users.EmailId;
                tbllogin.FullName = users.FullName;
                db.UserMasters.Add(tbllogin);
                db.SaveChanges();
            }
            userRecords = db.UserMasters.Where(x => x.UserName==users.UserName && x.Password ==users.Password).FirstOrDefault();
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenkey = Encoding.UTF8.GetBytes(configuration["JWT:Key"]);
            if (userRecords==null )
            {
                return null;
            }
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                new Claim(ClaimTypes.Name,userRecords.UserName),
                new Claim(ClaimTypes.Role,userRecords.RoleId.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new Tokens { Token = tokenHandler.WriteToken(token), UserId=userRecords.UserId,RoleId=userRecords.RoleId };
        }


        public bool UpdateUser(UserMasterViewModel userMasterViewModel)
        {

            try
            {
                if (db.UserMasters.Any(x => x.UserId == userMasterViewModel.UserId))
                {
                    var Userdata = db.UserMasters.Where(x => x.UserId == userMasterViewModel.UserId).FirstOrDefault();
                    // UserMaster userMaster = new UserMaster();
                    Userdata.FullName = userMasterViewModel.FullName ?? Userdata.FullName;
                    Userdata.EmailId = userMasterViewModel.EmailId ?? Userdata.EmailId;
                    Userdata.Password = userMasterViewModel.Password?? Userdata.Password;
                    Userdata.UserName = userMasterViewModel.UserName ?? Userdata.UserName;
                    Userdata.IsActive = userMasterViewModel.IsActive ?? Userdata.IsActive;
                    //userMaster. = userMasterViewModel.FullName;
                    db.UserMasters.Update(Userdata);
                    var result = db.SaveChanges();
                    return true;
                }
                else {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        

       

    }
}
