using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BaseHrm.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    PositionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.PositionId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "ShiftTypes",
                columns: table => new
                {
                    ShiftTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PayMultiplier = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftTypes", x => x.ShiftTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    MaxHoursPerDay = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    MaxHoursPerMonth = table.Column<decimal>(type: "decimal(7,2)", nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "PositionId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "RolePermissions",
                columns: table => new
                {
                    RolePermissionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    Module = table.Column<int>(type: "int", nullable: false),
                    Actions = table.Column<int>(type: "int", nullable: false),
                    ScopeType = table.Column<int>(type: "int", nullable: false),
                    ScopeValue = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermissions", x => x.RolePermissionId);
                    table.ForeignKey(
                        name: "FK_RolePermissions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shifts",
                columns: table => new
                {
                    ShiftId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    ExpectedHours = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    ShiftTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shifts", x => x.ShiftId);
                    table.ForeignKey(
                        name: "FK_Shifts_ShiftTypes_ShiftTypeId",
                        column: x => x.ShiftTypeId,
                        principalTable: "ShiftTypes",
                        principalColumn: "ShiftTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsMaster = table.Column<bool>(type: "bit", nullable: false),
                    LastLogin = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountId);
                    table.ForeignKey(
                        name: "FK_Accounts_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LeaderId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamId);
                    table.ForeignKey(
                        name: "FK_Teams_Employees_LeaderId",
                        column: x => x.LeaderId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "ShiftAssignments",
                columns: table => new
                {
                    ShiftAssignmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    ShiftId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApprovedByAccountId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftAssignments", x => x.ShiftAssignmentId);
                    table.ForeignKey(
                        name: "FK_ShiftAssignments_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShiftAssignments_Shifts_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Shifts",
                        principalColumn: "ShiftId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccountPermissions",
                columns: table => new
                {
                    AccountPermissionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    Module = table.Column<int>(type: "int", nullable: false),
                    Actions = table.Column<int>(type: "int", nullable: false),
                    ScopeType = table.Column<int>(type: "int", nullable: false),
                    ScopeValue = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountPermissions", x => x.AccountPermissionId);
                    table.ForeignKey(
                        name: "FK_AccountPermissions_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountRoles",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountRoles", x => new { x.AccountId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AccountRoles_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamMembers",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    IsLeader = table.Column<bool>(type: "bit", nullable: false),
                    JoinedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMembers", x => new { x.TeamId, x.EmployeeId });
                    table.ForeignKey(
                        name: "FK_TeamMembers_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamMembers_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttendanceRecords",
                columns: table => new
                {
                    AttendanceRecordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    CheckIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOut = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DurationHours = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    IsOvertime = table.Column<bool>(type: "bit", nullable: false),
                    ShiftAssignmentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceRecords", x => x.AttendanceRecordId);
                    table.ForeignKey(
                        name: "FK_AttendanceRecords_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttendanceRecords_ShiftAssignments_ShiftAssignmentId",
                        column: x => x.ShiftAssignmentId,
                        principalTable: "ShiftAssignments",
                        principalColumn: "ShiftAssignmentId");
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "PositionId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Develops software", "Software Engineer" },
                    { 2, "Manages projects", "Project Manager" },
                    { 3, "Handles HR tasks", "HR Specialist" },
                    { 4, "Creates designs", "Designer" },
                    { 5, "Analyzes data", "Analyst" },
                    { 6, "Tests software", "Tester" },
                    { 7, "Administers systems", "Administrator" },
                    { 8, "Handles sales", "Sales Representative" },
                    { 9, "Manages marketing", "Marketing Specialist" },
                    { 10, "Provides support", "Support Engineer" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Full access", "Master" },
                    { 2, "Administrative access", "Admin" },
                    { 3, "Manager access", "Manager" },
                    { 4, "Standard employee access", "Employee" },
                    { 5, "HR department access", "HR" },
                    { 6, "Finance access", "Finance" },
                    { 7, "IT support access", "IT" },
                    { 8, "Sales team access", "Sales" },
                    { 9, "Marketing access", "Marketing" },
                    { 10, "Limited guest access", "Guest" }
                });

            migrationBuilder.InsertData(
                table: "ShiftTypes",
                columns: new[] { "ShiftTypeId", "Name", "PayMultiplier" },
                values: new object[,]
                {
                    { 1, "Morning", 1.0m },
                    { 2, "Afternoon", 1.0m },
                    { 3, "Night", 1.5m },
                    { 4, "Weekend", 2.0m },
                    { 5, "Holiday", 2.5m },
                    { 6, "Overtime", 1.5m },
                    { 7, "Flexible", 1.0m },
                    { 8, "Remote", 1.0m },
                    { 9, "Part-time", 1.0m },
                    { 10, "Full-time", 1.0m }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Address", "DateOfBirth", "Email", "FirstName", "Gender", "HireDate", "IsActive", "LastName", "MaxHoursPerDay", "MaxHoursPerMonth", "Phone", "PositionId" },
                values: new object[,]
                {
                    { 1, "123 Main St", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.doe@example.com", "John", "Male", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Doe", 8.00m, 160.00m, "1234567890", 1 },
                    { 2, "456 Elm St", new DateTime(1985, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.smith@example.com", "Jane", "Female", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Smith", 8.00m, 160.00m, "0987654321", 2 },
                    { 3, "789 Oak St", new DateTime(1992, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "alice.johnson@example.com", "Alice", "Female", new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Johnson", 8.00m, 160.00m, "1112223334", 3 },
                    { 4, "101 Pine St", new DateTime(1988, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "bob.brown@example.com", "Bob", "Male", new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Brown", 8.00m, 160.00m, "4445556667", 4 },
                    { 5, "202 Maple St", new DateTime(1995, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "charlie.davis@example.com", "Charlie", "Male", new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Davis", 8.00m, 160.00m, "7778889990", 5 },
                    { 6, "303 Birch St", new DateTime(1991, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "diana.evans@example.com", "Diana", "Female", new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Evans", 8.00m, 160.00m, "3334445556", 6 },
                    { 7, "404 Cedar St", new DateTime(1987, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "ethan.franklin@example.com", "Ethan", "Male", new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Franklin", 8.00m, 160.00m, "6667778889", 7 },
                    { 8, "505 Spruce St", new DateTime(1993, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "fiona.garcia@example.com", "Fiona", "Female", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Garcia", 8.00m, 160.00m, "9990001112", 8 },
                    { 9, "606 Fir St", new DateTime(1989, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "george.harris@example.com", "George", "Male", new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Harris", 8.00m, 160.00m, "2223334445", 9 },
                    { 10, "707 Aspen St", new DateTime(1994, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "hannah.irving@example.com", "Hannah", "Female", new DateTime(2025, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Irving", 8.00m, 160.00m, "5556667778", 10 }
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "RolePermissionId", "Actions", "Module", "RoleId", "ScopeType", "ScopeValue" },
                values: new object[,]
                {
                    { 1, 3, 0, 1, 0, null },
                    { 2, 5, 1, 2, 0, null },
                    { 3, 9, 2, 3, 0, null },
                    { 4, 1, 4, 4, 0, null },
                    { 5, 6, 5, 5, 0, null },
                    { 6, 3, 3, 6, 0, null },
                    { 7, 12, 5, 7, 0, null },
                    { 8, 1, 0, 8, 0, null },
                    { 9, 2, 0, 9, 0, null },
                    { 10, 5, 1, 10, 0, null },
                    { 11, 15, 0, 1, 0, null },
                    { 12, 15, 1, 1, 0, null },
                    { 13, 15, 2, 1, 0, null },
                    { 14, 15, 3, 1, 0, null },
                    { 15, 15, 4, 1, 0, null },
                    { 16, 15, 5, 1, 0, null }
                });

            migrationBuilder.InsertData(
                table: "Shifts",
                columns: new[] { "ShiftId", "EndTime", "ExpectedHours", "Name", "ShiftTypeId", "StartTime" },
                values: new object[,]
                {
                    { 1, new TimeSpan(0, 12, 0, 0, 0), 4.0m, "Morning Shift 1", 1, new TimeSpan(0, 8, 0, 0, 0) },
                    { 2, new TimeSpan(0, 17, 0, 0, 0), 4.0m, "Afternoon Shift 1", 2, new TimeSpan(0, 13, 0, 0, 0) },
                    { 3, new TimeSpan(0, 22, 0, 0, 0), 4.0m, "Night Shift 1", 3, new TimeSpan(0, 18, 0, 0, 0) },
                    { 4, new TimeSpan(0, 18, 0, 0, 0), 9.0m, "Weekend Shift 1", 4, new TimeSpan(0, 9, 0, 0, 0) },
                    { 5, new TimeSpan(0, 14, 0, 0, 0), 4.0m, "Holiday Shift 1", 5, new TimeSpan(0, 10, 0, 0, 0) },
                    { 6, new TimeSpan(0, 20, 0, 0, 0), 3.0m, "Overtime Shift 1", 6, new TimeSpan(0, 17, 0, 0, 0) },
                    { 7, new TimeSpan(0, 17, 0, 0, 0), 8.0m, "Flexible Shift 1", 7, new TimeSpan(0, 9, 0, 0, 0) },
                    { 8, new TimeSpan(0, 16, 30, 0, 0), 8.0m, "Remote Shift 1", 8, new TimeSpan(0, 8, 30, 0, 0) },
                    { 9, new TimeSpan(0, 13, 0, 0, 0), 4.0m, "Part-time Shift 1", 9, new TimeSpan(0, 9, 0, 0, 0) },
                    { 10, new TimeSpan(0, 18, 0, 0, 0), 9.0m, "Full-time Shift 1", 10, new TimeSpan(0, 9, 0, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "EmployeeId", "IsMaster", "LastLogin", "PasswordHash", "Username" },
                values: new object[,]
                {
                    { 1, 1, false, null, "$2a$11$MP56nBCyKjSi.UD6pFbZ8OiGyTb.cIzXir2DlidtPFc428nfbU2wm", "john.doe" },
                    { 2, 2, false, null, "$2a$11$MP56nBCyKjSi.UD6pFbZ8OiGyTb.cIzXir2DlidtPFc428nfbU2wm", "jane.smith" },
                    { 3, 3, false, null, "$2a$11$MP56nBCyKjSi.UD6pFbZ8OiGyTb.cIzXir2DlidtPFc428nfbU2wm", "alice.johnson" },
                    { 4, 4, false, null, "$2a$11$MP56nBCyKjSi.UD6pFbZ8OiGyTb.cIzXir2DlidtPFc428nfbU2wm", "bob.brown" },
                    { 5, 5, false, null, "$2a$11$MP56nBCyKjSi.UD6pFbZ8OiGyTb.cIzXir2DlidtPFc428nfbU2wm", "charlie.davis" },
                    { 6, 6, false, null, "$2a$11$MP56nBCyKjSi.UD6pFbZ8OiGyTb.cIzXir2DlidtPFc428nfbU2wm", "diana.evans" },
                    { 7, 7, false, null, "$2a$11$MP56nBCyKjSi.UD6pFbZ8OiGyTb.cIzXir2DlidtPFc428nfbU2wm", "ethan.franklin" },
                    { 8, 8, false, null, "$2a$11$MP56nBCyKjSi.UD6pFbZ8OiGyTb.cIzXir2DlidtPFc428nfbU2wm", "fiona.garcia" },
                    { 9, 9, false, null, "$2a$11$MP56nBCyKjSi.UD6pFbZ8OiGyTb.cIzXir2DlidtPFc428nfbU2wm", "george.harris" },
                    { 10, 10, false, null, "$2a$11$MP56nBCyKjSi.UD6pFbZ8OiGyTb.cIzXir2DlidtPFc428nfbU2wm", "hannah.irving" }
                });

            migrationBuilder.InsertData(
                table: "ShiftAssignments",
                columns: new[] { "ShiftAssignmentId", "ApprovedByAccountId", "Date", "EmployeeId", "ShiftId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 2, 1, new DateTime(2025, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 3, 1, new DateTime(2025, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3 },
                    { 4, 1, new DateTime(2025, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 4 },
                    { 5, 1, new DateTime(2025, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 5 },
                    { 6, 1, new DateTime(2025, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 6 },
                    { 7, 1, new DateTime(2025, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 7 },
                    { 8, 1, new DateTime(2025, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 8 },
                    { 9, 1, new DateTime(2025, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 9 },
                    { 10, 1, new DateTime(2025, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 10 }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "TeamId", "CreatedAt", "LeaderId", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Team Alpha" },
                    { 2, new DateTime(2025, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Team Beta" },
                    { 3, new DateTime(2025, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Team Gamma" },
                    { 4, new DateTime(2025, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Team Delta" },
                    { 5, new DateTime(2025, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Team Epsilon" },
                    { 6, new DateTime(2025, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Team Zeta" },
                    { 7, new DateTime(2025, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "Team Eta" },
                    { 8, new DateTime(2025, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, "Team Theta" },
                    { 9, new DateTime(2025, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, "Team Iota" },
                    { 10, new DateTime(2025, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "Team Kappa" }
                });

            migrationBuilder.InsertData(
                table: "AccountPermissions",
                columns: new[] { "AccountPermissionId", "AccountId", "Actions", "Module", "ScopeType", "ScopeValue" },
                values: new object[,]
                {
                    { 1, 1, 1, 0, 0, null },
                    { 2, 2, 4, 1, 0, null },
                    { 3, 3, 2, 2, 0, null },
                    { 4, 4, 8, 4, 0, null },
                    { 5, 5, 5, 5, 0, null }
                });

            migrationBuilder.InsertData(
                table: "AccountRoles",
                columns: new[] { "AccountId", "RoleId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 },
                    { 6, 6 },
                    { 7, 7 },
                    { 8, 8 },
                    { 9, 9 },
                    { 10, 10 }
                });

            migrationBuilder.InsertData(
                table: "AttendanceRecords",
                columns: new[] { "AttendanceRecordId", "CheckIn", "CheckOut", "DurationHours", "EmployeeId", "IsOvertime", "ShiftAssignmentId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 23, 12, 0, 0, 0, DateTimeKind.Unspecified), 4.0m, 1, false, 1 },
                    { 2, new DateTime(2025, 9, 23, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), 4.0m, 2, false, 2 },
                    { 3, new DateTime(2025, 9, 23, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 23, 22, 0, 0, 0, DateTimeKind.Unspecified), 4.0m, 3, false, 3 },
                    { 4, new DateTime(2025, 9, 23, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 23, 18, 0, 0, 0, DateTimeKind.Unspecified), 9.0m, 4, false, 4 },
                    { 5, new DateTime(2025, 9, 23, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 23, 14, 0, 0, 0, DateTimeKind.Unspecified), 4.0m, 5, false, 5 },
                    { 6, new DateTime(2025, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 23, 20, 0, 0, 0, DateTimeKind.Unspecified), 3.0m, 6, false, 6 },
                    { 7, new DateTime(2025, 9, 23, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), 8.0m, 7, false, 7 },
                    { 8, new DateTime(2025, 9, 23, 8, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 23, 16, 30, 0, 0, DateTimeKind.Unspecified), 8.0m, 8, false, 8 },
                    { 9, new DateTime(2025, 9, 23, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 23, 13, 0, 0, 0, DateTimeKind.Unspecified), 4.0m, 9, false, 9 },
                    { 10, new DateTime(2025, 9, 23, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 23, 18, 0, 0, 0, DateTimeKind.Unspecified), 9.0m, 10, false, 10 }
                });

            migrationBuilder.InsertData(
                table: "TeamMembers",
                columns: new[] { "EmployeeId", "TeamId", "IsLeader", "JoinedAt" },
                values: new object[,]
                {
                    { 1, 1, true, new DateTime(2025, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, true, new DateTime(2025, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 3, true, new DateTime(2025, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 4, true, new DateTime(2025, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 5, true, new DateTime(2025, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 6, true, new DateTime(2025, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 7, true, new DateTime(2025, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 8, true, new DateTime(2025, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 9, true, new DateTime(2025, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 10, true, new DateTime(2025, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountPermissions_AccountId_Module_ScopeType_ScopeValue",
                table: "AccountPermissions",
                columns: new[] { "AccountId", "Module", "ScopeType", "ScopeValue" });

            migrationBuilder.CreateIndex(
                name: "IX_AccountRoles_RoleId",
                table: "AccountRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_EmployeeId",
                table: "Accounts",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_IsMaster",
                table: "Accounts",
                column: "IsMaster",
                unique: true,
                filter: "[IsMaster] = 1");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Username",
                table: "Accounts",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceRecords_EmployeeId",
                table: "AttendanceRecords",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceRecords_ShiftAssignmentId",
                table: "AttendanceRecords",
                column: "ShiftAssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PositionId",
                table: "Employees",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_RoleId_Module_ScopeType_ScopeValue",
                table: "RolePermissions",
                columns: new[] { "RoleId", "Module", "ScopeType", "ScopeValue" });

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Name",
                table: "Roles",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShiftAssignments_EmployeeId_Date",
                table: "ShiftAssignments",
                columns: new[] { "EmployeeId", "Date" });

            migrationBuilder.CreateIndex(
                name: "IX_ShiftAssignments_ShiftId",
                table: "ShiftAssignments",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_ShiftTypeId",
                table: "Shifts",
                column: "ShiftTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembers_EmployeeId",
                table: "TeamMembers",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_LeaderId",
                table: "Teams",
                column: "LeaderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountPermissions");

            migrationBuilder.DropTable(
                name: "AccountRoles");

            migrationBuilder.DropTable(
                name: "AttendanceRecords");

            migrationBuilder.DropTable(
                name: "RolePermissions");

            migrationBuilder.DropTable(
                name: "TeamMembers");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "ShiftAssignments");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Shifts");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "ShiftTypes");

            migrationBuilder.DropTable(
                name: "Positions");
        }
    }
}
