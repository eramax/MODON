using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domains
{
    public class Client : BaseEntity
    {
        public string FullName { get; set; }
        public string Organization { get; set; }
        public string Fax { get; set; }
        public string HeadOfficeAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Photo { get; set; }
        public string SSID { get; set; }
        public string UserIdPicture { get; set; }

        [InverseProperty("Client")]
        public ICollection<UserAccount> UserAccounts { get; set; }
    }
}
