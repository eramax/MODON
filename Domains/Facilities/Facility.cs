using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domains
{
    public class Facility : NamedBaseEntity, IAuditableEntity
    {
        [ForeignKey("Client")]
        public long? Client_Id { get; set; }
        public Client Client { get; set; }

        public int Space { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public long InternalOldActivity { get; set; }
        public long ExternalOldActivity { get; set; }

        [ForeignKey("IndustrialCity")]
        public long? IndustrialCity_Id { get; set; }
        public IndustrialCity IndustrialCity { get; set; }

        [ForeignKey("FacilitiesGroup")]
        public long? FacilitiesGroup_Id { get; set; }
        public FacilitiesGroup FacilitiesGroup { get; set; }

        public string OtherFacilitiesGroup { get; set; }
        public string FacilitiesGroupOwner { get; set; }
        public string Address { get; set; }
        public double Lang { get; set; }
        public double Late { get; set; }

        public ICollection<SubActivity> SubActivities { get; set; }
        public ICollection<SalesItem> SalesItems { get; set; }

        public string Ref { get; set; }
    }


}
