using CChat.Areas.Auth.Models;
using CChat.CChatServices.AuthService.Interfaces;
using CChat.Data;
using CChat.Data.Entity;
using CChat.Data.Entity.Auth;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CChat.CChatServices.AuthService
{
    public class UserInfoes:IUserInfoes
    {
        private readonly CChatDbContext _context; 
        public UserInfoes(CChatDbContext context)
        {
            _context = context;
        }

        //public async Task<IEnumerable<UserType>> GetUserTypeList()
        //{
        //    return await _context.UserTypes.AsNoTracking().AsNoTracking().ToListAsync();
        //}

        public async Task<ApplicationUser> GetUserBasicInfoes(string userName)
        {
            return await _context.Users.Where(x => x.UserName == userName).FirstOrDefaultAsync();
        }

        public async Task<AspNetUsersViewModel> GetUserInfoByUser(string userName)
        {
            var result = (from U in _context.Users
                          join E in _context.employeeInfos on U.Id equals E.ApplicationUserId
                          join B in _context.specialBranchUnits on E.branchId equals B.Id
                          join D in _context.departments on E.departmentId equals D.Id into DD
                          from dpt in DD.DefaultIfEmpty()
                          where U.UserName == userName
                          select new AspNetUsersViewModel
                          {
                              aspnetId = U.Id,
                              UserName = U.UserName,
                              UserTypeId = U.userTypeId,
                              Email = U.Email,
                              EmpCode = U.EmpCode,
                              FinancialValue = U.MaxAmount,
                              UserId = U.userId,
                              isActive = U.isActive,
                              EmpName = E.nameEnglish,
                              DivisionName = dpt.deptName,
                              projectId = E.branchId,
                              branchName = B.branchUnitName
                          }).FirstOrDefaultAsync();
            return await result;
        }

        public async Task<AspNetUsersViewModel> GetUserBasicInformationByUserName(string userName)
        {
            var result = (from U in _context.Users
                          where U.UserName == userName
                          select new AspNetUsersViewModel
                          {
                              aspnetId = U.Id,
                              UserName = U.UserName,
                              UserTypeId = U.userTypeId,
                              Email = U.Email,
                              EmpCode = U.EmpCode,
                              FinancialValue = U.MaxAmount,
                              UserId = U.userId,
                              isActive = U.isActive,
                              projectId=U.companyId,
                          }).FirstOrDefaultAsync();
            return await result;
        }
        public async Task<AspNetUsersViewModel> GetUserInfoByUserId(int? UserId)
        {
            var result = (from U in _context.Users
                          join E in _context.employeeInfos on U.Id equals E.ApplicationUserId
                          join D in _context.departments on E.departmentId equals D.Id
                          where U.userId == UserId
                          select new AspNetUsersViewModel
                          {
                              aspnetId = U.Id,
                              UserName = U.UserName,
                              UserTypeId = U.userTypeId,
                              Email = U.Email,
                              EmpCode = U.EmpCode,
                              FinancialValue = U.MaxAmount,
                              UserId = U.userId,
                              isActive = U.isActive,
                              EmpName = E.nameEnglish,
                              DivisionName = D.deptName
                          }).FirstOrDefaultAsync();
            return await result;
        }

        //public EmployeeInfoViewModel GetEmployeeInfobyUser(string userName)
        //{
        //    return _context.employeeInfoViewModels.FromSql($"sp_GetAspnetuserInfoByuser {userName}").AsNoTracking().FirstOrDefault();
        //}

        public async Task<IEnumerable<AspNetUsersViewModel>> GetUserInfo()
        {
            var result = (from U in _context.Users
                         join E in _context.employeeInfos on U.Id equals E.ApplicationUserId
                          select new AspNetUsersViewModel
                          {
                              aspnetId = U.Id,
                              UserName = U.UserName,
                              UserTypeId = U.userTypeId,
                              Email = U.Email,
                              EmpCode = U.EmpCode,
                              FinancialValue = U.MaxAmount,
                              UserId = U.userId,
                              isActive = U.isActive,
                              EmpName = E.nameEnglish+" - "+E.employeeCode,
                              //DivisionName = EEE.department.deptName

                          }).ToListAsync();
            return await result;
        }

        public async Task<int> GetMaxUserId()
        {
            var result = await _context.Users.MaxAsync(x => x.userId);
            return  result;
        }

        //public async Task<IEnumerable<AspNetUsersViewModel>> GetUsersByEmployeeInfo()
        //{
        //    try
        //    {
        //        return await _context.aspNetUsersViews.FromSql(@"sp_GetUsersByEmployeeInfo").AsNoTracking().ToListAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public async Task<IEnumerable<AspNetUsersViewModel>> GetUserInfoByModule(int moduleId)
        //{            
        //    try
        //    {
        //        return await _context.aspNetUsersViews.FromSql($"sp_GetAspNetUsersByModule  {moduleId}").AsNoTracking().ToListAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public async Task<IEnumerable<CChatModule>> GetAllERPModule()
        {
            return await _context.CChatModules.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<AspNetUsersViewModel>> GetUserInfoList()
        {
            List<AspNetUsersViewModel> result = (from U in _context.Users

                                                 join empInfo in _context.employeeInfos on U.Id equals empInfo.ApplicationUserId into Details
                                                 from m in Details.DefaultIfEmpty()
                                                 select new AspNetUsersViewModel
                                                 {
                                                     aspnetId = U.Id,
                                                     UserName = U.UserName,
                                                     UserTypeId = U.userTypeId,
                                                     Email = U.Email,
                                                     EmpCode = U.EmpCode,
                                                     FinancialValue = U.MaxAmount,
                                                     UserId = U.userId,
                                                     isActive = U.isActive,
                                                     EmpName = m.nameEnglish,
                                                     DesignationName = m.designation
                                                 }).ToList();

            var aspnetolelist = _context.UserRoles.ToList();
            var aspnetrolenamelist = _context.Roles.ToList();
            List<AspNetUsersViewModel> aspNetUsersViewModels = new List<AspNetUsersViewModel>();
            foreach (AspNetUsersViewModel data in result)
            {
                string roleId = aspnetolelist.Where(x => x.UserId == data.aspnetId).FirstOrDefault()?.RoleId;

                string roleName = aspnetrolenamelist.Where(x => x.Id == roleId).FirstOrDefault()?.Name;
                aspNetUsersViewModels.Add(new AspNetUsersViewModel
                {
                    aspnetId = data.Id,
                    UserName = data.UserName,
                    UserTypeId = data.UserTypeId,
                    Email = data.Email,
                    EmpCode = data.EmpCode,
                    FinancialValue = data.FinancialValue,
                    UserId = data.UserId,
                    isActive = data.isActive,
                    EmpName = data.EmpName,
                    DesignationName = data.DesignationName,
                    roleId = roleName
                });

            }
            return aspNetUsersViewModels;
        }

    }
}
