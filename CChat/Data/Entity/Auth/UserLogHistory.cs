using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CChat.Data.Entity.Auth
{
    public class UserLogHistory:Base
    {
        [MaxLength(250)]
        public string userId { get; set; }
        [MaxLength(250)]
        public string logTime { get; set; }
        public int? status { get; set; }
        [MaxLength(250)]
        public string ipAddress { get; set; }
        [MaxLength(250)]
        public string browserName { get; set; }
        [MaxLength(250)]
        public string pcName { get; set; }
        [NotMapped]
        public string statusName { get; set; }
    }
}
