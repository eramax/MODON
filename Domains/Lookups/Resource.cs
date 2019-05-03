using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domains
{
    public class Resource : BaseEntity
    {
        [MaxLength(200)]
        [Index(IsClustered = false)]
        public string ResourceKey { get; set; }

        [MaxLength(200)]
        public string ResourceValue { get; set; }

        [MaxLength(200)]
        public string ResourceLang { get; set; }
        public bool? IsDeleted { get; set; }

    }
}
