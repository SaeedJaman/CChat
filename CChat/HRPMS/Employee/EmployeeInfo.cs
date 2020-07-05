using CChat.Data.Entity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CChat.HRPMS.Data.Entity.Employee
{
    [Table("EmployeeInfo", Schema = "HR")]
    public class EmployeeInfo : Base
    {
        [Required]
        [MaxLength(50)]
        public string employeeCode { get; set; }

        [MaxLength(100)]
        public string nationalID { get; set; }

        [MaxLength(100)]
        public string birthIdentificationNo { get; set; }

        [MaxLength(250)]
        public string govtID { get; set; }
        
        public string gpfNomineeName { get; set; }
        
        public string gpfAcNo { get; set; }

        public string nameEnglish { get; set; }

        public string nameBangla { get; set; }

        public string motherNameEnglish { get; set; }

        public string motherNameBangla { get; set; }

        public string fatherNameEnglish { get; set; }

        public string fatherNameBangla { get; set; }

        public string nationality { get; set; }

        public string disability { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? dateOfBirth { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? joiningDatePresentWorkstation { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? joiningDateGovtService { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? dateofregularity { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? dateOfPermanent { get; set; }
        
        public string  LPRDate{ get; set; } //calculative From Date of Birth

        public string  PRLStartDate{ get; set; } //calculative From Date of Birth
        public string  PRLEndDate{ get; set; } //calculative From Date of Birth

        public string gender { get; set; }

        public string birthPlace { get; set; }

        public string maritalStatus { get; set; }

        //public int?  religionId { get; set; }
        //public Religion religion { get; set; }

        //public int? employeeTypeId { get; set; }
        //public EmployeeType employeeType { get; set; }

        public int? activityStatus { get; set; }

        public int? departmentId { get; set; }
        public Department department { get; set; }

        public string tin { get; set; }

        public string batch { get; set; }

        public string bloodGroup { get; set; }

        public bool freedomFighter { get; set; }

        public string freedomFighterNo { get; set; }
      
        public string telephoneOffice { get; set; }
       
        public string telephoneResidence { get; set; }
       
        public string pabx { get; set; }
       
        public string emailAddress { get; set; }

        public string emailAddressPersonal { get; set; } // Next generated not planned

        [MaxLength(50)]
        public string mobileNumberOffice { get; set; }

        [MaxLength(50)]
        public string mobileNumberPersonal { get; set; }

        public string specialSkill { get; set; }
       
        [MaxLength(50)]
        public string seniorityNumber { get; set; }

        public string designation { get; set; }

        public string skypeId { get; set; }

        public int? post { get; set; } // Related PostID But Not FK Referenced 

        public int designationCheck { get; set; }//Current Charged Checked

        public string joiningDesignation { get; set; }
        
        [MaxLength(100)]
        public string natureOfRequitment { get; set; } // Direct Or Absorbed

        public string homeDistrict { get; set; }

        public int? branchId { get; set; }
        public SpecialBranchUnit branch { get; set; }

        //public int? pNSId { get; set; }
        //public PNS pNS { get; set; }

        //public int? shiftGroupId { get; set; }
        //public ShiftGroupMaster shiftGroup { get; set; }

        //For Type Managing 
        [MaxLength(100)]
        public string orgType { get; set; }

        //Application User LInk
        public String ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }
}
