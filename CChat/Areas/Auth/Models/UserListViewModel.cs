using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CChat.Areas.Auth.Models
{
    public class UserListViewModel
    {
        public IEnumerable<AspNetUsersViewModel> aspNetUsersViewModels { get; set; }
        public IEnumerable<ApplicationRoleViewModel> userRoles { get; set; }
    }
}
