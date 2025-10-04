using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseHrm.Data.Enums
{
    public enum ModuleName
    {
        Employee,
        Team,
        Shift,
        ShiftType,   
        Attendance,
        Account
    }

    [Flags]
    public enum PermissionAction
    {
        None = 0,
        View = 1,
        Create = 2,
        Edit = 4,
        Delete = 8,
        All = View | Create | Edit | Delete
    }
    public enum ScopeType
    {
        Global,   
        Team,     // cụ thể 1 team (ScopeValue = teamId)
        OwnTeam,  
        Self      
    }

}
