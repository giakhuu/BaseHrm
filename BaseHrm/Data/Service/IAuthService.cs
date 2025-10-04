using BaseHrm.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseHrm.Data.Service
{
    public interface IAuthService
    {
        Task<(bool Success, string? Error, TokenModel? Token)> AuthenticateAsync(string username, string password, bool rememberMe, CancellationToken ct = default);
        Task<bool> ValidateTokenAsync(string token);
        TokenModel? LoadLocalToken();
        (int? AccountId, string? Username, string? Role, bool IsMaster, int? EmployeeId) GetUserInfoFromToken();
        void Logout();
    }

}
