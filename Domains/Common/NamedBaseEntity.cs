using System.ComponentModel.DataAnnotations;

namespace Domains
{
    public class NamedBaseEntity : BaseEntity
    {
        [MaxLength(500)]
        public string Name { get; set; }
    }
}
