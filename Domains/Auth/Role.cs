using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domains
{
    public class Role : IdentityRole<long, UserRoles>, IEntityKey, IBaseEntity
    {
        public string DisplayName { get; set; }

        [ForeignKey("CreatedBy")]
        public long? CreatedById { get; set; }
        public UserAccount CreatedBy { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? CreatedDate { get; set; }

        [ForeignKey("ModifiedBy")]
        public long? ModifiedById { get; set; }
        public UserAccount ModifiedBy { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? ModifiedDate { get; set; }

        [ForeignKey("DeletedBy")]
        public long? DeletedById { get; set; }
        public UserAccount DeletedBy { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DeletedDate { get; set; }
        public int Version { get; set; }
        public int? Status { get; set; }

        public ICollection<Permission> Permissions { get; set; }
    }
}
