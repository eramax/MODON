using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domains
{
    public class IndustrialCity : Location
    {
        [ForeignKey("City")]
        public long City_Id { get; set; }
        public City City { get; set; }

        public ICollection<FacilitiesGroup> FacilitiesGroups { get; set; }
        public ICollection<UserAccount> UserAccounts { get; set; }

    }
}
