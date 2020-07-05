using CChat.Data.Entity.Auth;
using CChat.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CChat.CChatServices.AuthService.Interfaces;

namespace CChat.CChatServices.AuthService
{
    public class DbChangeService: IDbChangeService
    {
        private readonly CChatDbContext _context;

        public DbChangeService(CChatDbContext context)
        {
            _context = context;
        }

        public async Task<int> SaveUserLogHistory(UserLogHistory userLogHistory)
        {
            try
            {
                if (userLogHistory.Id != 0)
                {
                    _context.UserLogHistories.Update(userLogHistory);
                }
                else
                {
                    _context.UserLogHistories.Add(userLogHistory);
                }

                await _context.SaveChangesAsync();
                return userLogHistory.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<UserLogHistory>> GetAllUserLogHistory()
        {
            return await _context.UserLogHistories.Select(x=>new UserLogHistory {userId=x.userId,logTime=x.logTime,ipAddress=x.ipAddress,statusName=x.status==1?"Logged In":x.status==0?"Logged Out":"Logged Off" }).ToListAsync();
        }
        //public async Task<IEnumerable<DbChangeHistoryMasterNameViewModel>> GetAllTableName()
        //{
        //    return await _context.masterNameViewModels.FromSql($"SP_GetTableName").AsNoTracking().ToListAsync();
        //}
        //public async Task<IEnumerable<DbChangeHistoryMasterNameViewModel>> GetAllTableFieldName(string tableName)
        //{
        //    return await _context.masterNameViewModels.FromSql($"SP_GetTableFieldNameByTable {tableName}").AsNoTracking().ToListAsync();
        //}
        //public async Task<IEnumerable<DbChangeHistory>> GetDbChangeHistoryByEntityName(string tableName)
        //{
        //    var result= await _context.DbChangeHistories.FromSql($"SP_GetDbChangeHistoryByEntityName {tableName}").AsNoTracking().ToListAsync();
        //    return result;
        //}

        public async Task<IEnumerable<UserLogHistory>> GetUserLogHistoryByUser(string userName)
        {
            return await _context.UserLogHistories.Where(x => x.createdBy == userName).ToListAsync();
        }

        public async Task<IEnumerable<DbChangeHistory>> GetAllChangeHistory()
        {
            return await _context.DbChangeHistories.OrderByDescending(x=>x.Id).ToListAsync();
        }

        public async Task<IEnumerable<DbChangeHistory>> GetChangeHistoryDetailsByName(string entitName)
        {
            var result= await _context.DbChangeHistories.Where(x => x.entityName.Contains(entitName.Remove(entitName.Length-1))).OrderByDescending(x => x.Id).ToListAsync();
            return result;
        }


        public async Task<IEnumerable<DbChangeHistory>> GetAllChangeHistoryByUser(string userName)
        {
            return await _context.DbChangeHistories.Where(x=>x.createdBy==userName).ToListAsync();
        }
    }
}
