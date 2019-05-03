using Domains;
using Infrastructure;
using System;

namespace Commands
{
    public class SaveRoleService : BasicService<Role, RoleVM>
    {
        public override Role Save(RoleVM vm , ref IMDResponse res)
        {
            vm.Permissions = DbHelper.ManyToMany<Role, Permission>(uw, vm, x => x.Permissions, vm.PermissionsIds, ref res);
            return base.Save(vm, ref res);
        }
    }
}