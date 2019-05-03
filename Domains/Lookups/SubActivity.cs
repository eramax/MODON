using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domains
{
    public class SubActivity : NamedBaseEntity
    {
        [ForeignKey("MainActivity")]
        public long MainActivity_Id { get; set; }
        public MainActivity MainActivity { get; set; }

        public ICollection<Facility> Facilities { get; set; }

    }
}
