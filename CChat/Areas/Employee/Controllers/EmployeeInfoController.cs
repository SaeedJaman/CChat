using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CChat.Areas.Employee.Models;
using CChat.CChatServices.EmployeeService.Interfaces;
using CChat.Data.Entity;
using CChat.HRPMS.Data.Entity.Employee;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CChat.Areas.Employee
{
    [Area("Employee")]
    public class EmployeeInfoController : Controller
    {

        private readonly IPersonalInfoService personalInfoService;
        //private readonly IReligionMunicipalityService religionMunicipalityService;
        //private readonly ITypeService typeService;
        //private readonly IOrganizationPostService organizationPostService;
        //private readonly IEmployeeOrganogramService employeeOrganogramService;
        //private readonly IDesignationDepartmentService designationDepartmentService;
        //private readonly IAddressService addressService;
        //private readonly ISpecialBranchUnitService specialBranchUnitService;
        //private readonly IStatusService statusService;
        private readonly UserManager<ApplicationUser> _userManager;

        public object dateOfBirth { get; private set; }

        public EmployeeInfoController(IHostingEnvironment hostingEnvironment, IPersonalInfoService personalInfoService, UserManager<ApplicationUser> userManager)
        {
            //_lang = new LangGenerate<EmployeeInfoLn>(hostingEnvironment.ContentRootPath);
            this.personalInfoService = personalInfoService;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        // GET: Info/Create
        public async Task<IActionResult> Create()
        {
            ApplicationUser user = await _userManager.GetUserAsync(HttpContext.User);
            var model = new EmployeeInfoViewModel
            {
                //fLang = _lang.PerseLang("Employee/EmployeeInfoEN.json", "Employee/EmployeeInfoBN.json", Request.Cookies["lang"]),
                //religions = await religionMunicipalityService.GetReligions(),
                //employeeTypes = await typeService.GetAllEmployeeType(),
                //organoOrganizations = await organizationPostService.GetAllOrganizationByIds(this.GetAllIdsByOrg(user.org)),
                //designations = await designationDepartmentService.GetDesignations(),
                //specialBranchUnits = await specialBranchUnitService.GetSpecialBranchUnit(),
                //districts = await addressService.GetAllDistrict(),
                //departments = await designationDepartmentService.GetDepartment(),
            };
            return View(model);
        }

        // POST: Info/Create
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] EmployeeInfoViewModel model)
        {
            //return Json(model);
            ApplicationUser user = await _userManager.GetUserAsync(HttpContext.User);

            int temp = await personalInfoService.IsThisEmpIDPresent(model.employeeCode);
            bool flag = false;
            if (temp != 0 && temp != Int32.Parse((model.employeeID)))
            {
                ModelState.AddModelError(string.Empty, "This Code Already Taken");
                flag = true;
            }

            if (!ModelState.IsValid || flag)
            {
                ViewBag.employeeID = model.employeeID;
                //model.fLang = _lang.PerseLang("Employee/EmployeeInfoEN.json", "Employee/EmployeeInfoBN.json", Request.Cookies["lang"]);
                //model.religions = await religionMunicipalityService.GetReligions();
                //model.employeeTypes = await typeService.GetAllEmployeeType();
                //model.organoOrganizations = await organizationPostService.GetAllOrganizationByIds(this.GetAllIdsByOrg(user.org));
                //model.designations = await designationDepartmentService.GetDesignations();
                //model.districts = await addressService.GetAllDistrict();
                //model.specialBranchUnits = await specialBranchUnitService.GetSpecialBranchUnit();
                //model.departments = await designationDepartmentService.GetDepartment();
                return View(model);
            }


            DateTime dateBirth = Convert.ToDateTime(model.dateOfBirth);
            DateTime dateLPR = dateBirth.AddYears(59);
            if (model.freedomFighter == "Yes") dateLPR = dateLPR.AddYears(1);

            string ApplicationUserId = await personalInfoService.GetAuthCodeByUserId(Int32.Parse(model.employeeID));
            //Console.WriteLine("\n\n\n"+dateLPR+"\n\n\n");

            EmployeeInfo data = new EmployeeInfo
            {
                Id = Int32.Parse(model.employeeID),
                employeeCode = model.employeeCode,
                nationalID = model.nationalID,
                birthIdentificationNo = model.birthIdentificationNo,
                govtID = model.govtID,
                gpfNomineeName = model.gpfNomineeName,
                gpfAcNo = model.gpfAcNo,
                nameEnglish = model.nameEnglish,
                nameBangla = model.nameBangla,
                motherNameEnglish = model.motherNameEnglish,
                motherNameBangla = model.motherNameBangla,
                fatherNameEnglish = model.fatherNameEnglish,
                fatherNameBangla = model.fatherNameBangla,
                nationality = model.nationality,
                disability = model.disability,
                dateOfBirth = model.dateOfBirth,
                gender = model.gender,
                birthPlace = model.birthPlace,
                maritalStatus = model.maritalStatus,
                tin = model.tin,
                batch = model.batch,
                bloodGroup = model.bloodGroup,
                freedomFighter = model.freedomFighter == "Yes" ? true : false,
                freedomFighterNo = model.freedomFighterNo,
                telephoneOffice = model.telephoneOffice,
                telephoneResidence = model.telephoneResidence,
                pabx = model.pabx,
                emailAddress = model.emailAddress,
                mobileNumberOffice = model.mobileNumberOffice,
                mobileNumberPersonal = model.mobileNumberPersonal,
                emailAddressPersonal = model.emailAddressPersonal,

                LPRDate = dateLPR.AddDays(-1).ToString("MM/dd/yyyy"),
                PRLStartDate = dateLPR.ToString("MM/dd/yyyy"),
                PRLEndDate = dateLPR.AddYears(1).ToString("MM/dd/yyyy"),
                joiningDatePresentWorkstation = model.joiningDatePresentWorkstation,
                joiningDateGovtService = model.joiningDateGovtService,
                dateofregularity = model.dateofregularity,
                dateOfPermanent = model.dateOfPermanent,
                branchId = model.sbu,

                natureOfRequitment = model.natureOfRequitment,
                activityStatus = model.activityStatus,
                departmentId = model.department,
                specialSkill = model.specialSkill,
                seniorityNumber = model.seniorityNumber,
                joiningDesignation = model.joiningDesignation,
                designation = model.designation,
                skypeId = model.skypeId,

                post = model.post,
                homeDistrict = model.homeDistrict,
                orgType = "ddm",
                ApplicationUserId = ApplicationUserId
            };

            int lstId = await personalInfoService.SaveEmployeeInfo(data);
            //return RedirectToAction(nameof(Index), new { @id = lstId });

            return RedirectToAction(nameof(Create));
        }
    }
}