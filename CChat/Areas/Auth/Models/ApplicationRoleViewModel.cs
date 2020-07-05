using CChat.Data.Entity.Auth;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CChat.Areas.Auth.Models
{
    public class ApplicationRoleViewModel
    {
        public string RoleId { get; set; }
        public string PreRoleId { get; set; }

        public string[] roleIdList { get; set; }

        public string userId { get; set; }

        public string userName { get; set; }

        public string RoleName { get; set; }

        public int? moduleId { get; set; }

        public string description { get; set; }

        public string moduleName { get; set; }
        public IEnumerable<CChatModule> eRPModules { get; set; }
        public IEnumerable<ApplicationRoleViewModel> roleViewModels { get; set; }
    }
}
