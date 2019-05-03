using System.ComponentModel.DataAnnotations.Schema;

namespace Domains
{
    public class FacilityOrder : Order
    {
        [ForeignKey("Facility")]
        public long? Facility_Id { get; set; }
        public Facility Facility { get; set; }
    }
}
