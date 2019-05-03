using Domains;
using Helpers;
using Infrastructure;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;

namespace Commands
{
    public static class Setup
    {
        public static void Config()
        {
            MDResponse.RegisterErrorHandler(MDLog.Error);
        }
        public static void Seed()
        {
            var uw = new UnitWork();
            var res = MDResponse.New();
            uw.Command<Role>().AddOrUpdate(new Role() { Id = 1, Name = "admin", DisplayName = "مدير النظام" }, ref res);
            uw.Command<Role>().AddOrUpdate(new Role() { Id = 2, Name = "super", DisplayName = "الادارة العليا" }, ref res);
            uw.Command<Role>().AddOrUpdate(new Role() { Id = 3, Name = "manager", DisplayName = "مدير" }, ref res);
            uw.Command<Role>().AddOrUpdate(new Role() { Id = 4, Name = "employee", DisplayName = "موظف" }, ref res);
            uw.Command<Role>().AddOrUpdate(new Role() { Id = 5, Name = "client", DisplayName = "مستثمر" }, ref res);
            uw.Command<Role>().AddOrUpdate(new Role() { Id = 6, Name = "hospital", DisplayName = "مستشفي" }, ref res);


            uw.Command<UserAccount>().AddOrUpdate(
                new UserAccount()
                {
                    Id = 1,
                    UserName = "admin",
                    PasswordHash = new PasswordHasher().HashPassword("123"),
                    Email = "a@a.com",
                    IsEnabled = 1,
                    FullName = "Admin",
                    CountryCode = 1,
                    PhoneNumber = "123",
                    SSID = "123",
                    LockoutEnabled = true,
                    SecurityStamp = Guid.NewGuid().ToString("D")
                }, ref res);

            uw.Command<Employee>().AddOrUpdate(new Employee() { Id = 1, ADUsername = "admin", UserAccount_Id = 1 }, ref res);
            uw.Command<UserRoles>().AddOrUpdate(new UserRoles() { Id = 1, RoleId = 1, UserId = 1 }, ref res);
            uw.Command<UserRoles>().AddOrUpdate(new UserRoles() { Id = 2, RoleId = 2, UserId = 1 }, ref res);
            uw.Command<UserRoles>().AddOrUpdate(new UserRoles() { Id = 3, RoleId = 3, UserId = 1 }, ref res);
            uw.Command<UserRoles>().AddOrUpdate(new UserRoles() { Id = 4, RoleId = 4, UserId = 1 }, ref res);


            uw.Command<UserAccount>().AddOrUpdate(
                 new UserAccount()
                 {
                     Id = 2,
                     UserName = "s1",
                     PasswordHash = new PasswordHasher().HashPassword("123"),
                     Email = "a@a.com",
                     IsEnabled = 1,
                     FullName = "Super",
                     CountryCode = 1,
                     PhoneNumber = "123",
                     SSID = "123",
                     LockoutEnabled = true,
                     SecurityStamp = Guid.NewGuid().ToString("D")
                 }, ref res);
            uw.Command<Employee>().AddOrUpdate(new Employee() { Id = 2, ADUsername = "s1", UserAccount_Id = 2 }, ref res);
            uw.Command<UserRoles>().AddOrUpdate(new UserRoles() { Id = 5, RoleId = 2, UserId = 2 }, ref res);
            uw.Command<UserRoles>().AddOrUpdate(new UserRoles() { Id = 6, RoleId = 3, UserId = 2 }, ref res);
            uw.Command<UserRoles>().AddOrUpdate(new UserRoles() { Id = 7, RoleId = 4, UserId = 2 }, ref res);


            uw.Command<UserAccount>().AddOrUpdate(
                 new UserAccount()
                 {
                     Id = 3,
                     UserName = "m1",
                     PasswordHash = new PasswordHasher().HashPassword("123"),
                     Email = "a@a.com",
                     IsEnabled = 1,
                     FullName = "Manager",
                     CountryCode = 1,
                     PhoneNumber = "123",
                     SSID = "123",
                     LockoutEnabled = true,
                     SecurityStamp = Guid.NewGuid().ToString("D")
                 }, ref res);

            uw.Command<Employee>().AddOrUpdate(new Employee() { Id = 3, ADUsername = "m1", UserAccount_Id = 3 }, ref res);
            uw.Command<UserRoles>().AddOrUpdate(new UserRoles() { Id = 8, RoleId = 3, UserId = 3 }, ref res);
            uw.Command<UserRoles>().AddOrUpdate(new UserRoles() { Id = 9, RoleId = 4, UserId = 3 }, ref res);

            uw.Command<UserAccount>().AddOrUpdate(
                 new UserAccount()
                 {
                     Id = 4,
                     UserName = "e1",
                     PasswordHash = new PasswordHasher().HashPassword("123"),
                     Email = "a@a.com",
                     IsEnabled = 1,
                     FullName = "Employee",
                     CountryCode = 1,
                     PhoneNumber = "123",
                     SSID = "123",
                     LockoutEnabled = true,
                     SecurityStamp = Guid.NewGuid().ToString("D")
                 }, ref res);

            uw.Command<Employee>().AddOrUpdate(new Employee() { Id = 4, ADUsername = "e1", UserAccount_Id = 4 }, ref res);
            uw.Command<UserRoles>().AddOrUpdate(new UserRoles() { Id = 10, RoleId = 4, UserId = 4 }, ref res);

            var c1 = uw.Command<UserAccount>().AddOrUpdate(
                 new UserAccount()
                 {
                     Id = 5,
                     UserName = "c1",
                     PasswordHash = new PasswordHasher().HashPassword("123"),
                     Email = "a@a.com",
                     IsEnabled = 1,
                     FullName = "SubAccount1",
                     CountryCode = 1,
                     PhoneNumber = "123",
                     SSID = "123",
                     LockoutEnabled = true,
                     SecurityStamp = Guid.NewGuid().ToString("D")
                 }, ref res);
            var c2 = uw.Command<UserAccount>().AddOrUpdate(
                 new UserAccount()
                 {
                     Id = 6,
                     UserName = "c2",
                     PasswordHash = new PasswordHasher().HashPassword("123"),
                     Email = "a@a.com",
                     IsEnabled = 1,
                     FullName = "SubAccount2",
                     CountryCode = 1,
                     PhoneNumber = "123",
                     SSID = "123",
                     LockoutEnabled = true,
                     SecurityStamp = Guid.NewGuid().ToString("D")
                 }, ref res);
            uw.Command<Client>().AddOrUpdate(new Client()
            {
                Id = 1,
                UserAccounts = new List<UserAccount>() { c1, c2 },
                Organization = "Alinma",
                FullName = "Alinma",
                SSID = "1233"
            }, ref res);
            uw.Command<UserRoles>().AddOrUpdate(new UserRoles() { Id = 11, RoleId = 5, UserId = 5 }, ref res);
            uw.Command<UserRoles>().AddOrUpdate(new UserRoles() { Id = 12, RoleId = 5, UserId = 6 }, ref res);

            //----------------- lookups -----------------------//
            uw.Command<Country>().AddOrUpdate(new Country() { Id = 1, Name = "المملكة العربية السعودية" }, ref res);
            uw.Command<Country>().AddOrUpdate(new Country() { Id = 2, Name = "جمهورية مصر العربية" }, ref res);

            uw.Command<City>().AddOrUpdate(new City() { Id = 1, Name = "الرياض", CountryID = 1 }, ref res);
            uw.Command<City>().AddOrUpdate(new City() { Id = 2, Name = "الدمام", CountryID = 1 }, ref res);
            uw.Command<City>().AddOrUpdate(new City() { Id = 3, Name = "جدة", CountryID = 1 }, ref res);

            uw.Command<IndustrialCity>().AddOrUpdate(new IndustrialCity() { Id = 1, Name = "المدينة الصناعية الاولي بالرياض", City_Id = 1 }, ref res);
            uw.Command<IndustrialCity>().AddOrUpdate(new IndustrialCity() { Id = 2, Name = "المدينة الصناعية الثانية بالرياض", City_Id = 1 }, ref res);
            uw.Command<IndustrialCity>().AddOrUpdate(new IndustrialCity() { Id = 3, Name = "المدينة الصناعية الاولي بالدمام", City_Id = 2 }, ref res);
            uw.Command<IndustrialCity>().AddOrUpdate(new IndustrialCity() { Id = 4, Name = "المدينة الصناعية الاولي بجدة", City_Id = 3 }, ref res);
            uw.Command<IndustrialCity>().AddOrUpdate(new IndustrialCity() { Id = 5, Name = "المدينة الصناعية الثانية بجدة", City_Id = 3 }, ref res);

            uw.Command<FacilitiesGroup>().AddOrUpdate(new FacilitiesGroup() { Id = 1, Name = "مجمع 1 بالرياض", IndustrialCity_Id = 1 }, ref res);
            uw.Command<FacilitiesGroup>().AddOrUpdate(new FacilitiesGroup() { Id = 2, Name = "مجمع 2 بالرياض", IndustrialCity_Id = 1 }, ref res);
            uw.Command<FacilitiesGroup>().AddOrUpdate(new FacilitiesGroup() { Id = 3, Name = "مجمع 1 بالدمام", IndustrialCity_Id = 3 }, ref res);
            uw.Command<FacilitiesGroup>().AddOrUpdate(new FacilitiesGroup() { Id = 4, Name = "مجمع 2 بالدمام", IndustrialCity_Id = 3 }, ref res);
            uw.Command<FacilitiesGroup>().AddOrUpdate(new FacilitiesGroup() { Id = 5, Name = "مجمع 1 بجدة", IndustrialCity_Id = 4 }, ref res);
            uw.Command<FacilitiesGroup>().AddOrUpdate(new FacilitiesGroup() { Id = 6, Name = "مجمع 2 بجدة", IndustrialCity_Id = 4 }, ref res);

            uw.Command<MainActivity>().AddOrUpdate(new MainActivity() { Id = 1, Name = "مطاعم" }, ref res);
            uw.Command<MainActivity>().AddOrUpdate(new MainActivity() { Id = 2, Name = "مخابز" }, ref res);
            uw.Command<MainActivity>().AddOrUpdate(new MainActivity() { Id = 3, Name = "تموينات" }, ref res);
            uw.Command<MainActivity>().AddOrUpdate(new MainActivity() { Id = 4, Name = "محلات سباكة" }, ref res);
            uw.Command<MainActivity>().AddOrUpdate(new MainActivity() { Id = 5, Name = "عصائر" }, ref res);

            uw.Command<SubActivity>().AddOrUpdate(new SubActivity() { Id = 1, Name = "مطعم مشويات", MainActivity_Id = 1 }, ref res);
            uw.Command<SubActivity>().AddOrUpdate(new SubActivity() { Id = 2, Name = "مطعم مندي", MainActivity_Id = 1 }, ref res);
            uw.Command<SubActivity>().AddOrUpdate(new SubActivity() { Id = 3, Name = "مطعم كبسة", MainActivity_Id = 1 }, ref res);
            uw.Command<SubActivity>().AddOrUpdate(new SubActivity() { Id = 4, Name = "مخبز عادي", MainActivity_Id = 2 }, ref res);
            uw.Command<SubActivity>().AddOrUpdate(new SubActivity() { Id = 5, Name = "مخبز كهربي", MainActivity_Id = 2 }, ref res);
            uw.Command<SubActivity>().AddOrUpdate(new SubActivity() { Id = 6, Name = "بقالة", MainActivity_Id = 3 }, ref res);
            uw.Command<SubActivity>().AddOrUpdate(new SubActivity() { Id = 7, Name = "سوبرماركت", MainActivity_Id = 3 }, ref res);
            uw.Command<SubActivity>().AddOrUpdate(new SubActivity() { Id = 8, Name = "ادوات منزلية", MainActivity_Id = 4 }, ref res);
            uw.Command<SubActivity>().AddOrUpdate(new SubActivity() { Id = 9, Name = "عصائر طبيعية", MainActivity_Id = 5 }, ref res);
            uw.Command<SubActivity>().AddOrUpdate(new SubActivity() { Id = 10, Name = "عصائر صناعية", MainActivity_Id = 5 }, ref res);

            uw.Save(ref res);
        }
    }
}
