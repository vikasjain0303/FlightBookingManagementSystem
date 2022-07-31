using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementMicroService.Models;
using UserManagementMicroService.ViewModels;

namespace UserManagementMicroService.BusinessLayerInterfaces
{
   public interface IUserBusinessLayerService
    {

        List<UserMaster> getAllUser();
        bool Adduser(UserMasterViewModel userMasterViewModel);
        bool Updateuser(UserMasterViewModel userMasterViewModel);
        bool Deleteuser(int UserId);
        Tokens userLogin(UserLoginViewModel userMasterViewModel);
    }
}
