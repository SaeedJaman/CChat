using CChat.Areas.Auth.Models;
using CChat.Data.Entity;
using CChat.Data.Entity.Auth;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CChat.CChatServices.AuthService.Interfaces
{
    public interface IUserInfoes
    {
        //Task<IEnumerable<UserType>> GetUserTypeList();
        Task<AspNetUsersViewModel> GetUserInfoByUser(string userName);
        Task<AspNetUsersViewModel> GetUserBasicInformationByUserName(string userName);
        Task<ApplicationUser> GetUserBasicInfoes(string userName);
        Task<IEnumerable<AspNetUsersViewModel>> GetUserInfo();
        Task<int> GetMaxUserId();
        //Task<IEnumerable<AspNetUsersViewModel>> GetUsersByEmployeeInfo();
        //Task<IEnumerable<AspNetUsersViewModel>> GetUserInfoByModule(int moduleId);
        Task<AspNetUsersViewModel> GetUserInfoByUserId(int? UserId);
        Task<IEnumerable<CChatModule>> GetAllERPModule();
        Task<IEnumerable<AspNetUsersViewModel>> GetUserInfoList();
    }
}
