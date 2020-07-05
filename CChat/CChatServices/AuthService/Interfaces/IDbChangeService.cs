using CChat.Data.Entity.Auth;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CChat.CChatServices.AuthService.Interfaces
{
    public interface IDbChangeService
    {
        Task<int> SaveUserLogHistory(UserLogHistory userLogHistory);

        Task<IEnumerable<UserLogHistory>> GetAllUserLogHistory();

        Task<IEnumerable<UserLogHistory>> GetUserLogHistoryByUser(string userName);

        Task<IEnumerable<DbChangeHistory>> GetAllChangeHistory();
        //Task<IEnumerable<DbChangeHistoryMasterNameViewModel>> GetAllTableName();

        Task<IEnumerable<DbChangeHistory>> GetAllChangeHistoryByUser(string userName);
        Task<IEnumerable<DbChangeHistory>> GetChangeHistoryDetailsByName(string entityName);
        //Task<IEnumerable<DbChangeHistoryMasterNameViewModel>> GetAllTableFieldName(string tableName);
        //Task<IEnumerable<DbChangeHistory>> GetDbChangeHistoryByEntityName(string entityName);
    }
}
