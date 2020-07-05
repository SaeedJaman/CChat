using CChat.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace CChat.Data.Entity.Auth
{
    public class DbChangeHistory:Base
    {
        [MaxLength(300)]
        public string entityName { get; set; }
        [MaxLength(100)]
        public string entityState { get; set; }
        [MaxLength(200)]
        public string fieldName { get; set; }
        public string fieldValue { get; set; }
        public int? sessionId { get; set; }
        [MaxLength(300)]
        public string remarks { get; set; }
    }
}
