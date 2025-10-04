using AutoMapper;
using BaseHrm.Auth;
using BaseHrm.Data.DTO;
using BaseHrm.Data.Models;
using BaseHrm.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;

namespace BaseHrm.Data.Service
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _repo;
        private readonly IMapper _mapper;



        public AccountService(IAccountRepository repo, IMapper mapper)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<AccountDto?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var ent = await _repo.GetByIdAsync(id, ct);
            return ent == null ? null : _mapper.Map<AccountDto>(ent);
        }

        public async Task<AccountDto?> GetByUsernameAsync(string username, CancellationToken ct = default)
        {
            var ent = await _repo.GetByUsernameAsync(username, ct);
            return ent == null ? null : _mapper.Map<AccountDto>(ent);
        }

        public async Task<AccountDto> CreateAsync(CreateAccountDto dto, CancellationToken ct = default)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            if (string.IsNullOrWhiteSpace(dto.Username)) throw new ArgumentException("Hãy nhập Username.", nameof(dto.Username));
            if (string.IsNullOrEmpty(dto.Password)) throw new ArgumentException("Hãy nhập password.", nameof(dto.Password));

            var existingByUsername = await _repo.GetByUsernameAsync(dto.Username, ct);
            if (existingByUsername != null)
                throw new InvalidOperationException("Username đã tồn tại.");

            if (dto.IsMaster)
            {
                var currentMaster = await _repo.GetMasterAccountAsync(ct);
                if (currentMaster != null)
                {
                    currentMaster.IsMaster = false;
                    await _repo.UpdateAsync(currentMaster, ct);
                    await _repo.SaveChangesAsync(ct);
                }
            }

            var account = new Account
            {
                EmployeeId = dto.EmployeeId,
                Username = dto.Username,
                IsMaster = dto.IsMaster,
                LastLogin = null
            };

            account.PasswordHash = PasswordHasher.HashPassword(dto.Password);

            await _repo.AddAsync(account, ct);
            await _repo.SaveChangesAsync(ct);

            var created = await _repo.GetByIdAsync(account.AccountId, ct);
            return _mapper.Map<AccountDto>(created!);
        }

        public async Task<bool> UpdateAsync(UpdateAccountDto dto, CancellationToken ct = default)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            var existing = await _repo.GetByIdAsync(dto.AccountId, ct);
            if (existing == null) return false;

            if (!string.IsNullOrWhiteSpace(dto.Username) && !string.Equals(dto.Username, existing.Username, StringComparison.OrdinalIgnoreCase))
            {
                var byUsername = await _repo.GetByUsernameAsync(dto.Username, ct);
                if (byUsername != null && byUsername.AccountId != dto.AccountId)
                    throw new InvalidOperationException("Username đã tồn tại.");
                existing.Username = dto.Username;
            }

            if (dto.IsMaster.HasValue)
            {
                if (dto.IsMaster.Value && !existing.IsMaster)
                {
                    var cur = await _repo.GetMasterAccountAsync(ct);
                    if (cur != null && cur.AccountId != existing.AccountId)
                    {
                        cur.IsMaster = false;
                        await _repo.UpdateAsync(cur, ct);
                    }
                    existing.IsMaster = true;
                }
                else if (!dto.IsMaster.Value)
                {
                    existing.IsMaster = false;
                }
            }

            if (!string.IsNullOrEmpty(dto.NewPassword))
            {
                existing.PasswordHash = PasswordHasher.HashPassword(dto.NewPassword);
            }

            await _repo.UpdateAsync(existing, ct);
            await _repo.SaveChangesAsync(ct);
            return true;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
        {
            var existing = await _repo.GetByIdAsync(id, ct);
            if (existing == null) return false;

            await _repo.DeleteAsync(existing, ct);
            await _repo.SaveChangesAsync(ct);
            return true;
        }

        public async Task<List<AccountDto>> SearchAsync(string? username = null, string? role = null, bool? isMaster = null, int? employeeId = null, CancellationToken ct = default)
        {
            var list = await _repo.SearchAsync(username, role, isMaster, employeeId, ct);
            return list.Select(a => _mapper.Map<AccountDto>(a)).ToList();
        }

        public async Task<bool> VerifyPasswordAsync(string username, string password, CancellationToken ct = default)
        {
            var acc = await _repo.GetByUsernameAsync(username, ct);
            if (acc == null) return false;
            return PasswordHasher.VerifyPassword(acc.PasswordHash, password);
        }

        public async Task<bool> SetPasswordAsync(int accountId, string newPassword, CancellationToken ct = default)
        {
            var acc = await _repo.GetByIdAsync(accountId, ct);
            if (acc == null) return false;
            acc.PasswordHash = PasswordHasher.HashPassword(newPassword);
            await _repo.UpdateAsync(acc, ct);
            await _repo.SaveChangesAsync(ct);
            return true;
        }


    }
}
