namespace Domains
{
    public class IndustrialCityVM : IEntityKey
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long City_Id { get; set; }
        public City City { get; set; }
        public double Lang { get; set; }
        public double Late { get; set; }
        public int ZoomLevel { get; set; }
        public long Country_Id { get; set; }
    }

}
