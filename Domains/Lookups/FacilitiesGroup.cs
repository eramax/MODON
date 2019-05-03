using System.ComponentModel.DataAnnotations.Schema;

namespace Domains
{
    public class FacilitiesGroup : Location
    {
        public string Steet { get; set; }
        public string FacilitiesGroupOwner { get; set; }

        [ForeignKey("IndustrialCity")]
        public long IndustrialCity_Id { get; set; }
        public IndustrialCity IndustrialCity { get; set; }
    }
}
