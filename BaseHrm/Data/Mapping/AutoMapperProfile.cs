using AutoMapper;
using BaseHrm.Data.DTO;
using BaseHrm.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseHrm.Data.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Employee, EmployeeDto>()
                .ForMember(dest => dest.Position,
                           opt => opt.MapFrom(src => src.Position != null ? src.Position.Name : null))
                .ForMember(d => d.TeamIds, opt => opt.MapFrom(s => s.TeamMemberships.Select(tm => tm.TeamId)));
            CreateMap<CreateEmployeeDto, Employee>();
            CreateMap<UpdateEmployeeDto, Employee>();

            CreateMap<Position, PositionDto>();
            CreateMap<CreatePositionDto, Position>();
            CreateMap<UpdatePositionDto, Position>();

            CreateMap<Team, TeamDto>()
                .ForMember(dest => dest.Leader,
                           opt => opt.MapFrom(src => src.Leader != null
                               ? src.Leader
                               : null))
                .ForMember(dest => dest.Members,
                           opt => opt.MapFrom(src => src.Members));

            // TeamMember -> TeamMemberDto
            CreateMap<TeamMember, TeamMemberDto>()
                .ForMember(dest => dest.FullName,
                           opt => opt.MapFrom(src => $"{src.Employee!.FirstName} {src.Employee.LastName}"));

            // Shift
            CreateMap<ShiftType, ShiftTypeDto>();
            CreateMap<ShiftTypeDto, ShiftType>();

            CreateMap<Shift, ShiftDto>()
                .ForMember(d => d.ShiftTypeName, opt => opt.MapFrom(s => s.ShiftType != null ? s.ShiftType.Name : null));
            CreateMap<ShiftDto, Shift>()
                .ForMember(dest => dest.ShiftType, opt => opt.Ignore());

            CreateMap<ShiftAssignment, ShiftAssignmentDto>()
                .ForMember(d => d.ShiftId, opt => opt.MapFrom(s => s.ShiftId))
                .ForMember(d => d.ShiftName, opt => opt.MapFrom(s => s.Shift != null ? s.Shift.Name : ""))
                .ForMember(d => d.ShiftStart, opt => opt.MapFrom(s => s.Shift.StartTime))
                .ForMember(d => d.ShiftEnd, opt => opt.MapFrom(s => s.Shift.EndTime))
                .ForMember(d => d.ExpectedHours, opt => opt.MapFrom(s => s.Shift.ExpectedHours))
                .ForMember(d => d.ShiftTypeName, opt => opt.MapFrom(s => s.Shift.ShiftType != null ? s.Shift.ShiftType.Name : null))
                .ForMember(d => d.EmployeeId, opt => opt.MapFrom(s => s.EmployeeId))
                .ForMember(d => d.EmployeeFirstName, opt => opt.MapFrom(s => s.Employee != null ? s.Employee.FirstName : ""))
                .ForMember(d => d.EmployeeLastName, opt => opt.MapFrom(s => s.Employee != null ? s.Employee.LastName : ""))
                .ForMember(d => d.EmployeeEmail, opt => opt.MapFrom(s => s.Employee != null ? s.Employee.Email : null))
                .ForMember(d => d.EmployeePhone, opt => opt.MapFrom(s => s.Employee != null ? s.Employee.Phone : null))
                .ForMember(d => d.EmployeePosition, opt => opt.MapFrom(s => s.Employee != null && s.Employee.Position != null ? s.Employee.Position.Name : null))
                .ForMember(d => d.ApproverName, opt => opt.MapFrom(s =>
                    s.ApprovedByAccount != null && s.ApprovedByAccount.Employee != null
                        ? s.ApprovedByAccount.Employee.FirstName + " " + s.ApprovedByAccount.Employee.LastName
                        : null));

            CreateMap<AttendanceRecord, AttendanceRecordDto>()
                // attendance basic
                .ForMember(d => d.AttendanceRecordId, opt => opt.MapFrom(s => s.AttendanceRecordId))
                .ForMember(d => d.CheckIn, opt => opt.MapFrom(s => s.CheckIn))
                .ForMember(d => d.CheckOut, opt => opt.MapFrom(s => s.CheckOut))
                .ForMember(d => d.DurationHours, opt => opt.MapFrom(s => s.DurationHours))
                .ForMember(d => d.IsOvertime, opt => opt.MapFrom(s => s.IsOvertime))

                // employee info (the requested fields)
                .ForMember(d => d.EmployeeId, opt => opt.MapFrom(s => s.EmployeeId))
                .ForMember(d => d.FullName,
                           opt => opt.MapFrom(s => s.Employee != null
                                ? (s.Employee.FirstName + " " + s.Employee.LastName).Trim()
                                : string.Empty))
                .ForMember(d => d.PositionName,
                           opt => opt.MapFrom(s => s.Employee != null && s.Employee.Position != null
                                ? s.Employee.Position.Name
                                : null))
                .ForMember(d => d.Email, opt => opt.MapFrom(s => s.Employee != null ? s.Employee.Email : null))

                // shift assignment info (optional)
                .ForMember(d => d.ShiftAssignmentId, opt => opt.MapFrom(s => s.ShiftAssignmentId))
                .ForMember(d => d.ShiftDate, opt => opt.MapFrom(s => s.ShiftAssignment != null ? (DateTime?)s.ShiftAssignment.Date : null))
                .ForMember(d => d.ShiftId, opt => opt.MapFrom(s => s.ShiftAssignment != null ? (int?)s.ShiftAssignment.ShiftId : null))
                .ForMember(d => d.ShiftName, opt => opt.MapFrom(s => s.ShiftAssignment != null && s.ShiftAssignment.Shift != null ? s.ShiftAssignment.Shift.Name : null))
                // ShiftType
                .ForMember(d => d.ShiftTypeId,
                           opt => opt.MapFrom(s => s.ShiftAssignment != null && s.ShiftAssignment.Shift != null
                                ? (int?)s.ShiftAssignment.Shift.ShiftTypeId
                                : null))
                .ForMember(d => d.ShiftTypeName,
                           opt => opt.MapFrom(s => s.ShiftAssignment != null && s.ShiftAssignment.Shift != null && s.ShiftAssignment.Shift.ShiftType != null
                                ? s.ShiftAssignment.Shift.ShiftType.Name
                                : null))
                .ForMember(d => d.PayMultiplier,
                           opt => opt.MapFrom(s => s.ShiftAssignment != null && s.ShiftAssignment.Shift != null && s.ShiftAssignment.Shift.ShiftType != null
                                ? (decimal?)s.ShiftAssignment.Shift.ShiftType.PayMultiplier
                                : null))
                .ForMember(d => d.ShiftStart,
                           opt => opt.MapFrom(s => s.ShiftAssignment != null && s.ShiftAssignment.Shift != null
                                ? (TimeSpan?)s.ShiftAssignment.Shift.StartTime
                                : null))
                .ForMember(d => d.ShiftEnd,
                           opt => opt.MapFrom(s => s.ShiftAssignment != null && s.ShiftAssignment.Shift != null
                                ? (TimeSpan?)s.ShiftAssignment.Shift.EndTime
                                : null));

            // Account
            CreateMap<Account, AccountDto>()
                .ForMember(d => d.EmployeeId, opt => opt.MapFrom(s => s.EmployeeId))
                .ForMember(d => d.EmployeeFullName,
                           opt => opt.MapFrom(s => s.Employee != null ? (s.Employee.FirstName + " " + s.Employee.LastName).Trim() : null))
                .ForMember(d => d.EmployeePhone,
                           opt => opt.MapFrom(s => s.Employee != null ? s.Employee.Phone : null))
                .ForMember(d => d.EmployeeEmail,
                           opt => opt.MapFrom(s => s.Employee != null ? s.Employee.Email : null))
                .ForMember(d => d.EmployeePositionName,
                           opt => opt.MapFrom(s => s.Employee != null && s.Employee.Position != null ? s.Employee.Position.Name : null));

            // Role -> RoleWithAccountsDto
            CreateMap<Role, RoleWithAccountsDto>()
                .ForMember(d => d.Accounts, opt => opt.MapFrom(r =>
                    r.AccountRoles != null
                        ? r.AccountRoles.Select(ar => ar.Account)
                        : Enumerable.Empty<Account>()
                ));
        }
    }
}
