namespace Domains
{ 
    public class Location : NamedBaseEntity
    {
        public double Lang { get; set; }
        public double Late { get; set; }
        public int ZoomLevel { get; set; }
        public double Accuracy { get; set; }
    }
}
