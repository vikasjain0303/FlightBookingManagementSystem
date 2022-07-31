using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementMicroService.Models;
using UserManagementMicroService.ViewModels;

namespace UserManagementMicroService.DataAccessLayerInterfaces
{
    public interface IUserDataAccessLayerService
    {
        List<UserMaster> getAllUsers();
        public Tokens Authenticate(UserMasterViewModel users, bool IsRegister);
        bool UpdateUser(UserMasterViewModel userMasterViewModel);

    }
}
