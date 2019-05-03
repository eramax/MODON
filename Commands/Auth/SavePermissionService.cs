using Domains;
using Infrastructure;
using System;

namespace Commands
{
    public class SavePermissionService : BasicService<Permission, PermissionVM>
    {
        public override Permission Save(PermissionVM vm, ref IMDResponse res)
        {
            vm.Roles = DbHelper.ManyToMany<Permission, Role>(uw, vm, x => x.Roles, vm.RoleIds, ref res);
            return base.Save(vm, ref res);
        }
    }
}
