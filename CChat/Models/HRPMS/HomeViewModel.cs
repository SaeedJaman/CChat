using CChat.HRPMS.Models.Lang;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace CChat.HRPMS.Models
{
    public class HomeViewModel
    {
        public string employeeNameCode { get; set; }
        public int id { get; set; }

        [Required]
        [Display(Name = "Employee Id")]
        public string employeeId { get; set; }

        [Display(Name = "Employee Name")]
        public string employeeName { get; set; }

        public string employeeInfo { get; set; }

        public string addressInfo { get; set; }

        public string educational { get; set; }

        public string spouseInfo { get; set; }

        public string childrenInfo { get; set; }

        public string drivingInfo { get; set; }

        public string passportInfo { get; set; }

        public string foreignTour { get; set; }

        public string trainingInfo { get; set; }

        public string membershipInfo { get; set; }

        public string languageInfo { get; set; }

        public string empPhotograph { get; set; }

        public string awardInfo { get; set; }

        public string publicationInfo { get; set; }

        public string promotionInfo { get; set; }

        public string transferInfo { get; set; }

        public HomeLn fLang { get; set; }

        public List<string> roles { get; set; }
        public string empOrganization { get; set; }

        //public IEnumerable<EmployeeInfo> prlInNextSix { get; set; }
        //public IEnumerable<EmployeeInfo> leaveInLastmonth { get; set; }
        //public IEnumerable<TrainingInfoNew> lastYearTraining { get; set; }
        //public List<CategoryWiseEmployee> categoryWiseEmployees { get; set; }
        //public List<BranchWiseEmployee> branchWiseEmployees { get; set; }
    }
}
