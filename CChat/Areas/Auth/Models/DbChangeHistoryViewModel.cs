using CChat.Data.Entity.Auth;
using System.Collections.Generic;

namespace CChat.Areas.Auth.Models
{
    public class DbChangeHistoryViewModel
    {
        public string entityName { get; set; }

        public string entityState { get; set; }

        public string fieldName { get; set; }

        public string fieldValue { get; set; }

        public string createdAt { get; set; }

        public string createdBy { get; set; }

        public IEnumerable<DbChangeHistory> changeHistories { get; set; }
        public IEnumerable<DbChangeHistoryMasterNameViewModel> nameViewModels { get; set; }
    }
}
