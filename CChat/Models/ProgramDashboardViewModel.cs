using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CChat.Models
{
    public class ProgramDashboardViewModel
    {
        public int? plan { get; set; }
        public int? program { get; set; }
        public decimal? perticipents { get; set; }
        public int? videos { get; set; }
        public IEnumerable<MasterPerticipants> masterPerticipants { get; set; }

    }

    public class HRMDashboardViewModel
    {
        public int? employees { get; set; }
        //public int? leave { get; set; }
        //public decimal? travel { get; set; }
        //public int? lateEmployee { get; set; }
        public int? training { get; set; }
        public int? officeBranches { get; set; }
        public int? enrolledTrainees { get; set; }


        public IEnumerable<MasterEmployees> masterEmployees { get; set; }
    }

    public class MasterPerticipants
    {
        public string name { get; set; }
        public int? count { get; set; }
    }

    public class MasterEmployees
    {
        public string name { get; set; }
        public int? count { get; set; }
    }
}
