using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CChat.Areas.Auth.Models;
using CChat.CChatServices.AuthService.Interfaces;
using CChat.Data.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace OPUSERP.Areas.Auth.Controllers
{
    [Area("Auth")]
    public class UserRoleAssignController : Controller
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserInfoes userInfoes;
        //private readonly IERPModuleService eRPModuleService;

        public UserRoleAssignController(RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager, IUserInfoes userInfoes)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            this.userInfoes = userInfoes;
            //this.eRPModuleService = eRPModuleService;
        }

        public async Task<IActionResult> Index()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            List<ApplicationRoleViewModel> lstRole = new List<ApplicationRoleViewModel>();
            foreach (var data in roles)
            {
                ApplicationRoleViewModel model = new ApplicationRoleViewModel
                {
                    RoleId = data.Id,
                    RoleName = data.Name
                };
                lstRole.Add(model);
            }
            return View();
        }

        public async Task<IActionResult> AssaignRoleToUser()
        {
            string userName = User.Identity.Name;
            var roles = await _roleManager.Roles.Where(x=>x.Name!= "OPUSAdmin").ToListAsync();
            List<ApplicationRoleViewModel> lstRole = new List<ApplicationRoleViewModel>();
            foreach (var data in roles)
            {
                ApplicationRoleViewModel rolesModel = new ApplicationRoleViewModel
                {
                    RoleId = data.Id,
                    RoleName = data.Name
                };
                lstRole.Add(rolesModel);
            }

            ApplicationRoleViewModel model = new ApplicationRoleViewModel
            {
                roleViewModels = lstRole,
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AssaignRoleToUser([FromForm] ApplicationRoleViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            //return Json(model);
            var user = await _userManager.FindByNameAsync(model.userName);
            if (model.roleIdList.Count() > 0)
            {
                for (int i = 0; i < model.roleIdList.Count(); i++)
                {
                    await _userManager.AddToRoleAsync(user, model.roleIdList[i]);
                }
            }
            
            return RedirectToAction(nameof(AssaignRoleToUser));
        }

        #region API Section
        [Route("global/api/getUserInfoList")]
        [HttpGet]
        public async Task<IActionResult> GetUserInfo()
        {
            return Json(await userInfoes.GetUserInfo());
        }

        [Route("global/api/GetUserRoleByModule/{moduleId}")]
        [HttpGet]
        public async Task<IActionResult> GetUserRoleByModule(int moduleId)
        {
            var roles = await _roleManager.Roles.ToListAsync();
            List<ApplicationRoleViewModel> lstRole = new List<ApplicationRoleViewModel>();
            foreach (var data in roles)
            {
                ApplicationRoleViewModel rolesModel = new ApplicationRoleViewModel
                {
                    RoleId = data.Id,
                    RoleName = data.Name
                };
                lstRole.Add(rolesModel);
            }
            return Json(await userInfoes.GetUserInfo());
        }

        #endregion 
    }
}