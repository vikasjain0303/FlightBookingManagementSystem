using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using UserManagementMicroService.BusinessLayerInterfaces;
using UserManagementMicroService.DataAccessLayerInterfaces;
using UserManagementMicroService.Models;
using UserManagementMicroService.ViewModels;

namespace UserManagementMicroService.BusinessLogic
{
    public class UserBusinessLayerService: IUserBusinessLayerService
    {
        private readonly IUserDataAccessLayerService IuserDataAccessLayerService;

        public UserBusinessLayerService(IUserDataAccessLayerService _IuserDataAccessLayerService)
        {
            this.IuserDataAccessLayerService = _IuserDataAccessLayerService;
        }
        public List<UserMaster> getAllUser()
        {
            List<UserMaster> userlist = new List<UserMaster>();

            userlist = IuserDataAccessLayerService.getAllUsers();
            return userlist;
        }
        public bool Adduser(UserMasterViewModel userMasterViewModel)
        {
            try {
                UserMaster usermaster = new UserMaster();
               // CreatepasswordHash(userMasterViewModel.Password, out byte[] passwordhash);
              // userMasterViewModel.PasswordHash = passwordhash;
                // usermaster = userMasterViewModel;
                var result = IuserDataAccessLayerService.Authenticate(userMasterViewModel, true);
                return true;
            }
            catch (Exception ex) {
                return false;
            }
        }
        public bool Updateuser(UserMasterViewModel userMasterViewModel)
        {
            try
            {
               // UserMaster usermaster = new UserMaster();
                // usermaster = userMasterViewModel;
                var result = IuserDataAccessLayerService.UpdateUser(userMasterViewModel);
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Deleteuser(int userid)
        {
            try
            {
                // UserMaster usermaster = new UserMaster();
                // usermaster = userMasterViewModel;
                UserMasterViewModel userMasterViewModel = new UserMasterViewModel();
                userMasterViewModel.UserId = userid;
                userMasterViewModel.IsActive = false;
                var result = IuserDataAccessLayerService.UpdateUser(userMasterViewModel);
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        
        public Tokens userLogin(UserLoginViewModel userMasterViewModel)
        {
            try
            {
                UserMasterViewModel usermaster = new UserMasterViewModel();
                usermaster.UserName = userMasterViewModel.UserName;
                usermaster.Password = userMasterViewModel.Password;
                // usermaster = userMasterViewModel;
                var result = IuserDataAccessLayerService.Authenticate(usermaster, false);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
