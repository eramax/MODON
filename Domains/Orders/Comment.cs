namespace Domains
{
    public class Comment : NamedBaseEntity
    {
        public Client Client { get; set; }
        public Employee Employee { get; set; }
    }
}
