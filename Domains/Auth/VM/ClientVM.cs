using System.Collections.Generic;

namespace Domains
{
    public class ClientVM : UserAccountVM
    {
        public string OrganizationName { get; set; }
        public string VerifiedPassword { get; set; }
        public List<UserAccount> UserAccounts { get; set; }
    }
}
