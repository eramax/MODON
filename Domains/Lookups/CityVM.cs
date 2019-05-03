namespace Domains
{
    public class CityVM : IEntityKey
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long CountryID { get; set; }
        public double Lang { get; set; }
        public double Late { get; set; }
        public int ZoomLevel { get; set; }
        public Country Country { get; set; }
    }
}
