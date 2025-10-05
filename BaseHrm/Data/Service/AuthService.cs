using BaseHrm.Auth;
using BaseHrm.Data.Models;
using BaseHrm.Data.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BaseHrm.Data.Service
{
    public class AuthService : IAuthService
    {
        private readonly IAccountRepository _repo;
        private readonly IAccountService _accountService;
        private readonly TokenStore _tokenStore;
        private readonly IConfiguration _cfg;
        private readonly string _jwtSecret;
        private readonly string _issuer;
        private readonly string _audience;
        private readonly int _tokenMinutes;

        public AuthService(IAccountRepository repo, IConfiguration cfg, IAccountService accountService)
        {
            _repo = repo;
            _cfg = cfg;
            _jwtSecret = _cfg["Jwt:Secret"] ?? throw new Exception("Jwt:Secret missing");
            _issuer = _cfg["Jwt:Issuer"] ?? "local";
            _audience = _cfg["Jwt:Audience"] ?? "local";
            _tokenMinutes = int.TryParse(_cfg["Jwt:TokenLifetimeMinutes"], out var m) ? m : 1440;
            var tokenFileName = _cfg["App:TokenStoreFileName"] ?? "employee_mgmt_token.json";
            _tokenStore = new TokenStore(tokenFileName);
            _accountService = accountService;
        }

        public async Task<(bool Success, string? Error, TokenModel? Token)> AuthenticateAsync(string username, string password, bool rememberMe, CancellationToken ct = default)
        {
            try
            {
                var account = await _repo.GetByUsernameAsync(username, ct);
                if (account == null) return (false, "Không tìm thấy tài khoản", null);
                if (account.IsActive == false) return (false, "Tài khoản bị khoá", null);
                Console.WriteLine($"mật kh{account.PasswordHash}   {password}");
                if (!PasswordHasher.VerifyPassword(account.PasswordHash, password))
                {
                    return (false, "Sai mật khẩu", null);
                }
                var token = GenerateToken(account);
                if (rememberMe)
                {
                    _tokenStore.Save(token);
                }
                account.LastLogin = DateTime.UtcNow;
                await _repo.UpdateAsync(account);
                await _repo.SaveChangesAsync(ct);

                return (true, null, token);
            }
            catch (Exception ex)
            {
                return (false, "Lỗi xác thực", null);
            }
        }

        private TokenModel GenerateToken(Account acc)
        {
            try
            {


                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSecret));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, acc.AccountId.ToString()),
                        new Claim("username", acc.Username),
                        new Claim("ismaster", acc.IsMaster ? "1" : "0"),
                        new Claim("employeeId", acc.EmployeeId.ToString())
                    };

                var now = DateTime.UtcNow;
                var expires = now.AddMinutes(_tokenMinutes);

                var token = new JwtSecurityToken(
                    issuer: _issuer,
                    audience: _audience,
                    claims: claims,
                    notBefore: now,
                    expires: expires,
                    signingCredentials: creds
                );

                var handler = new JwtSecurityTokenHandler();
                var jwt = handler.WriteToken(token);

                return new TokenModel { Token = jwt, ExpiresAt = expires, Username = acc.Username };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error generating token: {ex.Message}");
                return new TokenModel { Token = null, ExpiresAt = DateTime.MinValue, Username = acc.Username };
            }
        }

        public TokenModel? LoadLocalToken() => _tokenStore.Load();

        public async Task<bool> ValidateTokenAsync(string token)
        {
            if (string.IsNullOrEmpty(token)) return false;

            var handler = new JwtSecurityTokenHandler();
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = _issuer,
                ValidateAudience = true,
                ValidAudience = _audience,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSecret)),
                ValidateLifetime = true,
                ClockSkew = TimeSpan.FromSeconds(30)
            };

            try
            {
                handler.ValidateToken(token, validationParameters, out var validatedToken);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public (int? AccountId, string? Username, string? Role, bool IsMaster, int? EmployeeId) GetUserInfoFromToken()
        {
            string ? token = _tokenStore.Load()?.Token;
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);

            int? id = null;
            if (int.TryParse(jwtToken.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sub)?.Value, out var accId))
                id = accId;

            var username = jwtToken.Claims.FirstOrDefault(c => c.Type == "username")?.Value;
            var role = jwtToken.Claims.FirstOrDefault(c => c.Type == "role")?.Value;
            var isMaster = jwtToken.Claims.FirstOrDefault(c => c.Type == "ismaster")?.Value == "1";
            int? employeeId = null;
            if (int.TryParse(jwtToken.Claims.FirstOrDefault(c => c.Type == "employeeId")?.Value, out var eId))
                employeeId = eId;
            Console.WriteLine($"Token info: id={id}, username={username}, role={role}, isMaster={isMaster}, employeeId={employeeId}");
            return (id, username, role, isMaster, employeeId);
        }
        public void Logout() => _tokenStore.Delete();
    }
}
