using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CChat.Migrations
{
    public partial class firstMigrationCChat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "HR");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CChatModules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    moduleName = table.Column<string>(nullable: true),
                    moduleNameBN = table.Column<string>(nullable: true),
                    shortOrder = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CChatModules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    companyName = table.Column<string>(maxLength: 250, nullable: true),
                    ownerName = table.Column<string>(maxLength: 250, nullable: true),
                    managerName = table.Column<string>(maxLength: 250, nullable: true),
                    tradeLicense = table.Column<string>(maxLength: 250, nullable: true),
                    businessNature = table.Column<string>(maxLength: 250, nullable: true),
                    officeTelephone = table.Column<string>(maxLength: 150, nullable: true),
                    vatNo = table.Column<string>(maxLength: 150, nullable: true),
                    tinNo = table.Column<string>(maxLength: 150, nullable: true),
                    dateOfEstablishment = table.Column<DateTime>(nullable: true),
                    permanentEmployee = table.Column<int>(nullable: true),
                    companyEmail = table.Column<string>(maxLength: 150, nullable: true),
                    alternetEmail = table.Column<string>(maxLength: 150, nullable: true),
                    addressLine = table.Column<string>(nullable: true),
                    liquidityRatio = table.Column<decimal>(nullable: true),
                    fileName = table.Column<string>(maxLength: 250, nullable: true),
                    filePath = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbChangeHistories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    entityName = table.Column<string>(maxLength: 300, nullable: true),
                    entityState = table.Column<string>(maxLength: 100, nullable: true),
                    fieldName = table.Column<string>(maxLength: 200, nullable: true),
                    fieldValue = table.Column<string>(nullable: true),
                    sessionId = table.Column<int>(nullable: true),
                    remarks = table.Column<string>(maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbChangeHistories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserLogHistories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    userId = table.Column<string>(maxLength: 250, nullable: true),
                    logTime = table.Column<string>(maxLength: 250, nullable: true),
                    status = table.Column<int>(nullable: true),
                    ipAddress = table.Column<string>(maxLength: 250, nullable: true),
                    browserName = table.Column<string>(maxLength: 250, nullable: true),
                    pcName = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogHistories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTypeGroup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    groupTypeNameBN = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    groupTypeName = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    shortOrder = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTypeGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                schema: "HR",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    deptCode = table.Column<string>(nullable: true),
                    deptName = table.Column<string>(nullable: false),
                    deptNameBn = table.Column<string>(nullable: true),
                    shortName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpecialBranchUnit",
                schema: "HR",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    branchUnitName = table.Column<string>(nullable: true),
                    branchUnitNameBN = table.Column<string>(nullable: true),
                    branchCode = table.Column<string>(nullable: true),
                    companyId = table.Column<int>(nullable: true),
                    shortOrder = table.Column<int>(nullable: true),
                    CCCatID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialBranchUnit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecialBranchUnit_Company_companyId",
                        column: x => x.companyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    userTypeNameBn = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    userTypeName = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    groupId = table.Column<int>(nullable: true),
                    shortOrder = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserType_UserTypeGroup_groupId",
                        column: x => x.groupId,
                        principalTable: "UserTypeGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    userTypeId = table.Column<int>(nullable: true),
                    EmpCode = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    userId = table.Column<int>(nullable: false),
                    companyId = table.Column<int>(nullable: true),
                    MaxAmount = table.Column<decimal>(nullable: true),
                    isActive = table.Column<int>(nullable: true),
                    org = table.Column<string>(maxLength: 120, nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 120, nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    updatedBy = table.Column<string>(maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Company_companyId",
                        column: x => x.companyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_UserType_userTypeId",
                        column: x => x.userTypeId,
                        principalTable: "UserType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeInfo",
                schema: "HR",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    employeeCode = table.Column<string>(maxLength: 50, nullable: false),
                    nationalID = table.Column<string>(maxLength: 100, nullable: true),
                    birthIdentificationNo = table.Column<string>(maxLength: 100, nullable: true),
                    govtID = table.Column<string>(maxLength: 250, nullable: true),
                    gpfNomineeName = table.Column<string>(nullable: true),
                    gpfAcNo = table.Column<string>(nullable: true),
                    nameEnglish = table.Column<string>(nullable: true),
                    nameBangla = table.Column<string>(nullable: true),
                    motherNameEnglish = table.Column<string>(nullable: true),
                    motherNameBangla = table.Column<string>(nullable: true),
                    fatherNameEnglish = table.Column<string>(nullable: true),
                    fatherNameBangla = table.Column<string>(nullable: true),
                    nationality = table.Column<string>(nullable: true),
                    disability = table.Column<string>(nullable: true),
                    dateOfBirth = table.Column<DateTime>(nullable: true),
                    joiningDatePresentWorkstation = table.Column<DateTime>(nullable: true),
                    joiningDateGovtService = table.Column<DateTime>(nullable: true),
                    dateofregularity = table.Column<DateTime>(nullable: true),
                    dateOfPermanent = table.Column<DateTime>(nullable: true),
                    LPRDate = table.Column<string>(nullable: true),
                    PRLStartDate = table.Column<string>(nullable: true),
                    PRLEndDate = table.Column<string>(nullable: true),
                    gender = table.Column<string>(nullable: true),
                    birthPlace = table.Column<string>(nullable: true),
                    maritalStatus = table.Column<string>(nullable: true),
                    activityStatus = table.Column<int>(nullable: true),
                    departmentId = table.Column<int>(nullable: true),
                    tin = table.Column<string>(nullable: true),
                    batch = table.Column<string>(nullable: true),
                    bloodGroup = table.Column<string>(nullable: true),
                    freedomFighter = table.Column<bool>(nullable: false),
                    freedomFighterNo = table.Column<string>(nullable: true),
                    telephoneOffice = table.Column<string>(nullable: true),
                    telephoneResidence = table.Column<string>(nullable: true),
                    pabx = table.Column<string>(nullable: true),
                    emailAddress = table.Column<string>(nullable: true),
                    emailAddressPersonal = table.Column<string>(nullable: true),
                    mobileNumberOffice = table.Column<string>(maxLength: 50, nullable: true),
                    mobileNumberPersonal = table.Column<string>(maxLength: 50, nullable: true),
                    specialSkill = table.Column<string>(nullable: true),
                    seniorityNumber = table.Column<string>(maxLength: 50, nullable: true),
                    designation = table.Column<string>(nullable: true),
                    skypeId = table.Column<string>(nullable: true),
                    post = table.Column<int>(nullable: true),
                    designationCheck = table.Column<int>(nullable: false),
                    joiningDesignation = table.Column<string>(nullable: true),
                    natureOfRequitment = table.Column<string>(maxLength: 100, nullable: true),
                    homeDistrict = table.Column<string>(nullable: true),
                    branchId = table.Column<int>(nullable: true),
                    orgType = table.Column<string>(maxLength: 100, nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeInfo_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeInfo_SpecialBranchUnit_branchId",
                        column: x => x.branchId,
                        principalSchema: "HR",
                        principalTable: "SpecialBranchUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeInfo_Department_departmentId",
                        column: x => x.departmentId,
                        principalSchema: "HR",
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_companyId",
                table: "AspNetUsers",
                column: "companyId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_userTypeId",
                table: "AspNetUsers",
                column: "userTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserType_groupId",
                table: "UserType",
                column: "groupId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeInfo_ApplicationUserId",
                schema: "HR",
                table: "EmployeeInfo",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeInfo_branchId",
                schema: "HR",
                table: "EmployeeInfo",
                column: "branchId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeInfo_departmentId",
                schema: "HR",
                table: "EmployeeInfo",
                column: "departmentId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialBranchUnit_companyId",
                schema: "HR",
                table: "SpecialBranchUnit",
                column: "companyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CChatModules");

            migrationBuilder.DropTable(
                name: "DbChangeHistories");

            migrationBuilder.DropTable(
                name: "UserLogHistories");

            migrationBuilder.DropTable(
                name: "EmployeeInfo",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "SpecialBranchUnit",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "Department",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "UserType");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "UserTypeGroup");
        }
    }
}
