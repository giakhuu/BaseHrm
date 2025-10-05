using System.Threading.Tasks;

namespace BaseHrm.Data.Service
{
    public interface IBackupRestoreService
    {
        Task BackupAttendanceAsync(string filePath);
        Task DeleteAllAttendanceAsync();
        Task RestoreAttendanceAsync(string filePath);

        Task BackupShiftAndAssignmentAsync(string filePath);
        Task DeleteAllShiftAndAssignmentAsync();
        Task RestoreShiftAndAssignmentAsync(string filePath);
    }
}
