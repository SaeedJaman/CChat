using System.ComponentModel.DataAnnotations.Schema;

namespace CChat.Data.Entity.Auth
{
    public class UserType:Base
    {
        [Column(TypeName = "nvarchar(250)")]
        public string userTypeNameBn { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string userTypeName { get; set; }

        public int? groupId { get; set; }
        public virtual UserTypeGroup group { get; set; }

        public int? shortOrder { get; set; }
    }
}
