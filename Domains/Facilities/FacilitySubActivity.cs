using System.ComponentModel.DataAnnotations.Schema;

namespace Domains
{
    public class FacilitySubActivity : BaseEntity
    {
        [ForeignKey("Facility")]
        public long Facility_Id { get; set; }
        public Facility Facility { get; set; }

        [ForeignKey("SubActivity")]
        public long SubActivity_Id { get; set; }
        public SubActivity SubActivity { get; set; }
    }
}
