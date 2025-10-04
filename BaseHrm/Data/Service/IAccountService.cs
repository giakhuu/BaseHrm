using BaseHrm.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseHrm.Data.Service
{
    public interface IAccountService
    {
        Task<AccountDto?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<AccountDto?> GetByUsernameAsync(string username, CancellationToken ct = default);

        Task<AccountDto> CreateAsync(CreateAccountDto dto, CancellationToken ct = default);
        Task<bool> UpdateAsync(UpdateAccountDto dto, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);

        Task<List<AccountDto>> SearchAsync(string? username = null, string? role = null, bool? isMaster = null, int? employeeId = null, CancellationToken ct = default);

        // password helpers
        Task<bool> VerifyPasswordAsync(string username, string password, CancellationToken ct = default);
        Task<bool> SetPasswordAsync(int accountId, string newPassword, CancellationToken ct = default);
    }
}
