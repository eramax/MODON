using System.Collections.Generic;

namespace Domains
{
    public class FacilityVM : IEntityKey
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long? Client_Id { get; set; }
        public Client Client { get; set; }
        public int Space { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public long? MainActivity_Id { get; set; }
        public List<long> SubActivities2 { get; set; }
        public List<SubActivity> SubActivities { get; set; }
        public long InternalOldActivity { get; set; }
        public long ExternalOldActivity { get; set; }

        public long Country_Id { get; set; }
        public long City_Id { get; set; }
        public long? IndustrialCity_Id { get; set; }
        public IndustrialCity IndustrialCity { get; set; }
        public long? FacilitiesGroup_Id { get; set; }
        public FacilitiesGroup FacilitiesGroup { get; set; }
        public string OtherFacilitiesGroup { get; set; }
        public string FacilitiesGroupOwner { get; set; }
        public string Address { get; set; }
        public double Lang { get; set; }
        public double Late { get; set; }
        public List<SalesItem> SalesItems { get; set; }
    }
}
