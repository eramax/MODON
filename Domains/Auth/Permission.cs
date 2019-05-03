using System.Collections.Generic;

namespace Domains
{
    public class Permission : NamedBaseEntity
    {
        public string DisplayName { get; set; }
        public ICollection<Role> Roles { get; set; }
    }
}
