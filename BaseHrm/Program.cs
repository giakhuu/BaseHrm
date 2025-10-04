using BaseHrm.Auth;
using BaseHrm.Controls;
using BaseHrm.Data;
using BaseHrm.Data.Mapping;
using BaseHrm.Data.Repository;
using BaseHrm.Data.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using AutoMapper;
using OfficeOpenXml;

namespace BaseHrm
{
    internal static class Program
    {

        public static IServiceProvider ServiceProvider { get; private set; } = default!;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static async Task Main()
        {

            ApplicationConfiguration.Initialize(); 
            var host = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration((ctx, cfg) =>
                {
                    cfg.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                })
                .ConfigureServices((ctx, services) =>
                {
                    var conn = ctx.Configuration.GetConnectionString("DefaultConnection"); 
                    services.AddDbContextFactory<AppDbContext>(
                        options => options.UseSqlServer(conn),
                        ServiceLifetime.Transient // lifetime cho factory
                    );

                    // Repositories and services
                    services.AddScoped<IAccountRepository, AccountRepository>();
                    services.AddScoped<IAuthService, AuthService>();
                    services.AddScoped<IEmployeeRepository, EmployeeRepository>();
                    services.AddScoped<IEmployeeService, EmployeeService>();
                    services.AddScoped<IPositionRepository, PositionRepository>();
                    services.AddScoped<IPositionService, PositionService>();
                    services.AddScoped<ITeamRepository, TeamRepository>();
                    services.AddScoped<ITeamService, TeamService>();
                    services.AddScoped<IShiftRepository, ShiftRepository>();
                    services.AddScoped<IShiftTypeRepository, ShiftTypeRepository>();
                    services.AddScoped<IShiftAssignmentRepository, ShiftAssignmentRepository>();
                    services.AddScoped<IShiftService, ShiftService>();
                    services.AddScoped<IAttendanceRepository, AttendanceRepository>();
                    services.AddScoped<IAttendanceService, AttendanceService>();
                    services.AddScoped<IAccountService, AccountService>();
                    services.AddScoped<IRoleRepository, RoleRepository>();
                    services.AddScoped<IAccountPermissionRepository, AccountPermissionRepository>();
                    services.AddScoped<IPermissionService, PermissionService>();
                    // Register forms
                    services.AddTransient<LoginForm>();
                    services.AddTransient<MainForm>();
                    services.AddTransient<AddEmployeeForm>();
                    services.AddTransient<AddAttendanceRecordForm>();
                    services.AddTransient<AddAccountForm>();
                    services.AddTransient<AccountDetailForm>();
                    services.AddTransient<RoleDetailForm>();
                    services.AddTransient<Test>(); // Keep Test for development purposes
                    // Register Control
                    services.AddTransient<EmployeeManagementControl>();
                    services.AddTransient<TeamManagementControl>();
                    services.AddTransient<ShiftManagementControl>();
                    services.AddTransient<DailyShiftSummaryControl>();
                    services.AddTransient<AddShiftTypeControl>();
                    services.AddTransient<AttendanceManagementControl>();
                    services.AddTransient<PickEmployeeControl>();
                    services.AddTransient<PickShiftAssignmentControl>();
                    services.AddTransient<AccountManagementControl>();
                    services.AddTransient<RoleManagementControl>();
                    services.AddTransient<PickRoleControl>();
                    services.AddTransient<PickTeamControl>();
                    services.AddTransient<CheckInControl>();
                    // AutoMapper
                    services.AddAutoMapper(cfg => { }, typeof(AutoMapperProfile).Assembly);
                    services.AddMemoryCache();
                })
                .Build();
            // lưu lại để dùng global
            ServiceProvider = host.Services;
            using var scope = host.Services.CreateScope();
            var provider = scope.ServiceProvider;

            // check saved token and auto-login
            var auth = provider.GetRequiredService<IAuthService>();
            ExcelPackage.License.SetNonCommercialPersonal("Your Name or Organization");
            var tokenModel = auth.LoadLocalToken();
            Console.WriteLine(BCrypt.Net.BCrypt.HashPassword("1", 12));
            if (tokenModel != null && tokenModel.ExpiresAt > DateTime.UtcNow && await auth.ValidateTokenAsync(tokenModel.Token))
            {
                // token valid - open MainForm (production form) with full permission system
                Application.Run(provider.GetRequiredService<Test>());
            }
            else
            {
                // show login
                var login = provider.GetRequiredService<LoginForm>();
                Application.Run(login);
            }
        }
    }
}