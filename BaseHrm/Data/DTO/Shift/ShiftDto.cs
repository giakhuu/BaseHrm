namespace BaseHrm.Data.DTO
{
    public class ShiftDto
    {
        public int ShiftId { get; set; }
        public string Name { get; set; } = "";
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public decimal ExpectedHours { get; set; }
        public int ShiftTypeId { get; set; }
        public string? ShiftTypeName { get; set; }
        public decimal? PayMultiplier { get; set; }
    }
}
