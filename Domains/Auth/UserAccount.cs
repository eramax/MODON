using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;

namespace Domains
{
    public class UserAccount : IdentityUser<long, UserLogins, UserRoles, UserClaims> , IBaseEntity
    {
        public string FullName { get; set; }
        public string SSID { get; set; }
        public string UserIdPicture { get; set; }

        [ForeignKey("Client")]
        public long? Client_Id { get; set; }
        public Client Client { get; set; }

        [ForeignKey("Employee")]
        public long? Employee_Id { get; set; }
        public Employee Employee { get; set; }

        public int CountryCode { get; set; }
        public int IsEnabled { get; set; }
        public long? CreatedById { get; set; }
        public long? ModifiedById { get; set; }
        public long? DeletedById { get; set; }
        public DateTime? CreatedDate { get; set; }
        public UserAccount CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public UserAccount ModifiedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public UserAccount DeletedBy { get; set; }
        public int Version { get; set; }
        public int? Status { get; set; }
        
        public ICollection<IndustrialCity> IndustrialCities { get; set; }

        public ClaimsIdentity GenerateUserIdentity(UserManager<UserAccount, long> manager)
        {
            var userIdentity = manager.CreateIdentity(this, DefaultAuthenticationTypes.ApplicationCookie);
            if(userIdentity != null)
                userIdentity.AddClaims(new[] {
                                new Claim("Client_Id",Client_Id?.ToString() ?? ""),
                                new Claim("UserName",UserName ),
                                new Claim("FullName",FullName),
                            });
            return userIdentity;
        }
    }
}
