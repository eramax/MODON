namespace Domains
{
    public class CountryVM : IEntityKey
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double Lang { get; set; }
        public double Late { get; set; }
        public int ZoomLevel { get; set; }
    }
}
