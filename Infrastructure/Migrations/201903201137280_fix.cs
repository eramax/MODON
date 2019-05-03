namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Building",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 500),
                        CreatedById = c.Long(),
                        CreatedDate = c.DateTime(),
                        ModifiedById = c.Long(),
                        ModifiedDate = c.DateTime(),
                        DeletedById = c.Long(),
                        DeletedDate = c.DateTime(),
                        Version = c.Int(nullable: false),
                        Status = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedById)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedById)
                .ForeignKey("dbo.AspNetUsers", t => t.ModifiedById)
                .Index(t => t.CreatedById)
                .Index(t => t.ModifiedById)
                .Index(t => t.DeletedById);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CountryCode = c.Int(nullable: false),
                        FullName = c.String(maxLength: 200),
                        SSID = c.String(maxLength: 20),
                        UserIdPicture = c.String(maxLength: 500),
                        Client_Id = c.Long(),
                        IsEnabled = c.Int(nullable: false),
                        CreatedById = c.Long(),
                        ModifiedById = c.Long(),
                        DeletedById = c.Long(),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        DeletedDate = c.DateTime(),
                        Version = c.Int(nullable: false),
                        Status = c.Int(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Client", t => t.Client_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedById)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedById)
                .ForeignKey("dbo.AspNetUsers", t => t.ModifiedById)
                .Index(t => t.Client_Id)
                .Index(t => t.CreatedById)
                .Index(t => t.ModifiedById)
                .Index(t => t.DeletedById)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Long(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        UserAccount_Id = c.Long(nullable: false),
                        FullName = c.String(maxLength: 200),
                        Organization = c.String(maxLength: 200),
                        Fax = c.String(maxLength: 200),
                        HeadOfficeAddress = c.String(maxLength: 500),
                        PhoneNumber = c.String(maxLength: 15),
                        Photo = c.String(maxLength: 500),
                        SSID = c.String(maxLength: 20),
                        UserIdPicture = c.String(maxLength: 500),
                        CreatedById = c.Long(),
                        CreatedDate = c.DateTime(),
                        ModifiedById = c.Long(),
                        ModifiedDate = c.DateTime(),
                        DeletedById = c.Long(),
                        DeletedDate = c.DateTime(),
                        Version = c.Int(nullable: false),
                        Status = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedById)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedById)
                .ForeignKey("dbo.AspNetUsers", t => t.ModifiedById)
                .ForeignKey("dbo.AspNetUsers", t => t.UserAccount_Id)
                .Index(t => t.UserAccount_Id, unique: true)
                .Index(t => t.CreatedById)
                .Index(t => t.ModifiedById)
                .Index(t => t.DeletedById);

            CreateTable(
                "dbo.UserAccountIndustrialCity",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    UserAccount_Id = c.Long(nullable: false),
                    IndustrialCity_Id = c.Long(nullable: false),
                    CreatedById = c.Long(),
                    CreatedDate = c.DateTime(),
                    ModifiedById = c.Long(),
                    ModifiedDate = c.DateTime(),
                    DeletedById = c.Long(),
                    DeletedDate = c.DateTime(),
                    Version = c.Int(nullable: false),
                    Status = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedById)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedById)
                .ForeignKey("dbo.IndustrialCity", t => t.IndustrialCity_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ModifiedById)
                .ForeignKey("dbo.AspNetUsers", t => t.UserAccount_Id)
                .Index(t => t.UserAccount_Id)
                .Index(t => t.IndustrialCity_Id)
                .Index(t => t.CreatedById)
                .Index(t => t.ModifiedById)
                .Index(t => t.DeletedById);
            
            CreateTable(
                "dbo.IndustrialCity",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        City_Id = c.Long(nullable: false),
                        Lang = c.Double(nullable: false),
                        Late = c.Double(nullable: false),
                        ZoomLevel = c.Int(nullable: false),
                        Accuracy = c.Double(nullable: false),
                        Name = c.String(maxLength: 500),
                        CreatedById = c.Long(),
                        CreatedDate = c.DateTime(),
                        ModifiedById = c.Long(),
                        ModifiedDate = c.DateTime(),
                        DeletedById = c.Long(),
                        DeletedDate = c.DateTime(),
                        Version = c.Int(nullable: false),
                        Status = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.City", t => t.City_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedById)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedById)
                .ForeignKey("dbo.AspNetUsers", t => t.ModifiedById)
                .Index(t => t.City_Id)
                .Index(t => t.CreatedById)
                .Index(t => t.ModifiedById)
                .Index(t => t.DeletedById);
            
            CreateTable(
                "dbo.City",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CountryID = c.Long(nullable: false),
                        Lang = c.Double(nullable: false),
                        Late = c.Double(nullable: false),
                        ZoomLevel = c.Int(nullable: false),
                        Accuracy = c.Double(nullable: false),
                        Name = c.String(maxLength: 500),
                        CreatedById = c.Long(),
                        CreatedDate = c.DateTime(),
                        ModifiedById = c.Long(),
                        ModifiedDate = c.DateTime(),
                        DeletedById = c.Long(),
                        DeletedDate = c.DateTime(),
                        Version = c.Int(nullable: false),
                        Status = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Country", t => t.CountryID)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedById)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedById)
                .ForeignKey("dbo.AspNetUsers", t => t.ModifiedById)
                .Index(t => t.CountryID)
                .Index(t => t.CreatedById)
                .Index(t => t.ModifiedById)
                .Index(t => t.DeletedById);
            
            CreateTable(
                "dbo.Country",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Lang = c.Double(nullable: false),
                        Late = c.Double(nullable: false),
                        ZoomLevel = c.Int(nullable: false),
                        Accuracy = c.Double(nullable: false),
                        Name = c.String(maxLength: 500),
                        CreatedById = c.Long(),
                        CreatedDate = c.DateTime(),
                        ModifiedById = c.Long(),
                        ModifiedDate = c.DateTime(),
                        DeletedById = c.Long(),
                        DeletedDate = c.DateTime(),
                        Version = c.Int(nullable: false),
                        Status = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedById)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedById)
                .ForeignKey("dbo.AspNetUsers", t => t.ModifiedById)
                .Index(t => t.CreatedById)
                .Index(t => t.ModifiedById)
                .Index(t => t.DeletedById);
            
            CreateTable(
                "dbo.FacilitiesGroup",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Steet = c.String(),
                        FacilitiesGroupOwner = c.String(),
                        IndustrialCity_Id = c.Long(nullable: false),
                        Lang = c.Double(nullable: false),
                        Late = c.Double(nullable: false),
                        ZoomLevel = c.Int(nullable: false),
                        Accuracy = c.Double(nullable: false),
                        Name = c.String(maxLength: 500),
                        CreatedById = c.Long(),
                        CreatedDate = c.DateTime(),
                        ModifiedById = c.Long(),
                        ModifiedDate = c.DateTime(),
                        DeletedById = c.Long(),
                        DeletedDate = c.DateTime(),
                        Version = c.Int(nullable: false),
                        Status = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedById)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedById)
                .ForeignKey("dbo.IndustrialCity", t => t.IndustrialCity_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ModifiedById)
                .Index(t => t.IndustrialCity_Id)
                .Index(t => t.CreatedById)
                .Index(t => t.ModifiedById)
                .Index(t => t.DeletedById);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.Long(nullable: false),
                        RoleId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Worker",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        JobName = c.String(),
                        RelegionId = c.Long(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        NationalityId = c.Long(nullable: false),
                        IDCardNumber = c.String(),
                        IDCardStartDate = c.DateTime(nullable: false),
                        IDCardExpireDate = c.DateTime(nullable: false),
                        PhoneNumber = c.String(),
                        EmployeerName = c.String(),
                        IDPicture = c.String(),
                        WorkerPicture = c.String(),
                        Name = c.String(maxLength: 500),
                        CreatedById = c.Long(),
                        CreatedDate = c.DateTime(),
                        ModifiedById = c.Long(),
                        ModifiedDate = c.DateTime(),
                        DeletedById = c.Long(),
                        DeletedDate = c.DateTime(),
                        Version = c.Int(nullable: false),
                        Status = c.Int(),
                        Building_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedById)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedById)
                .ForeignKey("dbo.AspNetUsers", t => t.ModifiedById)
                .ForeignKey("dbo.Building", t => t.Building_Id)
                .Index(t => t.CreatedById)
                .Index(t => t.ModifiedById)
                .Index(t => t.DeletedById)
                .Index(t => t.Building_Id);
            
            CreateTable(
                "dbo.EmployeeIndustrialCity",
                c => new
                    {
                        EmployeeId = c.Long(nullable: false),
                        IndustrialCityId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.EmployeeId, t.IndustrialCityId })
                .ForeignKey("dbo.Employee", t => t.EmployeeId)
                .ForeignKey("dbo.IndustrialCity", t => t.IndustrialCityId)
                .Index(t => t.EmployeeId)
                .Index(t => t.IndustrialCityId);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        UserAccountId = c.Long(nullable: false),
                        ADUsername = c.String(),
                        FinalPermission = c.Boolean(nullable: false),
                        CreatedById = c.Long(),
                        CreatedDate = c.DateTime(),
                        ModifiedById = c.Long(),
                        ModifiedDate = c.DateTime(),
                        DeletedById = c.Long(),
                        DeletedDate = c.DateTime(),
                        Version = c.Int(nullable: false),
                        Status = c.Int(),
                        Job_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedById)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedById)
                .ForeignKey("dbo.Job", t => t.Job_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ModifiedById)
                .ForeignKey("dbo.AspNetUsers", t => t.UserAccountId)
                .Index(t => t.UserAccountId)
                .Index(t => t.CreatedById)
                .Index(t => t.ModifiedById)
                .Index(t => t.DeletedById)
                .Index(t => t.Job_Id);
            
            CreateTable(
                "dbo.Job",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 500),
                        CreatedById = c.Long(),
                        CreatedDate = c.DateTime(),
                        ModifiedById = c.Long(),
                        ModifiedDate = c.DateTime(),
                        DeletedById = c.Long(),
                        DeletedDate = c.DateTime(),
                        Version = c.Int(nullable: false),
                        Status = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedById)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedById)
                .ForeignKey("dbo.AspNetUsers", t => t.ModifiedById)
                .Index(t => t.CreatedById)
                .Index(t => t.ModifiedById)
                .Index(t => t.DeletedById);
            
            CreateTable(
                "dbo.Facility",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Client_Id = c.Long(),
                        Space = c.Int(nullable: false),
                        Email = c.String(),
                        Phone = c.String(),
                        SubActivity_Id = c.Long(),
                        InternalOldActivity = c.Long(nullable: false),
                        ExternalOldActivity = c.Long(nullable: false),
                        IndustrialCity_Id = c.Long(),
                        FacilitiesGroup_Id = c.Long(),
                        OtherFacilitiesGroup = c.String(),
                        FacilitiesGroupOwner = c.String(),
                        Address = c.String(),
                        Lang = c.Double(nullable: false),
                        Late = c.Double(nullable: false),
                        Ref = c.String(),
                        Name = c.String(maxLength: 500),
                        CreatedById = c.Long(),
                        CreatedDate = c.DateTime(),
                        ModifiedById = c.Long(),
                        ModifiedDate = c.DateTime(),
                        DeletedById = c.Long(),
                        DeletedDate = c.DateTime(),
                        Version = c.Int(nullable: false),
                        Status = c.Int(),
                        Facility_Id = c.Long(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        CommcommercialID_Id = c.Long(),
                        FacilitySpaceDesign_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Client", t => t.Client_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedById)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedById)
                .ForeignKey("dbo.FacilitiesGroup", t => t.FacilitiesGroup_Id)
                .ForeignKey("dbo.IndustrialCity", t => t.IndustrialCity_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ModifiedById)
                .ForeignKey("dbo.SubActivity", t => t.SubActivity_Id)
                .ForeignKey("dbo.AttachmentFile", t => t.CommcommercialID_Id)
                .ForeignKey("dbo.Facility", t => t.Facility_Id)
                .ForeignKey("dbo.AttachmentFile", t => t.FacilitySpaceDesign_Id)
                .Index(t => t.Client_Id)
                .Index(t => t.SubActivity_Id)
                .Index(t => t.IndustrialCity_Id)
                .Index(t => t.FacilitiesGroup_Id)
                .Index(t => t.CreatedById)
                .Index(t => t.ModifiedById)
                .Index(t => t.DeletedById)
                .Index(t => t.Facility_Id)
                .Index(t => t.CommcommercialID_Id)
                .Index(t => t.FacilitySpaceDesign_Id);
            
            CreateTable(
                "dbo.SalesItem",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 500),
                        CreatedById = c.Long(),
                        CreatedDate = c.DateTime(),
                        ModifiedById = c.Long(),
                        ModifiedDate = c.DateTime(),
                        DeletedById = c.Long(),
                        DeletedDate = c.DateTime(),
                        Version = c.Int(nullable: false),
                        Status = c.Int(),
                        Facility_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedById)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedById)
                .ForeignKey("dbo.AspNetUsers", t => t.ModifiedById)
                .ForeignKey("dbo.Facility", t => t.Facility_Id)
                .Index(t => t.CreatedById)
                .Index(t => t.ModifiedById)
                .Index(t => t.DeletedById)
                .Index(t => t.Facility_Id);
            
            CreateTable(
                "dbo.SubActivity",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        MainActivity_Id = c.Long(nullable: false),
                        Name = c.String(maxLength: 500),
                        CreatedById = c.Long(),
                        CreatedDate = c.DateTime(),
                        ModifiedById = c.Long(),
                        ModifiedDate = c.DateTime(),
                        DeletedById = c.Long(),
                        DeletedDate = c.DateTime(),
                        Version = c.Int(nullable: false),
                        Status = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedById)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedById)
                .ForeignKey("dbo.MainActivity", t => t.MainActivity_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ModifiedById)
                .Index(t => t.MainActivity_Id)
                .Index(t => t.CreatedById)
                .Index(t => t.ModifiedById)
                .Index(t => t.DeletedById);
            
            CreateTable(
                "dbo.MainActivity",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 500),
                        CreatedById = c.Long(),
                        CreatedDate = c.DateTime(),
                        ModifiedById = c.Long(),
                        ModifiedDate = c.DateTime(),
                        DeletedById = c.Long(),
                        DeletedDate = c.DateTime(),
                        Version = c.Int(nullable: false),
                        Status = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedById)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedById)
                .ForeignKey("dbo.AspNetUsers", t => t.ModifiedById)
                .Index(t => t.CreatedById)
                .Index(t => t.ModifiedById)
                .Index(t => t.DeletedById);
            
            CreateTable(
                "dbo.AttachmentFile",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FilePath = c.String(),
                        Name = c.String(maxLength: 500),
                        CreatedById = c.Long(),
                        CreatedDate = c.DateTime(),
                        ModifiedById = c.Long(),
                        ModifiedDate = c.DateTime(),
                        DeletedById = c.Long(),
                        DeletedDate = c.DateTime(),
                        Version = c.Int(nullable: false),
                        Status = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedById)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedById)
                .ForeignKey("dbo.AspNetUsers", t => t.ModifiedById)
                .Index(t => t.CreatedById)
                .Index(t => t.ModifiedById)
                .Index(t => t.DeletedById);
            
            CreateTable(
                "dbo.Permission",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 500),
                        CreatedById = c.Long(),
                        CreatedDate = c.DateTime(),
                        ModifiedById = c.Long(),
                        ModifiedDate = c.DateTime(),
                        DeletedById = c.Long(),
                        DeletedDate = c.DateTime(),
                        Version = c.Int(nullable: false),
                        Status = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedById)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedById)
                .ForeignKey("dbo.AspNetUsers", t => t.ModifiedById)
                .Index(t => t.CreatedById)
                .Index(t => t.ModifiedById)
                .Index(t => t.DeletedById);
            
            CreateTable(
                "dbo.RolePermissions",
                c => new
                    {
                        RoleId = c.Long(nullable: false),
                        PermissionId = c.Long(nullable: false),
                        Id = c.Long(nullable: false, identity: true),
                        CreatedById = c.Long(),
                        CreatedDate = c.DateTime(),
                        ModifiedById = c.Long(),
                        ModifiedDate = c.DateTime(),
                        DeletedById = c.Long(),
                        DeletedDate = c.DateTime(),
                        Version = c.Int(nullable: false),
                        Status = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedById)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedById)
                .ForeignKey("dbo.AspNetUsers", t => t.ModifiedById)
                .ForeignKey("dbo.Permission", t => t.PermissionId)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId)
                .Index(t => t.RoleId)
                .Index(t => t.PermissionId)
                .Index(t => t.CreatedById)
                .Index(t => t.ModifiedById)
                .Index(t => t.DeletedById);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        DisplayName = c.String(),
                        CreatedById = c.Long(),
                        CreatedDate = c.DateTime(),
                        ModifiedById = c.Long(),
                        ModifiedDate = c.DateTime(),
                        DeletedById = c.Long(),
                        DeletedDate = c.DateTime(),
                        Version = c.Int(nullable: false),
                        Status = c.Int(),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedById)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedById)
                .ForeignKey("dbo.AspNetUsers", t => t.ModifiedById)
                .Index(t => t.CreatedById)
                .Index(t => t.ModifiedById)
                .Index(t => t.DeletedById)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.UserAccountPermission",
                c => new
                    {
                        UserAccountId = c.Long(nullable: false),
                        PermissionId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserAccountId, t.PermissionId })
                .ForeignKey("dbo.Permission", t => t.PermissionId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserAccountId)
                .Index(t => t.UserAccountId)
                .Index(t => t.PermissionId);
            
            CreateTable(
                "dbo.Resource",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ResourceKey = c.String(maxLength: 200),
                        ResourceValue = c.String(maxLength: 200),
                        ResourceLang = c.String(maxLength: 200),
                        IsDeleted = c.Boolean(),
                        CreatedById = c.Long(),
                        CreatedDate = c.DateTime(),
                        ModifiedById = c.Long(),
                        ModifiedDate = c.DateTime(),
                        DeletedById = c.Long(),
                        DeletedDate = c.DateTime(),
                        Version = c.Int(nullable: false),
                        Status = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedById)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedById)
                .ForeignKey("dbo.AspNetUsers", t => t.ModifiedById)
                .Index(t => t.ResourceKey)
                .Index(t => t.CreatedById)
                .Index(t => t.ModifiedById)
                .Index(t => t.DeletedById);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Resource", "ModifiedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Resource", "DeletedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Resource", "CreatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserAccountPermission", "UserAccountId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserAccountPermission", "PermissionId", "dbo.Permission");
            DropForeignKey("dbo.RolePermissions", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetRoles", "ModifiedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetRoles", "DeletedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetRoles", "CreatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.RolePermissions", "PermissionId", "dbo.Permission");
            DropForeignKey("dbo.RolePermissions", "ModifiedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.RolePermissions", "DeletedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.RolePermissions", "CreatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Permission", "ModifiedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Permission", "DeletedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Permission", "CreatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Facility", "FacilitySpaceDesign_Id", "dbo.AttachmentFile");
            DropForeignKey("dbo.Facility", "Facility_Id", "dbo.Facility");
            DropForeignKey("dbo.Facility", "CommcommercialID_Id", "dbo.AttachmentFile");
            DropForeignKey("dbo.AttachmentFile", "ModifiedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.AttachmentFile", "DeletedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.AttachmentFile", "CreatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Facility", "SubActivity_Id", "dbo.SubActivity");
            DropForeignKey("dbo.SubActivity", "ModifiedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.SubActivity", "MainActivity_Id", "dbo.MainActivity");
            DropForeignKey("dbo.MainActivity", "ModifiedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.MainActivity", "DeletedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.MainActivity", "CreatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.SubActivity", "DeletedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.SubActivity", "CreatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.SalesItem", "Facility_Id", "dbo.Facility");
            DropForeignKey("dbo.SalesItem", "ModifiedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.SalesItem", "DeletedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.SalesItem", "CreatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Facility", "ModifiedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Facility", "IndustrialCity_Id", "dbo.IndustrialCity");
            DropForeignKey("dbo.Facility", "FacilitiesGroup_Id", "dbo.FacilitiesGroup");
            DropForeignKey("dbo.Facility", "DeletedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Facility", "CreatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Facility", "Client_Id", "dbo.Client");
            DropForeignKey("dbo.EmployeeIndustrialCity", "IndustrialCityId", "dbo.IndustrialCity");
            DropForeignKey("dbo.EmployeeIndustrialCity", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.Employee", "UserAccountId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Employee", "ModifiedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Employee", "Job_Id", "dbo.Job");
            DropForeignKey("dbo.Job", "ModifiedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Job", "DeletedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Job", "CreatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Employee", "DeletedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Employee", "CreatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Worker", "Building_Id", "dbo.Building");
            DropForeignKey("dbo.Worker", "ModifiedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Worker", "DeletedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Worker", "CreatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Building", "ModifiedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Building", "DeletedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Building", "CreatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "ModifiedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserAccountIndustrialCity", "UserAccount_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserAccountIndustrialCity", "ModifiedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserAccountIndustrialCity", "IndustrialCity_Id", "dbo.IndustrialCity");
            DropForeignKey("dbo.IndustrialCity", "ModifiedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.FacilitiesGroup", "ModifiedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.FacilitiesGroup", "IndustrialCity_Id", "dbo.IndustrialCity");
            DropForeignKey("dbo.FacilitiesGroup", "DeletedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.FacilitiesGroup", "CreatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.IndustrialCity", "DeletedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.IndustrialCity", "CreatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.IndustrialCity", "City_Id", "dbo.City");
            DropForeignKey("dbo.City", "ModifiedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.City", "DeletedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.City", "CreatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.City", "CountryID", "dbo.Country");
            DropForeignKey("dbo.Country", "ModifiedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Country", "DeletedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Country", "CreatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserAccountIndustrialCity", "DeletedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserAccountIndustrialCity", "CreatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "DeletedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "CreatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Client", "UserAccount_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "Client_Id", "dbo.Client");
            DropForeignKey("dbo.Client", "ModifiedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Client", "DeletedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Client", "CreatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Resource", new[] { "DeletedById" });
            DropIndex("dbo.Resource", new[] { "ModifiedById" });
            DropIndex("dbo.Resource", new[] { "CreatedById" });
            DropIndex("dbo.Resource", new[] { "ResourceKey" });
            DropIndex("dbo.UserAccountPermission", new[] { "PermissionId" });
            DropIndex("dbo.UserAccountPermission", new[] { "UserAccountId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetRoles", new[] { "DeletedById" });
            DropIndex("dbo.AspNetRoles", new[] { "ModifiedById" });
            DropIndex("dbo.AspNetRoles", new[] { "CreatedById" });
            DropIndex("dbo.RolePermissions", new[] { "DeletedById" });
            DropIndex("dbo.RolePermissions", new[] { "ModifiedById" });
            DropIndex("dbo.RolePermissions", new[] { "CreatedById" });
            DropIndex("dbo.RolePermissions", new[] { "PermissionId" });
            DropIndex("dbo.RolePermissions", new[] { "RoleId" });
            DropIndex("dbo.Permission", new[] { "DeletedById" });
            DropIndex("dbo.Permission", new[] { "ModifiedById" });
            DropIndex("dbo.Permission", new[] { "CreatedById" });
            DropIndex("dbo.AttachmentFile", new[] { "DeletedById" });
            DropIndex("dbo.AttachmentFile", new[] { "ModifiedById" });
            DropIndex("dbo.AttachmentFile", new[] { "CreatedById" });
            DropIndex("dbo.MainActivity", new[] { "DeletedById" });
            DropIndex("dbo.MainActivity", new[] { "ModifiedById" });
            DropIndex("dbo.MainActivity", new[] { "CreatedById" });
            DropIndex("dbo.SubActivity", new[] { "DeletedById" });
            DropIndex("dbo.SubActivity", new[] { "ModifiedById" });
            DropIndex("dbo.SubActivity", new[] { "CreatedById" });
            DropIndex("dbo.SubActivity", new[] { "MainActivity_Id" });
            DropIndex("dbo.SalesItem", new[] { "Facility_Id" });
            DropIndex("dbo.SalesItem", new[] { "DeletedById" });
            DropIndex("dbo.SalesItem", new[] { "ModifiedById" });
            DropIndex("dbo.SalesItem", new[] { "CreatedById" });
            DropIndex("dbo.Facility", new[] { "FacilitySpaceDesign_Id" });
            DropIndex("dbo.Facility", new[] { "CommcommercialID_Id" });
            DropIndex("dbo.Facility", new[] { "Facility_Id" });
            DropIndex("dbo.Facility", new[] { "DeletedById" });
            DropIndex("dbo.Facility", new[] { "ModifiedById" });
            DropIndex("dbo.Facility", new[] { "CreatedById" });
            DropIndex("dbo.Facility", new[] { "FacilitiesGroup_Id" });
            DropIndex("dbo.Facility", new[] { "IndustrialCity_Id" });
            DropIndex("dbo.Facility", new[] { "SubActivity_Id" });
            DropIndex("dbo.Facility", new[] { "Client_Id" });
            DropIndex("dbo.Job", new[] { "DeletedById" });
            DropIndex("dbo.Job", new[] { "ModifiedById" });
            DropIndex("dbo.Job", new[] { "CreatedById" });
            DropIndex("dbo.Employee", new[] { "Job_Id" });
            DropIndex("dbo.Employee", new[] { "DeletedById" });
            DropIndex("dbo.Employee", new[] { "ModifiedById" });
            DropIndex("dbo.Employee", new[] { "CreatedById" });
            DropIndex("dbo.Employee", new[] { "UserAccountId" });
            DropIndex("dbo.EmployeeIndustrialCity", new[] { "IndustrialCityId" });
            DropIndex("dbo.EmployeeIndustrialCity", new[] { "EmployeeId" });
            DropIndex("dbo.Worker", new[] { "Building_Id" });
            DropIndex("dbo.Worker", new[] { "DeletedById" });
            DropIndex("dbo.Worker", new[] { "ModifiedById" });
            DropIndex("dbo.Worker", new[] { "CreatedById" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.FacilitiesGroup", new[] { "DeletedById" });
            DropIndex("dbo.FacilitiesGroup", new[] { "ModifiedById" });
            DropIndex("dbo.FacilitiesGroup", new[] { "CreatedById" });
            DropIndex("dbo.FacilitiesGroup", new[] { "IndustrialCity_Id" });
            DropIndex("dbo.Country", new[] { "DeletedById" });
            DropIndex("dbo.Country", new[] { "ModifiedById" });
            DropIndex("dbo.Country", new[] { "CreatedById" });
            DropIndex("dbo.City", new[] { "DeletedById" });
            DropIndex("dbo.City", new[] { "ModifiedById" });
            DropIndex("dbo.City", new[] { "CreatedById" });
            DropIndex("dbo.City", new[] { "CountryID" });
            DropIndex("dbo.IndustrialCity", new[] { "DeletedById" });
            DropIndex("dbo.IndustrialCity", new[] { "ModifiedById" });
            DropIndex("dbo.IndustrialCity", new[] { "CreatedById" });
            DropIndex("dbo.IndustrialCity", new[] { "City_Id" });
            DropIndex("dbo.UserAccountIndustrialCity", new[] { "DeletedById" });
            DropIndex("dbo.UserAccountIndustrialCity", new[] { "ModifiedById" });
            DropIndex("dbo.UserAccountIndustrialCity", new[] { "CreatedById" });
            DropIndex("dbo.UserAccountIndustrialCity", new[] { "IndustrialCity_Id" });
            DropIndex("dbo.UserAccountIndustrialCity", new[] { "UserAccount_Id" });
            DropIndex("dbo.Client", new[] { "DeletedById" });
            DropIndex("dbo.Client", new[] { "ModifiedById" });
            DropIndex("dbo.Client", new[] { "CreatedById" });
            DropIndex("dbo.Client", new[] { "UserAccount_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUsers", new[] { "DeletedById" });
            DropIndex("dbo.AspNetUsers", new[] { "ModifiedById" });
            DropIndex("dbo.AspNetUsers", new[] { "CreatedById" });
            DropIndex("dbo.AspNetUsers", new[] { "Client_Id" });
            DropIndex("dbo.Building", new[] { "DeletedById" });
            DropIndex("dbo.Building", new[] { "ModifiedById" });
            DropIndex("dbo.Building", new[] { "CreatedById" });
            DropTable("dbo.Resource");
            DropTable("dbo.UserAccountPermission");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.RolePermissions");
            DropTable("dbo.Permission");
            DropTable("dbo.AttachmentFile");
            DropTable("dbo.MainActivity");
            DropTable("dbo.SubActivity");
            DropTable("dbo.SalesItem");
            DropTable("dbo.Facility");
            DropTable("dbo.Job");
            DropTable("dbo.Employee");
            DropTable("dbo.EmployeeIndustrialCity");
            DropTable("dbo.Worker");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.FacilitiesGroup");
            DropTable("dbo.Country");
            DropTable("dbo.City");
            DropTable("dbo.IndustrialCity");
            DropTable("dbo.UserAccountIndustrialCity");
            DropTable("dbo.Client");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Building");
        }
    }
}
