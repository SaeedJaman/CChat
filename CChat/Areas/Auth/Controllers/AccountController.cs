using CChat.Areas.Auth.Models;
using CChat.CChatServices.AuthService.Interfaces;
using CChat.CChatServices.EmployeeService.Interfaces;
using CChat.Data.Entity;
using CChat.Data.Entity.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OPUSERP.Controllers;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace OPUSERP.Areas.Auth.Controllers
{
    //[Authorize]
    [Area("Auth")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IPersonalInfoService personalInfoService;
        private readonly IUserInfoes userInfoes;
        private readonly IDbChangeService dbChangeService;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager, IUserInfoes userInfoes, IPersonalInfoService personalInfoService, IDbChangeService dbChangeService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            this.userInfoes = userInfoes;
            this.personalInfoService = personalInfoService;
            this.dbChangeService = dbChangeService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LogInViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(model.Name, model.Password, model.RememberMe, lockoutOnFailure: true);
                if (result.Succeeded)
                {
                    var ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                    var userAgent = Request.Headers["User-Agent"].ToString();
                    var mechineName = Environment.MachineName;
                    var rip = Dns.GetHostEntry(HttpContext.Connection.RemoteIpAddress.ToString()).ToString();
                    var userinofs = await userInfoes.GetUserInfoByUser(model.Name);
                    var employeeinfo = await personalInfoService.GetEmployeeInfoByApplicationId(userinofs?.aspnetId);
                    UserLogHistory userLog = new UserLogHistory
                    {
                        userId = model.Name,
                        logTime = DateTime.Now.ToShortDateString(),
                        status = 1,
                        ipAddress = ip,
                        pcName = mechineName,
                        browserName = userAgent
                    };

                    await dbChangeService.SaveUserLogHistory(userLog);

                    //EmpAttendance empAttendance = new EmpAttendance
                    //{
                    //    punchCardNo = employeeinfo.employeeCode,
                    //    startTime = DateTime.Now,
                    //    summaryId=1
                    //};
                    //await attendanceProcessService.SaveEmpAttendence(empAttendance);
                    return RedirectToLocal(returnUrl);
                    //FormsAuth.SetAuthCookie(username, rememberMe);

                    // return RedirectToLocal(returnUrl);
                    //var claims = new List<Claim>();
                    //var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    //var principal = new ClaimsPrincipal(identity);

                    //var props = new AuthenticationProperties();
                    //props.IsPersistent = model.RememberMe;

                    //HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,principal, props).Wait();
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Lockout()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Register(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            
            var roles = await _roleManager.Roles.ToListAsync();
            List<ApplicationRoleViewModel> lstRole = new List<ApplicationRoleViewModel>();
            foreach (var data in roles)
            {
                ApplicationRoleViewModel modelr = new ApplicationRoleViewModel
                {
                    RoleId = data.Id,
                    RoleName = data.Name
                };
                lstRole.Add(modelr);
            }
            var model = new RegisterViewModel
            {
                userRoles = lstRole,
            };
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                int maxUserId = await userInfoes.GetMaxUserId() + 1;
                var user = new ApplicationUser { UserName = model.Name, Email = model.Email, userId = maxUserId,EmpCode=model.EmpCode,org="ddm" };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, model.RoleId);
                    IdentityUser temp = await _userManager.FindByNameAsync(model.Name);
                    var emp = await personalInfoService.GetEmployeeInfoByCode(model.EmpCode);
                    emp.ApplicationUserId = temp.Id;
                    await personalInfoService.SaveEmployeeInfo(emp);
                    return RedirectToLocal(returnUrl);
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> EditRole([FromForm] ApplicationRoleViewModel model)
        {

            ApplicationUser user = await _userManager.FindByNameAsync(model.userName);
            //var oldRoleId = _userManager.GetUsersInRoleAsync(model.userName);
            //var oldRoleName = _roleManager.Roles.SingleOrDefault(r => r.Id == oldRoleId).Name;
            await _userManager.RemoveFromRoleAsync(user, model.PreRoleId);
            await _userManager.AddToRoleAsync(user, model.RoleId);
            return RedirectToAction(nameof(UserList));
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterModuleAdmin(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            var roles = await _roleManager.Roles.ToListAsync();
            List<ApplicationRoleViewModel> lstRole = new List<ApplicationRoleViewModel>();
            foreach (var data in roles)
            {
                ApplicationRoleViewModel modelr = new ApplicationRoleViewModel
                {
                    RoleId = data.Id,
                    RoleName = data.Name
                };
                lstRole.Add(modelr);
            }
            var model = new RegisterViewModel
            {
                userRoles = lstRole,
            };
            return View(model);
        }

        
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterModuleAdmin(RegisterViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                int maxUserId = await userInfoes.GetMaxUserId() + 1;
                var user = new ApplicationUser { UserName = model.Name, Email = model.Email,EmpCode=model.EmpCode, userId = maxUserId };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, model.RoleId);
                    IdentityUser temp = await _userManager.FindByNameAsync(model.Name);
                    return RedirectToLocal(returnUrl);
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> UserRoleCreate()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            List<ApplicationRoleViewModel> lstRole = new List<ApplicationRoleViewModel>();
            foreach (var data in roles)
            {
                ApplicationRoleViewModel model = new ApplicationRoleViewModel
                {
                    RoleId=data.Id,
                    RoleName=data.Name
                };
                lstRole.Add(model);
            }
            ApplicationRoleViewModel viewModel = new ApplicationRoleViewModel
            {
                eRPModules=await userInfoes.GetAllERPModule(),
                roleViewModels = lstRole
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UserIdentityRoleCreate([FromForm] ApplicationRoleViewModel model)
        {
            var user = new ApplicationRole ( model.RoleName );
            IdentityResult result =await _roleManager.CreateAsync(user);
            
            return RedirectToAction(nameof(UserRoleCreate));
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> UserList()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            List<ApplicationRoleViewModel> lstRole = new List<ApplicationRoleViewModel>();
            foreach (var data in roles)
            {
                ApplicationRoleViewModel modelr = new ApplicationRoleViewModel
                {
                    RoleId = data.Id,
                    RoleName = data.Name
                };
                lstRole.Add(modelr);
            }

            UserListViewModel model = new UserListViewModel
            {
                aspNetUsersViewModels = await userInfoes.GetUserInfoList(),
                userRoles = lstRole,
            };
            return View(model);
        }

        //[HttpPost]
        //[AllowAnonymous]
        //public async Task<IActionResult> UpdateUserInfo([FromForm] ApplicationRoleViewModel model)
        //{
        //    var user = _userManager.FindByNameAsync(model.userName);
        //    var oldRoleId = _userManager.GetUsersInRoleAsync(model.userName);
        //    var oldRoleName = _roleManager.Roles.SingleOrDefault(r => r.Id == oldRoleId).Name;
        //    return View(model);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            var ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            UserLogHistory userLog = new UserLogHistory
            {
                userId = HttpContext.User.Identity.Name,
                logTime = DateTime.Now.ToString(),
                status = 0,
                ipAddress = ip
            };
            await dbChangeService.SaveUserLogHistory(userLog);
            await _signInManager.SignOutAsync();
            //_logger.LogInformation("User logged out.");
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePsswordViewModel model)
        {
            string message = "Fail To Update Password";
            if (ModelState.IsValid)
            {
                var data = await _userManager.ChangePasswordAsync(await _userManager.FindByNameAsync(HttpContext.User.Identity.Name), model.OldPassword, model.Password);
                message = data.ToString();
            }
            return RedirectToAction(nameof(HomeController.Index), "Home", new { Message = message });
        }

        #region Helpers

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }
        #endregion
    }
}