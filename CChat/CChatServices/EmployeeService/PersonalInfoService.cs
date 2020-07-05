using Microsoft.EntityFrameworkCore;
using CChat.Data;
using CChat.HRPMS.Data.Entity.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CChat.CChatServices.EmployeeService.Interfaces;

namespace CChat.CChatServices.EmployeeService
{
    public class PersonalInfoService : IPersonalInfoService
    {
        private readonly CChatDbContext _context;

        public PersonalInfoService(CChatDbContext context)
        {
            _context = context;
        }

        //EmployeeInfo
        public async Task<bool> DeleteEmployeeInfoById(int id)
        {
            _context.employeeInfos.Remove(_context.employeeInfos.Find(id));
            return 1 == await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<EmployeeInfo>> GetEmployeeInfo()
        {
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            return await _context.employeeInfos.Include(x => x.department).ToListAsync();
        }

        public async Task<EmployeeInfo> GetEmployeeInfoById(int id)
        {
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            return await _context.employeeInfos.Include(x=>x.department).Where(x=>x.Id == id).FirstAsync();
        }

        public async Task<EmployeeInfo> GetEmployeeInfoByApplicationId(string userId)
        {
            return await _context.employeeInfos.Where(x => x.ApplicationUserId == userId).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<int> SaveEmployeeInfo(EmployeeInfo employeeInfo)
        {
            if (employeeInfo.Id != 0)
                _context.employeeInfos.Update(employeeInfo);
            else
                _context.employeeInfos.Add(employeeInfo);
            await _context.SaveChangesAsync();
            return employeeInfo.Id;
        }

        public async Task<EmployeeInfo> GetEmployeeInfoByCode(string code)
        {
            return await _context.employeeInfos.Where(x => x.employeeCode == code).AsNoTracking().FirstOrDefaultAsync();
        }

        //public async Task<IEnumerable<EmployeeWithDesignationVM>> GetEmployeeInfoDetailsList(int empId)
        //{
        //    return await _context.employeeWithDesignations.FromSql($"sp_GetEmployeeDetailsList @p0,@p1",empId,string.Empty).ToListAsync();
        //}

        public async Task<string> GetEmployeeNameCodeById(int Id)
        {
            EmployeeInfo data = await _context.employeeInfos.FindAsync(Id);
            return data.nameEnglish + "-" + data.employeeCode;
        }

        //Here We GetQuery Result
        //public async Task<IEnumerable<AllEmployeeJson>> GetEmployeeInfoAsQueryAble(string queryString, string org)
        //{
        //    IQueryable<EmployeeInfo> queryData = _context.employeeInfos.Where(x => x.orgType == org);

        //    #region Filtering...

        //    string[] Tokens = queryString.Split("&");
        //    foreach(string token in Tokens)
        //    {
        //        string[] SepToken = token.Split("=");
        //        if(SepToken.Length > 1)
        //        {
        //            if(SepToken[0] == "EmpType")
        //            {
        //                queryData = queryData.Where(x => x.employeeTypeId == Int32.Parse(SepToken[1]));
        //            }else if(SepToken[0] == "PRL")
        //            {
        //                DateTime nowAndEx = DateTime.Now.AddMonths(Int32.Parse(SepToken[1]));
        //                DateTime now = DateTime.Now;
        //                queryData = queryData.Where(x => (DateTime.Parse(x.LPRDate) <= nowAndEx && DateTime.Parse(x.LPRDate) >= now));
        //            }
        //        }
        //    }
        //    #endregion

        //    #region Result Process
        //    IEnumerable<EmployeeInfo> data = await queryData.ToListAsync();
        //    List<AllEmployeeJson> filteredData = new List<AllEmployeeJson>();

        //    foreach (EmployeeInfo employeeInfo in data)
        //    {
        //        filteredData.Add(new AllEmployeeJson
        //        {
        //            employeeCode = employeeInfo.employeeCode,
        //            nameEnglish = employeeInfo.nameEnglish,
        //            emailAddress = employeeInfo.emailAddress,
        //            mobileNumberOffice = employeeInfo.mobileNumberOffice,
        //            designation = employeeInfo.designation,
        //            action = $"<a class='btn btn-success' data-toggle='tooltip' title='Edit' href='/HRPMSEmployee/Photograph/EditGrid/{employeeInfo.Id}'><i class='fa fa-edit'></i></a> <a class='btn btn-success' data-toggle='tooltip' title='Preview' target='_blank' href='/HRPMSEmployee/InfoView/Index/{employeeInfo.Id}'><i class='fas fa-eye'></i></a> <a class='btn btn-info' data-toggle='tooltip' target='_blank' title='Print' href='/HRPMSEmployee/InfoView/pdspdf/{employeeInfo.Id}'><i class='fa fa-print'></i></a>"
        //        });
        //    }
        //    #endregion

        //    return filteredData;
        //}

        public async Task<EmployeeInfo> GetFreeEmployeeByCode(string code)
        {
            return await _context.employeeInfos.Where(x => x.employeeCode == code && (x.ApplicationUserId == null || x.ApplicationUserId == "" || x.ApplicationUserId =="0")).FirstAsync();
        }

        public async Task<bool> UpdateEmployee(int Id, string authId, string org)
        {
            EmployeeInfo data = await _context.employeeInfos.FindAsync(Id);

            if (data == null) return false;
            data.ApplicationUserId = authId;
            data.orgType = org;

            return 1 == await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<EmployeeInfo>> GetEmployeeInfoByOrg(string org)
        {
            return await _context.employeeInfos.Where(x => x.orgType == org).AsNoTracking().ToListAsync();
        }

        public async Task<EmployeeInfo> GetEmployeeInfoByCodeAndOrg(string code, string orgType)
        {
            return await _context.employeeInfos.Where(x => x.employeeCode == code).Where(x=> x.orgType == orgType).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<string> GetAuthCodeByUserId(int empId)
        {
            return await _context.employeeInfos.Where(x => x.Id == empId).AsNoTracking().Select(x=> x.ApplicationUserId).FirstOrDefaultAsync();
        }

        public async Task<int> IsThisEmpIDPresent(string employeeId)
        {
           return await _context.employeeInfos.Where(x => x.employeeCode == employeeId).AsNoTracking().Select(x=> x.Id).FirstOrDefaultAsync();
        }

        //Dashboard 

        public async Task<IEnumerable<EmployeeInfo>> PRLInNextSixMonthByOrg(string org)
        {
            DateTime frm = DateTime.Now;
            DateTime to = frm.AddMonths(6);
            return await _context.employeeInfos.Where(x => x.orgType == org && (DateTime.Parse(x.LPRDate) <= to && DateTime.Parse(x.LPRDate) >= frm)).AsNoTracking().ToListAsync();
        }

        //public async Task<IEnumerable<EmployeeInfo>> LeaveInLastOneMonthByOrg(string org)
        //{
        //    DateTime to = DateTime.Now;
        //    DateTime frm = to.AddMonths(-1);
        //    List<int> ids = await  _context.leaveLogs.Where(x => x.leaveFrom >= frm && x.leaveFrom <= to).AsNoTracking().Select(x => (int)x.employeeId).ToListAsync();
        //    return await _context.employeeInfos.Where(x => x.orgType == org && ids.Contains(x.Id)).AsNoTracking().ToListAsync();
        //}
    }
}
