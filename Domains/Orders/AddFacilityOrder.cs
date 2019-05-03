namespace Domains
{
    public class AddFacilityOrder : FacilityOrder, IAuditableEntity
    {
        public string Ref { get; set; }
        public string CommcommercialID { get; set; }
        public string FacilitySpaceDesign { get; set; }
    }
}
