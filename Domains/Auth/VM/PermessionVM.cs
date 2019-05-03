using System.Collections.Generic;

namespace Domains
{
    public class PermissionVM : IEntityKey
    {
        public long Id { get; set; }
        public string DisplayName { get; set; }
        public string Name { get; set; }
        public List<long> RoleIds { get; set; }
        public List<Role> Roles { get; set; }
    }
}
