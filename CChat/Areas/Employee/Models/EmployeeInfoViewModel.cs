using CChat.HRPMS.Data.Entity.Employee;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CChat.Areas.Employee.Models
{
    public class EmployeeInfoViewModel
    {
        [Required]
        [Display(Name = "Emp ID")]
        public string employeeID { get; set; }

        [Required]
        [Display(Name = "Employee Code")]
        public string employeeCode { get; set; }

        [Display(Name = "National ID")]
        public string nationalID { get; set; }

        [Display(Name = "Birth Identification No")]
        public string birthIdentificationNo { get; set; }

        [Display(Name = "Govt. ID")]
        public string govtID { get; set; }

        [Display(Name = "GPF Nominee Name")]
        public string gpfNomineeName { get; set; }

        [Display(Name = "GPF Acc No")]
        public string gpfAcNo { get; set; }

        [Required]
        [Display(Name = "Name In English")]
        public string nameEnglish { get; set; }

        [Display(Name = "Name In Bangla")]
        public string nameBangla { get; set; }

        [Display(Name = "Mother Name In English")]
        public string motherNameEnglish { get; set; }

        [Display(Name = "Mother Name In Bangla")]
        public string motherNameBangla { get; set; }

        [Display(Name = "Father Name In English")]
        public string fatherNameEnglish { get; set; }

        [Display(Name = "Father Name In Bangla")]
        public string fatherNameBangla { get; set; }

        [Display(Name = "Nationality")]
        public string nationality { get; set; }

        [Display(Name = "Disability")]
        public string disability { get; set; }

        [Display(Name = "Date Of Birth")]
        public DateTime? dateOfBirth { get; set; }

        [Display(Name = "Gender")]
        public string gender { get; set; }

        [Display(Name = "Place of Birth")]
        public string birthPlace { get; set; }

        [Display(Name = "Marital Status")]
        public string maritalStatus { get; set; }

        [Display(Name = "Religion")]
        public int? religion { get; set; }

        [Display(Name = "Employee Type")]
        public int? employeeType { get; set; }

        public int? activityStatus { get; set; }

        public int? department { get; set; }

        [Display(Name = "Tax Identification No.")]
        public string tin { get; set; }

        [Display(Name = "Batch")]
        public string batch { get; set; }

        [Display(Name = "SBU")]
        public int? sbu { get; set; }

        [Display(Name = "PNS")]
        public int? pns { get; set; }

        [Display(Name = "Blood Group")]
        public string bloodGroup { get; set; }

        [Display(Name = "Freedom Fighter")]
        public string freedomFighter { get; set; }

        [Display(Name = "Freedom Fighter No")]
        public string freedomFighterNo { get; set; }

        [Display(Name = "Telephone (Office)")]
        public string telephoneOffice { get; set; }

        [Display(Name = "Telephone (Residence)")]
        public string telephoneResidence { get; set; }

        [Display(Name = "PABX")]
        public string pabx { get; set; }

        [Display(Name = "Email Address")]
        public string emailAddress { get; set; }

        [Display(Name = "Mobile Number (Office)")]
        public string mobileNumberOffice { get; set; }

        [Display(Name = "Mobile Number (Personal)")]
        public string mobileNumberPersonal { get; set; }

        public string dateOfLPR { get; set; }
        public string emailAddressPersonal { get; set; }

        public DateTime? joiningDatePresentWorkstation { get; set; }
        public DateTime? joiningDateGovtService { get; set; }
        public DateTime? dateofregularity { get; set; }
        public DateTime? dateOfPermanent { get; set; }

        public string homeDistrict { get; set; }
        public string natureOfRequitment { get; set; }
        public string specialSkill { get; set; }
        public string seniorityNumber { get; set; }
        public string joiningDesignation { get; set; }
        public string designation { get; set; }
        public string skypeId { get; set; }

        public string action { get; set; }

        public int? post { get; set; }//Hidden Field For Designation, Handle.
        public string employeeNameCode { get; set; }

        public EmployeeInfo employeeInfo { get; set; }
        public IEnumerable<EmployeeInfo> allEmployeeInfos { get; set; }
        //public IEnumerable<Religion> religions { get; set; }
        //public IEnumerable<EmployeeType> employeeTypes { get; set; }
        //public IEnumerable<OrganoOrganization> organoOrganizations { get; set; }
        //public IEnumerable<Designation> designations { get; set; }
        //public IEnumerable<District> districts { get; set; }
        public IEnumerable<SpecialBranchUnit> specialBranchUnits { get; set; }
        public IEnumerable<Department> departments { get; set; }
    }
}
