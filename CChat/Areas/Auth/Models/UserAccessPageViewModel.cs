using System.ComponentModel.DataAnnotations.Schema;

namespace CChat.Areas.Auth.Models
{
    [NotMapped]
    public class UserAccessPageViewModel
    {
        public string nameOption { get; set; }

        public string controller { get; set; }

        public string action { get; set; }

        public int parentID { get; set; }

        public int? isParent { get; set; }

        public int? displayOrder { get; set; }

        public string parentMenu { get; set; }

        public string parentName { get; set; }

        public string rowSl { get; set; }

        public int navbarId { get; set; }

        public string access { get; set; }
        public string moduleName { get; set; }
    }
}
