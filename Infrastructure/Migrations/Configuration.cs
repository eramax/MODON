namespace Infrastructure.Migrations
{
    using Domains;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MDContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MDContext context)
        {
            //context.Countries.AddOrUpdate(x => x.PhoneCode, new TBL_Country { PhoneCode = "20", Code = "EGY", Name = "ãÕÑ", NameEn = "Egypt", IsArab = true, Status = 1 });
            //context.Countries.AddOrUpdate(x => x.PhoneCode, new TBL_Country { PhoneCode = "213", Code = "DZA", Name = "ÇáÌÒÇÆÑ", NameEn = "Algeria", IsArab = true, Status = 1 });
            //context.Countries.AddOrUpdate(x => x.PhoneCode, new TBL_Country { PhoneCode = "216", Code = "TUN", Name = "ÊæäÓ", NameEn = "Tunisia", IsArab = true, Status = 1 });
            //context.Countries.AddOrUpdate(x => x.PhoneCode, new TBL_Country { PhoneCode = "965", Code = "KWT", Name = "ÇáßæíÊ", NameEn = "Kuwait", IsArab = true, Status = 1 });
            //context.Countries.AddOrUpdate(x => x.PhoneCode, new TBL_Country { PhoneCode = "966", Code = "SAU", Name = "ÇáããáßÉ ÇáÚÑÈíÉ ÇáÓÚæÏíÉ", NameEn = "Saudi Arabia", IsArab = true, Status = 1 });
            //context.Countries.AddOrUpdate(x => x.PhoneCode, new TBL_Country { PhoneCode = "968", Code = "OMN", Name = "ÚãÇä", NameEn = "Oman", IsArab = true, Status = 1 });
            //context.Countries.AddOrUpdate(x => x.PhoneCode, new TBL_Country { PhoneCode = "971", Code = "ARE", Name = "ÇáÇãÇÑÇÊ ÇáÚÑÈíÉ ÇáãÊÍÏÉ", NameEn = "United Arab Emirates", IsArab = true, Status = 1 });
            //context.Countries.AddOrUpdate(x => x.PhoneCode, new TBL_Country { PhoneCode = "973", Code = "BHR", Name = "ÇáÈÍÑíä", NameEn = "Bahrain", IsArab = true, Status = 1 });

            //context.Roles.AddOrUpdate(x => x.Name, new Role { Name = "Client" });
            //context.Roles.AddOrUpdate(x => x.Name, new Role { Name = "Employee" });


            //if (!context.Roles.Any(r => r.Name == "Administrator") && !context.Users.Any(u => u.UserName == "Admin"))
            //{
            //    var RoleStore = new RoleStore<Role, Int64, UserRoles>(context);
            //    var RoleManager = new RoleManager<Role, Int64>(RoleStore);
            //    var role = new Role { Name = "Administrator" };

            //    RoleManager.Create(role);
            //    var UserStore = new UserStore<UserAccount, Role, Int64, UserLogins, UserRoles, UserClaims>(context);
            //    var UserManager = new UserManager<UserAccount, Int64>(UserStore);
            //    var user = new UserAccount { FullName = "Admin", UserName = "Admin", Email = "Admin@mail.com" };

            //    UserManager.Create(user, "123");
            //    user.Roles.Add(new UserRoles { RoleId = role.Id, UserId = user.Id });
            //}

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
