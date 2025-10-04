using BaseHrm.Data.Enums;
using BaseHrm.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseHrm.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts) { }

        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Team> Teams => Set<Team>();
        public DbSet<TeamMember> TeamMembers => Set<TeamMember>();
        public DbSet<Account> Accounts => Set<Account>();
        public DbSet<Shift> Shifts => Set<Shift>();
        public DbSet<ShiftAssignment> ShiftAssignments => Set<ShiftAssignment>();
        public DbSet<AttendanceRecord> AttendanceRecords => Set<AttendanceRecord>();
        public DbSet<Position> Positions => Set<Position>();
        public DbSet<ShiftType> ShiftTypes { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<RolePermission> RolePermissions { get; set; } = null!;
        public DbSet<AccountRole> AccountRoles { get; set; } = null!;
        public DbSet<AccountPermission> AccountPermissions { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Employee
            builder.Entity<Employee>(eb =>
            {
                eb.HasKey(e => e.EmployeeId);
                eb.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
                eb.Property(e => e.LastName).HasMaxLength(100).IsRequired();
                eb.Property(e => e.Email).HasMaxLength(200);
                eb.Property(e => e.Phone).HasMaxLength(50);
                eb.Property(e => e.Address).HasMaxLength(500);

                eb.Property(e => e.MaxHoursPerDay).HasColumnType("decimal(5,2)");
                eb.Property(e => e.MaxHoursPerMonth).HasColumnType("decimal(7,2)");
                eb.HasOne(x => x.Position)
                 .WithMany(p => p.Employees)
                 .HasForeignKey(x => x.PositionId)
                 .OnDelete(DeleteBehavior.SetNull);
            });

            // Team
            builder.Entity<Team>(tb =>
            {
                tb.HasKey(t => t.TeamId);
                tb.Property(t => t.Name).HasMaxLength(200).IsRequired();

                tb.HasOne(t => t.Leader)
                  .WithMany()
                  .HasForeignKey(t => t.LeaderId)
                  .OnDelete(DeleteBehavior.SetNull);
            });

            // TeamMember (composite key)
            builder.Entity<TeamMember>(tm =>
            {
                tm.HasKey(x => new { x.TeamId, x.EmployeeId });
                tm.HasOne(x => x.Team).WithMany(t => t.Members).HasForeignKey(x => x.TeamId).OnDelete(DeleteBehavior.Cascade);
                tm.HasOne(x => x.Employee).WithMany(e => e.TeamMemberships).HasForeignKey(x => x.EmployeeId);
            });

            // Account
            builder.Entity<Account>(ab =>
            {
                ab.HasKey(a => a.AccountId);
                ab.HasIndex(a => a.Username).IsUnique();
                ab.HasIndex(a => a.IsMaster)
                  .IsUnique()
                  .HasFilter("[IsMaster] = 1");

                ab.HasOne(a => a.Employee).WithOne(e => e.Account).HasForeignKey<Account>(a => a.EmployeeId);
                ab.Property(a => a.Username).HasMaxLength(100).IsRequired();
                ab.Property(a => a.PasswordHash).HasMaxLength(500).IsRequired();
            });

            // Shift
            builder.Entity<Shift>(sb =>
            {
                sb.HasKey(s => s.ShiftId);
                sb.Property(s => s.Name).HasMaxLength(100).IsRequired();
                sb.Property(s => s.ExpectedHours).HasColumnType("decimal(5,2)");
            });
            builder.Entity<ShiftType>(st =>
            {
                st.HasKey(x => x.ShiftTypeId);
                st.Property(x => x.Name)
                  .HasMaxLength(200)
                  .IsRequired();

                st.Property(x => x.PayMultiplier)
                  .HasPrecision(5, 2)
                  .IsRequired();

                st.HasMany(x => x.Shifts)
                  .WithOne(s => s.ShiftType)
                  .HasForeignKey(s => s.ShiftTypeId)
                  .OnDelete(DeleteBehavior.Restrict);
            });

            // ShiftAssignment
            builder.Entity<ShiftAssignment>(sa =>
            {
                sa.HasKey(s => s.ShiftAssignmentId);
                sa.HasIndex(s => new { s.EmployeeId, s.Date }).IsUnique(false);
                sa.HasOne(s => s.Employee)
                  .WithMany(e => e.ShiftAssignments)
                  .HasForeignKey(s => s.EmployeeId)
                  .OnDelete(DeleteBehavior.Cascade);
                sa.HasOne(s => s.Shift)
                  .WithMany()
                  .HasForeignKey(s => s.ShiftId)
                  .OnDelete(DeleteBehavior.Restrict);
            });

            // AttendanceRecord
            builder.Entity<AttendanceRecord>(ab =>
            {
                ab.HasKey(a => a.AttendanceRecordId);
                ab.HasOne(a => a.Employee)
                  .WithMany(e => e.AttendanceRecords)
                  .HasForeignKey(a => a.EmployeeId)
                  .OnDelete(DeleteBehavior.Cascade);
                ab.HasOne(a => a.ShiftAssignment)
                  .WithMany()
                  .HasForeignKey(a => a.ShiftAssignmentId)
                  .OnDelete(DeleteBehavior.NoAction);
                ab.Property(a => a.DurationHours)
                  .HasColumnType("decimal(5,2)");
            });

            builder.Entity<Position>(p =>
            {
                p.HasKey(x => x.PositionId);
                p.Property(x => x.Name).IsRequired().HasMaxLength(100);
                p.Property(x => x.Description).HasMaxLength(255);
            });

            builder.Entity<Role>(e =>
            {
                e.HasKey(r => r.RoleId);
                e.Property(r => r.Name).IsRequired().HasMaxLength(200);
                e.HasIndex(r => r.Name).IsUnique();
                e.Property(r => r.Description).HasMaxLength(1000);
            });

            builder.Entity<RolePermission>(e =>
            {
                e.HasKey(rp => rp.RolePermissionId);

                e.HasOne(rp => rp.Role)
                 .WithMany(r => r.RolePermissions)
                 .HasForeignKey(rp => rp.RoleId)
                 .OnDelete(DeleteBehavior.Cascade);

                e.Property(rp => rp.Module).HasConversion<int>().IsRequired();
                e.Property(rp => rp.Actions).HasConversion<int>().IsRequired();
                e.Property(rp => rp.ScopeType).HasConversion<int>().IsRequired();

                e.HasIndex(rp => new { rp.RoleId, rp.Module, rp.ScopeType, rp.ScopeValue });
            });

            builder.Entity<AccountRole>(e =>
            {
                e.HasKey(ar => new { ar.AccountId, ar.RoleId });

                e.HasOne(ar => ar.Account)
                 .WithMany(a => a.AccountRoles)
                 .HasForeignKey(ar => ar.AccountId)
                 .OnDelete(DeleteBehavior.Cascade);

                e.HasOne(ar => ar.Role)
                 .WithMany(r => r.AccountRoles)
                 .HasForeignKey(ar => ar.RoleId)
                 .OnDelete(DeleteBehavior.Cascade);
            });

            // --- AccountPermission ---
            builder.Entity<AccountPermission>(e =>
            {
                e.HasKey(ap => ap.AccountPermissionId);

                e.HasOne(ap => ap.Account)
                 .WithMany(a => a.AccountPermissions)
                 .HasForeignKey(ap => ap.AccountId)
                 .OnDelete(DeleteBehavior.Cascade);

                e.Property(ap => ap.Module).HasConversion<int>().IsRequired();
                e.Property(ap => ap.Actions).HasConversion<int>().IsRequired();
                e.Property(ap => ap.ScopeType).HasConversion<int>().IsRequired();

                e.HasIndex(ap => new { ap.AccountId, ap.Module, ap.ScopeType, ap.ScopeValue });
            });

            // Seeding data

            // Seed Positions (10 samples)
            builder.Entity<Position>().HasData(
                new Position { PositionId = 1, Name = "Software Engineer", Description = "Develops software" },
                new Position { PositionId = 2, Name = "Project Manager", Description = "Manages projects" },
                new Position { PositionId = 3, Name = "HR Specialist", Description = "Handles HR tasks" },
                new Position { PositionId = 4, Name = "Designer", Description = "Creates designs" },
                new Position { PositionId = 5, Name = "Analyst", Description = "Analyzes data" },
                new Position { PositionId = 6, Name = "Tester", Description = "Tests software" },
                new Position { PositionId = 7, Name = "Administrator", Description = "Administers systems" },
                new Position { PositionId = 8, Name = "Sales Representative", Description = "Handles sales" },
                new Position { PositionId = 9, Name = "Marketing Specialist", Description = "Manages marketing" },
                new Position { PositionId = 10, Name = "Support Engineer", Description = "Provides support" }
            );

            // Seed ShiftTypes (10 samples)
            builder.Entity<ShiftType>().HasData(
                new ShiftType { ShiftTypeId = 1, Name = "Morning", PayMultiplier = 1.0m },
                new ShiftType { ShiftTypeId = 2, Name = "Afternoon", PayMultiplier = 1.0m },
                new ShiftType { ShiftTypeId = 3, Name = "Night", PayMultiplier = 1.5m },
                new ShiftType { ShiftTypeId = 4, Name = "Weekend", PayMultiplier = 2.0m },
                new ShiftType { ShiftTypeId = 5, Name = "Holiday", PayMultiplier = 2.5m },
                new ShiftType { ShiftTypeId = 6, Name = "Overtime", PayMultiplier = 1.5m },
                new ShiftType { ShiftTypeId = 7, Name = "Flexible", PayMultiplier = 1.0m },
                new ShiftType { ShiftTypeId = 8, Name = "Remote", PayMultiplier = 1.0m },
                new ShiftType { ShiftTypeId = 9, Name = "Part-time", PayMultiplier = 1.0m },
                new ShiftType { ShiftTypeId = 10, Name = "Full-time", PayMultiplier = 1.0m }
            );

            // Seed Shifts (10 samples, linked to ShiftTypes 1-10)
            builder.Entity<Shift>().HasData(
                new Shift { ShiftId = 1, Name = "Morning Shift 1", StartTime = new TimeSpan(8, 0, 0), EndTime = new TimeSpan(12, 0, 0), ExpectedHours = 4.0m, ShiftTypeId = 1 },
                new Shift { ShiftId = 2, Name = "Afternoon Shift 1", StartTime = new TimeSpan(13, 0, 0), EndTime = new TimeSpan(17, 0, 0), ExpectedHours = 4.0m, ShiftTypeId = 2 },
                new Shift { ShiftId = 3, Name = "Night Shift 1", StartTime = new TimeSpan(18, 0, 0), EndTime = new TimeSpan(22, 0, 0), ExpectedHours = 4.0m, ShiftTypeId = 3 },
                new Shift { ShiftId = 4, Name = "Weekend Shift 1", StartTime = new TimeSpan(9, 0, 0), EndTime = new TimeSpan(18, 0, 0), ExpectedHours = 9.0m, ShiftTypeId = 4 },
                new Shift { ShiftId = 5, Name = "Holiday Shift 1", StartTime = new TimeSpan(10, 0, 0), EndTime = new TimeSpan(14, 0, 0), ExpectedHours = 4.0m, ShiftTypeId = 5 },
                new Shift { ShiftId = 6, Name = "Overtime Shift 1", StartTime = new TimeSpan(17, 0, 0), EndTime = new TimeSpan(20, 0, 0), ExpectedHours = 3.0m, ShiftTypeId = 6 },
                new Shift { ShiftId = 7, Name = "Flexible Shift 1", StartTime = new TimeSpan(9, 0, 0), EndTime = new TimeSpan(17, 0, 0), ExpectedHours = 8.0m, ShiftTypeId = 7 },
                new Shift { ShiftId = 8, Name = "Remote Shift 1", StartTime = new TimeSpan(8, 30, 0), EndTime = new TimeSpan(16, 30, 0), ExpectedHours = 8.0m, ShiftTypeId = 8 },
                new Shift { ShiftId = 9, Name = "Part-time Shift 1", StartTime = new TimeSpan(9, 0, 0), EndTime = new TimeSpan(13, 0, 0), ExpectedHours = 4.0m, ShiftTypeId = 9 },
                new Shift { ShiftId = 10, Name = "Full-time Shift 1", StartTime = new TimeSpan(9, 0, 0), EndTime = new TimeSpan(18, 0, 0), ExpectedHours = 9.0m, ShiftTypeId = 10 }
            );

            // Seed Employees (10 samples)
            builder.Entity<Employee>().HasData(
                new Employee { EmployeeId = 1, FirstName = "John", LastName = "Doe", DateOfBirth = new DateTime(1990, 1, 1), Gender = "Nam", Email = "john.doe@example.com", Phone = "1234567890", Address = "123 Main St", HireDate = new DateTime(2025, 1, 1), PositionId = 1 },
                new Employee { EmployeeId = 2, FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateTime(1985, 2, 2), Gender = "Nữ", Email = "jane.smith@example.com", Phone = "0987654321", Address = "456 Elm St", HireDate = new DateTime(2025, 2, 1), PositionId = 2 },
                new Employee { EmployeeId = 3, FirstName = "Alice", LastName = "Johnson", DateOfBirth = new DateTime(1992, 3, 3), Gender = "Nữ", Email = "alice.johnson@example.com", Phone = "1112223334", Address = "789 Oak St", HireDate = new DateTime(2025, 3, 1), PositionId = 3 },
                new Employee { EmployeeId = 4, FirstName = "Bob", LastName = "Brown", DateOfBirth = new DateTime(1988, 4, 4), Gender = "Nam", Email = "bob.brown@example.com", Phone = "4445556667", Address = "101 Pine St", HireDate = new DateTime(2025, 4, 1), PositionId = 4 },
                new Employee { EmployeeId = 5, FirstName = "Charlie", LastName = "Davis", DateOfBirth = new DateTime(1995, 5, 5), Gender = "Nam", Email = "charlie.davis@example.com", Phone = "7778889990", Address = "202 Maple St", HireDate = new DateTime(2025, 5, 1), PositionId = 5 },
                new Employee { EmployeeId = 6, FirstName = "Diana", LastName = "Evans", DateOfBirth = new DateTime(1991, 6, 6), Gender = "Nữ", Email = "diana.evans@example.com", Phone = "3334445556", Address = "303 Birch St", HireDate = new DateTime(2025, 6, 1), PositionId = 6 },
                new Employee { EmployeeId = 7, FirstName = "Ethan", LastName = "Franklin", DateOfBirth = new DateTime(1987, 7, 7), Gender = "Nam", Email = "ethan.franklin@example.com", Phone = "6667778889", Address = "404 Cedar St", HireDate = new DateTime(2025, 7, 1), PositionId = 7 },
                new Employee { EmployeeId = 8, FirstName = "Fiona", LastName = "Garcia", DateOfBirth = new DateTime(1993, 8, 8), Gender = "Nữ", Email = "fiona.garcia@example.com", Phone = "9990001112", Address = "505 Spruce St", HireDate = new DateTime(2025, 8, 1), PositionId = 8 },
                new Employee { EmployeeId = 9, FirstName = "George", LastName = "Harris", DateOfBirth = new DateTime(1989, 9, 9), Gender = "Nam", Email = "george.harris@example.com", Phone = "2223334445", Address = "606 Fir St", HireDate = new DateTime(2025, 9, 1), PositionId = 9 },
                new Employee { EmployeeId = 10, FirstName = "Hannah", LastName = "Irving", DateOfBirth = new DateTime(1994, 10, 10), Gender = "Nữ", Email = "hannah.irving@example.com", Phone = "5556667778", Address = "707 Aspen St", HireDate = new DateTime(2025, 10, 1), PositionId = 10 }
            );

            // Seed Accounts (10 samples, linked to Employees 1-10)
            builder.Entity<Account>().HasData(
                new Account { AccountId = 1, EmployeeId = 1, Username = "john.doe", PasswordHash = "$2a$12$a/MI775Gp/RqAH3yOpLyc.LiemMXjZndSislMwLbbbY4Mgu4EFxii", IsMaster = false },
                new Account { AccountId = 2, EmployeeId = 2, Username = "jane.smith", PasswordHash = "$2a$12$a/MI775Gp/RqAH3yOpLyc.LiemMXjZndSislMwLbbbY4Mgu4EFxii", IsMaster = false },
                new Account { AccountId = 3, EmployeeId = 3, Username = "alice.johnson", PasswordHash = "$2a$12$a/MI775Gp/RqAH3yOpLyc.LiemMXjZndSislMwLbbbY4Mgu4EFxii", IsMaster = false },
                new Account { AccountId = 4, EmployeeId = 4, Username = "bob.brown", PasswordHash = "$2a$12$a/MI775Gp/RqAH3yOpLyc.LiemMXjZndSislMwLbbbY4Mgu4EFxii", IsMaster = false },
                new Account { AccountId = 5, EmployeeId = 5, Username = "charlie.davis", PasswordHash = "$2a$12$a/MI775Gp/RqAH3yOpLyc.LiemMXjZndSislMwLbbbY4Mgu4EFxii", IsMaster = false },
                new Account { AccountId = 6, EmployeeId = 6, Username = "diana.evans", PasswordHash = "$2a$12$a/MI775Gp/RqAH3yOpLyc.LiemMXjZndSislMwLbbbY4Mgu4EFxii", IsMaster = false },
                new Account { AccountId = 7, EmployeeId = 7, Username = "ethan.franklin", PasswordHash = "$2a$12$a/MI775Gp/RqAH3yOpLyc.LiemMXjZndSislMwLbbbY4Mgu4EFxii", IsMaster = false },
                new Account { AccountId = 8, EmployeeId = 8, Username = "fiona.garcia", PasswordHash = "$2a$12$a/MI775Gp/RqAH3yOpLyc.LiemMXjZndSislMwLbbbY4Mgu4EFxii", IsMaster = false },
                new Account { AccountId = 9, EmployeeId = 9, Username = "george.harris", PasswordHash = "$2a$12$a/MI775Gp/RqAH3yOpLyc.LiemMXjZndSislMwLbbbY4Mgu4EFxii", IsMaster = false },
                new Account { AccountId = 10, EmployeeId = 10, Username = "hannah.irving", PasswordHash = "$2a$12$a/MI775Gp/RqAH3yOpLyc.LiemMXjZndSislMwLbbbY4Mgu4EFxii", IsMaster = false }
            );

            // Seed Roles (10 samples, including Master as 1)
            builder.Entity<Role>().HasData(
                new Role { RoleId = 1, Name = "Master", Description = "Full access" },
                new Role { RoleId = 2, Name = "Admin", Description = "Administrative access" },
                new Role { RoleId = 3, Name = "Manager", Description = "Manager access" },
                new Role { RoleId = 4, Name = "Employee", Description = "Standard employee access" },
                new Role { RoleId = 5, Name = "HR", Description = "HR department access" },
                new Role { RoleId = 6, Name = "Finance", Description = "Finance access" },
                new Role { RoleId = 7, Name = "IT", Description = "IT support access" },
                new Role { RoleId = 8, Name = "Sales", Description = "Sales team access" },
                new Role { RoleId = 9, Name = "Marketing", Description = "Marketing access" },
                new Role { RoleId = 10, Name = "Guest", Description = "Limited guest access" }
            );

            // Seed Teams (10 samples, leaders from Employees 1-10)
            builder.Entity<Team>().HasData(
                new Team { TeamId = 1, Name = "Team Alpha", LeaderId = 1, CreatedAt = new DateTime(2025, 9, 23) },
                new Team { TeamId = 2, Name = "Team Beta", LeaderId = 2, CreatedAt = new DateTime(2025, 9, 23) },
                new Team { TeamId = 3, Name = "Team Gamma", LeaderId = 3, CreatedAt = new DateTime(2025, 9, 23) },
                new Team { TeamId = 4, Name = "Team Delta", LeaderId = 4, CreatedAt = new DateTime(2025, 9, 23) },
                new Team { TeamId = 5, Name = "Team Epsilon", LeaderId = 5, CreatedAt = new DateTime(2025, 9, 23) },
                new Team { TeamId = 6, Name = "Team Zeta", LeaderId = 6, CreatedAt = new DateTime(2025, 9, 23) },
                new Team { TeamId = 7, Name = "Team Eta", LeaderId = 7, CreatedAt = new DateTime(2025, 9, 23) },
                new Team { TeamId = 8, Name = "Team Theta", LeaderId = 8, CreatedAt = new DateTime(2025, 9, 23) },
                new Team { TeamId = 9, Name = "Team Iota", LeaderId = 9, CreatedAt = new DateTime(2025, 9, 23) },
                new Team { TeamId = 10, Name = "Team Kappa", LeaderId = 10, CreatedAt = new DateTime(2025, 9, 23) }
            );

            // Seed TeamMembers (10 samples, linking Employees 1-10 to Teams 1-10)
            builder.Entity<TeamMember>().HasData(
                new TeamMember { TeamId = 1, EmployeeId = 1, IsLeader = true, JoinedAt = new DateTime(2025, 9, 23) },
                new TeamMember { TeamId = 2, EmployeeId = 2, IsLeader = true, JoinedAt = new DateTime(2025, 9, 23) },
                new TeamMember { TeamId = 3, EmployeeId = 3, IsLeader = true, JoinedAt = new DateTime(2025, 9, 23) },
                new TeamMember { TeamId = 4, EmployeeId = 4, IsLeader = true, JoinedAt = new DateTime(2025, 9, 23) },
                new TeamMember { TeamId = 5, EmployeeId = 5, IsLeader = true, JoinedAt = new DateTime(2025, 9, 23) },
                new TeamMember { TeamId = 6, EmployeeId = 6, IsLeader = true, JoinedAt = new DateTime(2025, 9, 23) },
                new TeamMember { TeamId = 7, EmployeeId = 7, IsLeader = true, JoinedAt = new DateTime(2025, 9, 23) },
                new TeamMember { TeamId = 8, EmployeeId = 8, IsLeader = true, JoinedAt = new DateTime(2025, 9, 23) },
                new TeamMember { TeamId = 9, EmployeeId = 9, IsLeader = true, JoinedAt = new DateTime(2025, 9, 23) },
                new TeamMember { TeamId = 10, EmployeeId = 10, IsLeader = true, JoinedAt = new DateTime(2025, 9, 23) }
            );

            // Seed ShiftAssignments (10 samples, for Employees 1-10, Shifts 1-10)
            builder.Entity<ShiftAssignment>().HasData(
                new ShiftAssignment { ShiftAssignmentId = 1, EmployeeId = 1, ShiftId = 1, Date = new DateTime(2025, 9, 23), ApprovedByAccountId = 1 },
                new ShiftAssignment { ShiftAssignmentId = 2, EmployeeId = 2, ShiftId = 2, Date = new DateTime(2025, 9, 23), ApprovedByAccountId = 1 },
                new ShiftAssignment { ShiftAssignmentId = 3, EmployeeId = 3, ShiftId = 3, Date = new DateTime(2025, 9, 23), ApprovedByAccountId = 1 },
                new ShiftAssignment { ShiftAssignmentId = 4, EmployeeId = 4, ShiftId = 4, Date = new DateTime(2025, 9, 23), ApprovedByAccountId = 1 },
                new ShiftAssignment { ShiftAssignmentId = 5, EmployeeId = 5, ShiftId = 5, Date = new DateTime(2025, 9, 23), ApprovedByAccountId = 1 },
                new ShiftAssignment { ShiftAssignmentId = 6, EmployeeId = 6, ShiftId = 6, Date = new DateTime(2025, 9, 23), ApprovedByAccountId = 1 },
                new ShiftAssignment { ShiftAssignmentId = 7, EmployeeId = 7, ShiftId = 7, Date = new DateTime(2025, 9, 23), ApprovedByAccountId = 1 },
                new ShiftAssignment { ShiftAssignmentId = 8, EmployeeId = 8, ShiftId = 8, Date = new DateTime(2025, 9, 23), ApprovedByAccountId = 1 },
                new ShiftAssignment { ShiftAssignmentId = 9, EmployeeId = 9, ShiftId = 9, Date = new DateTime(2025, 9, 23), ApprovedByAccountId = 1 },
                new ShiftAssignment { ShiftAssignmentId = 10, EmployeeId = 10, ShiftId = 10, Date = new DateTime(2025, 9, 23), ApprovedByAccountId = 1 }
            );

            // Seed AttendanceRecords (10 samples, for Employees 1-10, linked to ShiftAssignments 1-10)
            builder.Entity<AttendanceRecord>().HasData(
                new AttendanceRecord { AttendanceRecordId = 1, EmployeeId = 1, CheckIn = new DateTime(2025, 9, 23, 8, 0, 0), CheckOut = new DateTime(2025, 9, 23, 12, 0, 0), DurationHours = 4.0m, ShiftAssignmentId = 1 },
                new AttendanceRecord { AttendanceRecordId = 2, EmployeeId = 2, CheckIn = new DateTime(2025, 9, 23, 13, 0, 0), CheckOut = new DateTime(2025, 9, 23, 17, 0, 0), DurationHours = 4.0m, ShiftAssignmentId = 2 },
                new AttendanceRecord { AttendanceRecordId = 3, EmployeeId = 3, CheckIn = new DateTime(2025, 9, 23, 18, 0, 0), CheckOut = new DateTime(2025, 9, 23, 22, 0, 0), DurationHours = 4.0m, ShiftAssignmentId = 3 },
                new AttendanceRecord { AttendanceRecordId = 4, EmployeeId = 4, CheckIn = new DateTime(2025, 9, 23, 9, 0, 0), CheckOut = new DateTime(2025, 9, 23, 18, 0, 0), DurationHours = 9.0m, ShiftAssignmentId = 4 },
                new AttendanceRecord { AttendanceRecordId = 5, EmployeeId = 5, CheckIn = new DateTime(2025, 9, 23, 10, 0, 0), CheckOut = new DateTime(2025, 9, 23, 14, 0, 0), DurationHours = 4.0m, ShiftAssignmentId = 5 },
                new AttendanceRecord { AttendanceRecordId = 6, EmployeeId = 6, CheckIn = new DateTime(2025, 9, 23, 17, 0, 0), CheckOut = new DateTime(2025, 9, 23, 20, 0, 0), DurationHours = 3.0m, ShiftAssignmentId = 6 },
                new AttendanceRecord { AttendanceRecordId = 7, EmployeeId = 7, CheckIn = new DateTime(2025, 9, 23, 9, 0, 0), CheckOut = new DateTime(2025, 9, 23, 17, 0, 0), DurationHours = 8.0m, ShiftAssignmentId = 7 },
                new AttendanceRecord { AttendanceRecordId = 8, EmployeeId = 8, CheckIn = new DateTime(2025, 9, 23, 8, 30, 0), CheckOut = new DateTime(2025, 9, 23, 16, 30, 0), DurationHours = 8.0m, ShiftAssignmentId = 8 },
                new AttendanceRecord { AttendanceRecordId = 9, EmployeeId = 9, CheckIn = new DateTime(2025, 9, 23, 9, 0, 0), CheckOut = new DateTime(2025, 9, 23, 13, 0, 0), DurationHours = 4.0m, ShiftAssignmentId = 9 },
                new AttendanceRecord { AttendanceRecordId = 10, EmployeeId = 10, CheckIn = new DateTime(2025, 9, 23, 9, 0, 0), CheckOut = new DateTime(2025, 9, 23, 18, 0, 0), DurationHours = 9.0m, ShiftAssignmentId = 10 }
            );

            // Seed RolePermissions (10 samples, for Roles 1-10)
            builder.Entity<RolePermission>().HasData(
                new RolePermission { RolePermissionId = 1, RoleId = 1, Module = ModuleName.Employee, Actions = PermissionAction.View | PermissionAction.Create, ScopeType = ScopeType.Global },
                new RolePermission { RolePermissionId = 2, RoleId = 2, Module = ModuleName.Team, Actions = PermissionAction.View | PermissionAction.Edit, ScopeType = ScopeType.Global },
                new RolePermission { RolePermissionId = 3, RoleId = 3, Module = ModuleName.Shift, Actions = PermissionAction.View | PermissionAction.Delete, ScopeType = ScopeType.Global },
                new RolePermission { RolePermissionId = 4, RoleId = 4, Module = ModuleName.Attendance, Actions = PermissionAction.View, ScopeType = ScopeType.Global },
                new RolePermission { RolePermissionId = 5, RoleId = 5, Module = ModuleName.Account, Actions = PermissionAction.Create | PermissionAction.Edit, ScopeType = ScopeType.Global },
                new RolePermission { RolePermissionId = 6, RoleId = 6, Module = ModuleName.ShiftType, Actions = PermissionAction.View | PermissionAction.Create, ScopeType = ScopeType.Global },
                new RolePermission { RolePermissionId = 7, RoleId = 7, Module = ModuleName.Account, Actions = PermissionAction.Edit | PermissionAction.Delete, ScopeType = ScopeType.Global },
                new RolePermission { RolePermissionId = 8, RoleId = 8, Module = ModuleName.Employee, Actions = PermissionAction.View, ScopeType = ScopeType.Global },
                new RolePermission { RolePermissionId = 9, RoleId = 9, Module = ModuleName.Employee, Actions = PermissionAction.Create, ScopeType = ScopeType.Global },
                new RolePermission { RolePermissionId = 10, RoleId = 10, Module = ModuleName.Team, Actions = PermissionAction.View | PermissionAction.Edit, ScopeType = ScopeType.Global }
            );

            // Seed AccountRoles (10 samples, linking Accounts 1-10 to Roles 1-10)
            builder.Entity<AccountRole>().HasData(
                new AccountRole { AccountId = 1, RoleId = 1 },
                new AccountRole { AccountId = 2, RoleId = 2 },
                new AccountRole { AccountId = 3, RoleId = 3 },
                new AccountRole { AccountId = 4, RoleId = 4 },
                new AccountRole { AccountId = 5, RoleId = 5 },
                new AccountRole { AccountId = 6, RoleId = 6 },
                new AccountRole { AccountId = 7, RoleId = 7 },
                new AccountRole { AccountId = 8, RoleId = 8 },
                new AccountRole { AccountId = 9, RoleId = 9 },
                new AccountRole { AccountId = 10, RoleId = 10 }
            );

            // Seed AccountPermissions (5 samples, using valid ModuleName enum values)
            builder.Entity<AccountPermission>().HasData(
                new AccountPermission { AccountPermissionId = 1, AccountId = 1, Module = ModuleName.Employee, Actions = PermissionAction.View, ScopeType = ScopeType.Global },
                new AccountPermission { AccountPermissionId = 2, AccountId = 2, Module = ModuleName.Team, Actions = PermissionAction.Edit, ScopeType = ScopeType.Global },
                new AccountPermission { AccountPermissionId = 3, AccountId = 3, Module = ModuleName.Shift, Actions = PermissionAction.Create, ScopeType = ScopeType.Global },
                new AccountPermission { AccountPermissionId = 4, AccountId = 4, Module = ModuleName.Attendance, Actions = PermissionAction.Delete, ScopeType = ScopeType.Global },
                new AccountPermission { AccountPermissionId = 5, AccountId = 5, Module = ModuleName.Account, Actions = PermissionAction.View | PermissionAction.Edit, ScopeType = ScopeType.Global }
            );

            // Master RolePermissions for RoleId = 1
            var rolePermissions = new List<RolePermission>();
            int rpId = 11; // Start after 10 samples
            foreach (var module in Enum.GetValues(typeof(ModuleName)).Cast<ModuleName>())
            {
                rolePermissions.Add(new RolePermission
                {
                    RolePermissionId = rpId++,
                    RoleId = 1,
                    Module = module,
                    Actions = PermissionAction.View | PermissionAction.Create | PermissionAction.Edit | PermissionAction.Delete,
                    ScopeType = ScopeType.Global,
                    ScopeValue = null
                });
            }
            builder.Entity<RolePermission>().HasData(rolePermissions);
        }
    }
}

