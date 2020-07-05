using CChat.Data.Entity;
using CChat.Data.Entity.Auth;
using CChat.HRPMS.Data.Entity.Employee;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CChat.Data
{
    public class CChatDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CChatDbContext(DbContextOptions<CChatDbContext> options, IHttpContextAccessor _httpContextAccessor) : base(options)
        {
            this._httpContextAccessor = _httpContextAccessor;
        }

        public DbSet<EmployeeInfo> employeeInfos { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<SpecialBranchUnit> specialBranchUnits { get; set; }
        public DbSet<CChatModule> CChatModules { get; set; }
        public DbSet<UserLogHistory> UserLogHistories { get; set; }
        public DbSet<DbChangeHistory> DbChangeHistories { get; set; }

        #region Settings Configs
        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            AddTimestamps();
            return await base.SaveChangesAsync();
        }

        private void AddTimestamps()
        {

            var entities = ChangeTracker.Entries().Where(x => x.Entity is Base && (x.State == EntityState.Added || x.State == EntityState.Modified));

            var currentUsername = !string.IsNullOrEmpty(_httpContextAccessor?.HttpContext?.User?.Identity?.Name)
                ? _httpContextAccessor.HttpContext.User.Identity.Name
                : "Anonymous";

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    ((Base)entity.Entity).createdAt = DateTime.Now;
                    ((Base)entity.Entity).createdBy = currentUsername;
                }
                else
                {
                    entity.Property("createdAt").IsModified = false;
                    entity.Property("createdBy").IsModified = false;
                    ((Base)entity.Entity).updatedAt = DateTime.Now;
                    ((Base)entity.Entity).updatedBy = currentUsername;
                }

                #region changelog
                int sessionId = 0;
                DateTime myDate1 = new DateTime(1970, 1, 9, 0, 0, 00);
                DateTime myDate2 = DateTime.Now;
                TimeSpan myDateResult;
                myDateResult = myDate2 - myDate1;
                double seconds = myDateResult.TotalSeconds;
                sessionId = Convert.ToInt32(seconds);

                string entityName = entity.Entity.GetType().Name;
                string entityState = entity.State.ToString();
                if (entityName != "UserLogHistory")
                {

                    var builder = new ConfigurationBuilder()
                                    .SetBasePath(Directory.GetCurrentDirectory())
                                    .AddJsonFile("appsettings.json");

                    var configuration = builder.Build();

                    using (var db = new SqlConnection(configuration.GetConnectionString("ERPConnection")))
                    {
                        db.Open();

                        var entityMember = entity.Members;
                        var value = entity.Members.Count();
                        var entityinfo = entity.Entity.GetType();
                        var entityVal = entity.Entity;
                        string customAttributeName = string.Empty;
                        var fieldName = entityinfo.GetProperties();
                        for (int i = 0; i < fieldName.Count(); i++)
                        {
                            var columnName = fieldName[i].Name;
                            string colType = fieldName[i].PropertyType.ToString();
                            var custmAttribute = fieldName[i].GetCustomAttributesData();
                            if (custmAttribute.Count() >= 1)
                                customAttributeName = custmAttribute.FirstOrDefault().AttributeType.Name;

                            if (colType.Contains("OPUSERP") || customAttributeName == "NotMappedAttribute")
                            {

                            }
                            else
                            {
                                var type = entity.Property(columnName).GetType();
                                var valueName = entity?.Property(columnName)?.CurrentValue?.ToString();
                                valueName = valueName?.Replace("'", "''");
                                string Tmp1 = $"INSERT INTO DbChangeHistories (entityName,fieldName,fieldValue,entityState,sessionId,createdBy,createdAt) VALUES('{entityName}','{columnName}','{valueName}','{entityState}','{sessionId}','{currentUsername}','{DateTime.Now}');";
                                SqlCommand cmd1 = new SqlCommand(Tmp1, db);
                                cmd1.ExecuteScalar();
                            }

                        }
                        db.Close();
                    }

                }

                #endregion
            }
        }
        #endregion

    }
}
