using System.ComponentModel.DataAnnotations.Schema;

namespace CChat.Data.Entity.Auth
{
    public class UserTypeGroup:Base
    {
        [Column(TypeName = "nvarchar(250)")]
        public string groupTypeNameBN { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string groupTypeName { get; set; }

        public int? shortOrder { get; set; }
    }
}
