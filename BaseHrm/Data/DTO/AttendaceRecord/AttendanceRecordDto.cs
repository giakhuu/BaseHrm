using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BaseHrm.Data.DTO
{
    public class AttendanceRecordDto
    {
        public int AttendanceRecordId { get; set; }

        public int EmployeeId { get; set; }
        public string FullName { get; set; } = "";
        public string? PositionName { get; set; }
        public string? Email { get; set; }
        public string? EmployeeEmail { get; set; }
        public string? EmployeePhone { get; set; }
        public string? EmployeePosition { get; set; }
        public string? EmployeeFirstName { get; set; }
        public string? EmployeeLastName { get; set; }

        public DateTime CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
        public decimal? DurationHours { get; set; }
        public bool IsOvertime { get; set; }

        public int? ShiftAssignmentId { get; set; }
        public DateTime? ShiftDate { get; set; }
        public int? ShiftId { get; set; }
        public string? ShiftName { get; set; }
        public int? ShiftTypeId { get; set; }
        public string? ShiftTypeName { get; set; }
        public decimal? PayMultiplier { get; set; }
        public TimeSpan ShiftStart { get; set; }   
        public TimeSpan ShiftEnd { get; set; }

        [JsonIgnore]
        public TimeSpan ValidDuration
        {
            get
            {
                if (!CheckOut.HasValue) return TimeSpan.Zero;
                if (!ShiftDate.HasValue) return TimeSpan.Zero;

                DateTime checkIn = CheckIn;
                DateTime checkOut = CheckOut.Value;

                if (checkOut <= checkIn) return TimeSpan.Zero;

                DateTime shiftStart = ShiftDate.Value.Date + ShiftStart;
                DateTime shiftEnd = ShiftDate.Value.Date + ShiftEnd;

                if (shiftEnd <= shiftStart)
                {
                    shiftEnd = shiftEnd.AddDays(1);
                }

                DateTime overlapStart = checkIn > shiftStart ? checkIn : shiftStart;
                DateTime overlapEnd = checkOut < shiftEnd ? checkOut : shiftEnd;

                if (overlapEnd <= overlapStart) return TimeSpan.Zero;

                return overlapEnd - overlapStart;
            }
        }

        [JsonIgnore]
        public decimal ValidDurationHours
        {
            get
            {
                if (ValidDuration == TimeSpan.Zero) return 0.00m;

                decimal hours = (decimal)ValidDuration.TotalSeconds / 3600m;
                return Math.Round(hours, 2);
            }
        }
    }
}
