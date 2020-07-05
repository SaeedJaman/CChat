using CChat.Data.Entity;
using CChat.HRPMS.Employee;
using System.ComponentModel.DataAnnotations.Schema;

namespace CChat.HRPMS.Data.Entity.Employee
{
    [Table("SpecialBranchUnit", Schema = "HR")]
    public class SpecialBranchUnit: Base
    {
        public string branchUnitName { get; set; }

        public string branchUnitNameBN { get; set; }

        public string branchCode { get; set; }

        public int? companyId { get; set; }
        public Company company { get; set; }

        public int? shortOrder { get; set; }
        public int? CCCatID { get; set; }
    }
}
