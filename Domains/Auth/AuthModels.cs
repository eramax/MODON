using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;

namespace Domains
{
    public class UserRoles : IdentityUserRole<long>, IBaseEntity
    {
        public long? CreatedById { get; set ; }
        public long? ModifiedById { get ; set ; }
        public long? DeletedById { get ; set ; }
        public DateTime? CreatedDate { get ; set ; }
        public UserAccount CreatedBy { get ; set ; }
        public DateTime? ModifiedDate { get ; set ; }
        public UserAccount ModifiedBy { get ; set ; }
        public DateTime? DeletedDate { get ; set ; }
        public UserAccount DeletedBy { get ; set ; }
        public int Version { get ; set ; }
        public int? Status { get ; set ; }
        public long Id { get ; set ; }
    }

    public class UserClaims : IdentityUserClaim<long>
    {
    }

    public class UserLogins : IdentityUserLogin<long>
    {
    }
    public class UserStoreIntPk : UserStore<UserAccount, Role, long, UserLogins, UserRoles, UserClaims>
    {
        public UserStoreIntPk(DbContext context)
            : base(context)
        {
        }
    }

    public class RoleStoreIntPk : RoleStore<Role, Int64, UserRoles>
    {
        public RoleStoreIntPk(DbContext context)
            : base(context)
        {
        }
    }
}
