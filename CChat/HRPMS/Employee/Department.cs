using CChat.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CChat.HRPMS.Data.Entity.Employee
{
    [Table("Department", Schema = "HR")]
    public class Department:Base
    {
        public string deptCode { get; set; }

        [Required]
        public string deptName { get; set; }
        public string deptNameBn { get; set; }

        public string shortName { get; set; }

    }
}
