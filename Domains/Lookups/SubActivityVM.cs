namespace Domains
{
    public class SubActivityVM : IEntityKey
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long MainActivity_Id { get; set; }
        public MainActivity MainActivity { get; set; }
    }
}
