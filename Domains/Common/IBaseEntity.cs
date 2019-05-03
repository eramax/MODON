using System;
using System.Collections.Generic;

namespace Domains
{
    public interface IBaseEntity : IEntityKey
    {
        long? CreatedById { get; set; }
        long? ModifiedById { get; set; }
        long? DeletedById { get; set; }
        DateTime? CreatedDate { get; set; }
        UserAccount CreatedBy { get; set; }
        DateTime? ModifiedDate { get; set; }
        UserAccount ModifiedBy { get; set; }
        DateTime? DeletedDate { get; set; }
        UserAccount DeletedBy { get; set; }
        int Version { get; set; }
        int? Status { get; set; }
    }

}
