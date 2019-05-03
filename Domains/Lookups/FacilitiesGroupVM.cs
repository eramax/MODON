namespace Domains
{
    public class FacilitiesGroupVM : IEntityKey
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Steet { get; set; }
        public string FacilitiesGroupOwner { get; set; }
        public long IndustrialCity_Id { get; set; }
        public IndustrialCity IndustrialCity { get; set; }
        public double Lang { get; set; }
        public double Late { get; set; }
        public int ZoomLevel { get; set; }
        public long Country_Id { get; set; }
        public long City_Id { get; set; }
    }
}
