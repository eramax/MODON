using System.Collections.Generic;

namespace Domains
{
    public class AddFacilityOrderVM : Order
    {
        public long? Facility_Id { get; set; }
        public Facility Facility { get; set; }
        public List<long> SubActivitiesIds { get; set; }
        public List<SubActivity> SubActivities { get; set; }

        public ICollection<SalesItem> SalesItems { get; set; }
        public string Ref { get; set; }
        public string CommcommercialID { get; set; }
        public string FacilitySpaceDesign { get; set; }
        //------- for filters
        public long? Country_Id { get; set; }
        public long? City_Id { get; set; }
    }
}
