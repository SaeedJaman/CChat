namespace CChat.Areas.Auth.Models
{
    public class AspNetUsersViewModel
    {
        public string aspnetId { get; set; }
        public string UserName { get; set; }

        public int UserId { get; set; }

        public string Email { get; set; }

        public int? UserTypeId { get; set; }

        public string EmpCode { get; set; }

        public decimal? FinancialValue { get; set; }

        public int? isActive { get; set; }

        public string EmpName { get; set; }

        public string DivisionName { get; set; }

        public string DesignationName { get; set; }

        public string userTypeName { get; set; }

        public string companyName { get; set; }

        public string branchName { get; set; }

        public int? projectId { get; set; }

        public string roleId { get; set; }

        public string Id { get; set; }
    }
}
