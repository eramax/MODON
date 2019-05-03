namespace Domains
{
    public interface IAuditableEntity : IBaseEntity
    {
        string Ref { get; set; }
    }
}
