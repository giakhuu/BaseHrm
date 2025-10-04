using BaseHrm.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BaseHrm.Data.Repository
{
    public interface IAccountRepository
    {
        Task<Account?> GetByUsernameAsync(string username, CancellationToken ct = default);
        Task<Account?> GetByIdAsync(int id, CancellationToken ct = default);
        Task AddAsync(Account account, CancellationToken ct = default);
        Task UpdateAsync(Account account, CancellationToken ct = default);
        Task DeleteAsync(Account account, CancellationToken ct = default);
        Task SaveChangesAsync(CancellationToken ct = default);
        Task<List<Account>> SearchAsync(string? username = null, string? role = null, bool? isMaster = null, int? employeeId = null, CancellationToken ct = default);

        Task<Account?> GetMasterAccountAsync(CancellationToken ct = default);
    }
}

