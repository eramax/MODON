namespace Domains
{
    public class SelectItem : IEntityKey
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long? ParantID { get; set; }
        public bool? Selected { get; set; } = false;
        public SelectItem() { }
        public SelectItem(int id, string val, long? parant = null)
        {
            Id = id;
            Name = val;
            ParantID = parant;
        }
    }
}
