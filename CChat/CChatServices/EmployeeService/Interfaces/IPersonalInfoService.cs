using CChat.HRPMS.Data.Entity.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CChat.CChatServices.EmployeeService.Interfaces
{
    public interface IPersonalInfoService
    {
        Task<int> SaveEmployeeInfo(EmployeeInfo employeeInfo);
        Task<IEnumerable<EmployeeInfo>> GetEmployeeInfo();
        Task<EmployeeInfo> GetEmployeeInfoById(int id);
        Task<bool> DeleteEmployeeInfoById(int id);
        //Task<IEnumerable<EmployeeWithDesignationVM>> GetEmployeeInfoDetailsList(int empId);
        Task<EmployeeInfo> GetEmployeeInfoByCode(string code);
        Task<EmployeeInfo> GetEmployeeInfoByCodeAndOrg(string code,string orgType);
        Task<EmployeeInfo> GetFreeEmployeeByCode(string code);
        Task<string> GetEmployeeNameCodeById(int Id);
        Task<bool> UpdateEmployee(int Id, string authId, string org);
        Task<IEnumerable<EmployeeInfo>> GetEmployeeInfoByOrg(string org);
        Task<string> GetAuthCodeByUserId(int empId);

        Task<int> IsThisEmpIDPresent(string employeeId);
        //Task<IEnumerable<AllEmployeeJson>> GetEmployeeInfoAsQueryAble(string queryString, string org);
        Task<EmployeeInfo> GetEmployeeInfoByApplicationId(string userId);

        // for DashBoard
        Task<IEnumerable<EmployeeInfo>> PRLInNextSixMonthByOrg(string org);
        //Task<IEnumerable<EmployeeInfo>> LeaveInLastOneMonthByOrg(string org);
    }
}
