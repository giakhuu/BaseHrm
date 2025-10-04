namespace BaseHrm.Data.DTO
{
    public class ShiftAssignmentDto
    {
        public int ShiftAssignmentId { get; set; }
        public DateTime Date { get; set; }

        public int ShiftId { get; set; }
        public string ShiftName { get; set; } = "";
        public TimeSpan ShiftStart { get; set; }
        public TimeSpan ShiftEnd { get; set; }
        public decimal ExpectedHours { get; set; }
        public string? ShiftTypeName { get; set; }

        public int EmployeeId { get; set; }
        public string EmployeeFirstName { get; set; } = "";
        public string EmployeeLastName { get; set; } = "";
        public string EmployeeFullName => $"{EmployeeFirstName} {EmployeeLastName}";
        public string? EmployeeEmail { get; set; }
        public string? EmployeePhone { get; set; }
        public string? EmployeePosition { get; set; }

        public int? ApprovedByAccountId { get; set; }
        public string? ApproverName { get; set; }
    }
}
