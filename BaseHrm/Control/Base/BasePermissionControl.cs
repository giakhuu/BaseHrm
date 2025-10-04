using BaseHrm.Data.Enums;
using BaseHrm.Data.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseHrm.Controls.Base
{
    public abstract class BasePermissionControl : UserControl
    {
        protected readonly IPermissionService _permissionService;
        protected readonly IAuthService _authService;
        protected int? _currentAccountId;
        protected bool _isMasterAccount;
        protected readonly Dictionary<(PermissionAction action, ScopeType scope, int? scopeValue), bool> _permCache
            = new Dictionary<(PermissionAction, ScopeType, int?), bool>();

        protected BasePermissionControl(IPermissionService permissionService, IAuthService authService)
        {
            _permissionService = permissionService ?? throw new ArgumentNullException(nameof(permissionService));
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
        }

        protected async Task InitializeIdentityAsync()
        {
            try
            {
                var info = _authService.GetUserInfoFromToken();
                _currentAccountId = info.AccountId;
                _isMasterAccount = info.IsMaster;
                _permCache.Clear();
            }
            catch
            {
                _currentAccountId = null;
                _isMasterAccount = false;
            }
        }

        protected async Task<bool> HasPermissionAsync(ModuleName module, PermissionAction action, ScopeType scope = ScopeType.Global, int? scopeValue = null)
        {
            if (_isMasterAccount) return true;
            if (!_currentAccountId.HasValue) return false;

            var key = (action, scope, scopeValue);
            if (!_permCache.TryGetValue(key, out bool allowed))
            {
                allowed = await _permissionService.HasPermissionAsync(_currentAccountId.Value, module, action, scope, scopeValue);
                _permCache[key] = allowed;
            }
            return allowed;
        }

        protected async Task<bool> CheckPermissionWithMessage(ModuleName module, PermissionAction action, ScopeType scope = ScopeType.Global, int? scopeValue = null, string errorMessage = "B?n không có quy?n th?c hi?n hành ??ng này.")
        {
            bool hasPermission = await HasPermissionAsync(module, action, scope, scopeValue);
            if (!hasPermission)
            {
                MessageBox.Show(errorMessage, "Không ?? quy?n", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return hasPermission;
        }
    }
}