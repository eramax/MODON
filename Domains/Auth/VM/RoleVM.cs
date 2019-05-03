using System.Collections.Generic;

namespace Domains
{
    public class RoleVM : IEntityKey
    {
        public long Id { get; set; }
        public string DisplayName { get; set; }
        public string Name { get; set; }
        public List<long> PermissionsIds { get; set; }
        public List<Permission> Permissions { get; set; }
    }
}
 