namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AddFacilityOrder",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Ref = c.String(),
                        CommcommercialID = c.String(),
                        FacilitySpaceDesign = c.String(),
                        Facility_Id = c.Long(),
                        OtherFiles = c.String(),
                        RefusedFields = c.String(),
                        ApprovalDate = c.DateTime(),
                        FinalApprovalDate = c.DateTime(),
                        CreatedById = c.Long(),
                        CreatedDate = c.DateTime(),
                        ModifiedById = c.Long(),
                        ModifiedDate = c.DateTime(),
                        DeletedById = c.Long(),
                        DeletedDate = c.DateTime(),
                        Version = c.Int(nullable: false),
                        Status = c.Int(),
                        ApprovaledBy_Id = c.Long(),
                        FinalApprovaledBy_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserAccount", t => t.ApprovaledBy_Id)
                .ForeignKey("dbo.UserAccount", t => t.CreatedById)
                .ForeignKey("dbo.UserAccount", t => t.DeletedById)
                .ForeignKey("dbo.Facility", t => t.Facility_Id)
                .ForeignKey("dbo.UserAccount", t => t.FinalApprovaledBy_Id)
                .ForeignKey("dbo.UserAccount", t => t.ModifiedById)
                .Index(t => t.Facility_Id)
                .Index(t => t.CreatedById)
                .Index(t => t.ModifiedById)
                .Index(t => t.DeletedById)
                .Index(t => t.ApprovaledBy_Id)
                .Index(t => t.FinalApprovaledBy_Id);
            
            CreateTable(
                "dbo.UserAccount",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FullName = c.String(),
                        SSID = c.String(),
                        UserIdPicture = c.String(),
                        Client_Id = c.Long(),
                        Employee_Id = c.Long(),
                        CountryCode = c.Int(nullable: false),
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
                .ForeignKey("dbo.UserAccount", t => t.CreatedById)
                .ForeignKey("dbo.UserAccount", t => t.DeletedById)
                .ForeignKey("dbo.Employee", t => t.Employee_Id)
                .ForeignKey("dbo.UserAccount", t => t.ModifiedById)
                .Index(t => t.Client_Id)
                .Index(t => t.Employee_Id)
                .Index(t => t.CreatedById)
                .Index(t => t.ModifiedById)
                .Index(t => t.DeletedById)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.UserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Long(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserAccount", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FullName = c.String(),
                        Organization = c.String(),
                        Fax = c.String(),
                        HeadOfficeAddress = c.String(),
                        PhoneNumber = c.String(),
                        Photo = c.String(),
                        SSID = c.String(),
                        UserIdPicture = c.String(),
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
                .ForeignKey("dbo.UserAccount", t => t.CreatedById)
                .ForeignKey("dbo.UserAccount", t => t.DeletedById)
                .ForeignKey("dbo.UserAccount", t => t.ModifiedById)
                .Index(t => t.CreatedById)
                .Index(t => t.ModifiedById)
                .Index(t => t.DeletedById);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Job_Id = c.Long(),
                        UserAccount_Id = c.Long(nullable: false),
                        ADUsername = c.String(),
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
                .ForeignKey("dbo.UserAccount", t => t.CreatedById)
                .ForeignKey("dbo.UserAccount", t => t.DeletedById)
                .ForeignKey("dbo.Job", t => t.Job_Id)
                .ForeignKey("dbo.UserAccount", t => t.ModifiedById)
                .ForeignKey("dbo.UserAccount", t => t.UserAccount_Id)
                .Index(t => t.Job_Id)
                .Index(t => t.UserAccount_Id)
                .Index(t => t.CreatedById)
                .Index(t => t.ModifiedById)
                .Index(t => t.DeletedById);
            
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
                .ForeignKey("dbo.UserAccount", t => t.CreatedById)
                .ForeignKey("dbo.UserAccount", t => t.DeletedById)
                .ForeignKey("dbo.UserAccount", t => t.ModifiedById)
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
                .ForeignKey("dbo.UserAccount", t => t.CreatedById)
                .ForeignKey("dbo.UserAccount", t => t.DeletedById)
                .ForeignKey("dbo.UserAccount", t => t.ModifiedById)
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
                .ForeignKey("dbo.UserAccount", t => t.CreatedById)
                .ForeignKey("dbo.UserAccount", t => t.DeletedById)
                .ForeignKey("dbo.UserAccount", t => t.ModifiedById)
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
                .ForeignKey("dbo.UserAccount", t => t.CreatedById)
                .ForeignKey("dbo.UserAccount", t => t.DeletedById)
                .ForeignKey("dbo.UserAccount", t => t.ModifiedById)
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
                .ForeignKey("dbo.UserAccount", t => t.CreatedById)
                .ForeignKey("dbo.UserAccount", t => t.DeletedById)
                .ForeignKey("dbo.IndustrialCity", t => t.IndustrialCity_Id)
                .ForeignKey("dbo.UserAccount", t => t.ModifiedById)
                .Index(t => t.IndustrialCity_Id)
                .Index(t => t.CreatedById)
                .Index(t => t.ModifiedById)
                .Index(t => t.DeletedById);
            
            CreateTable(
                "dbo.UserLogin",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.UserAccount", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        UserId = c.Long(nullable: false),
                        RoleId = c.Long(nullable: false),
                        CreatedById = c.Long(),
                        ModifiedById = c.Long(),
                        DeletedById = c.Long(),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        DeletedDate = c.DateTime(),
                        Version = c.Int(nullable: false),
                        Status = c.Int(),
                        Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.UserAccount", t => t.CreatedById)
                .ForeignKey("dbo.UserAccount", t => t.DeletedById)
                .ForeignKey("dbo.UserAccount", t => t.ModifiedById)
                .ForeignKey("dbo.UserAccount", t => t.UserId)
                .ForeignKey("dbo.Role", t => t.RoleId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId)
                .Index(t => t.CreatedById)
                .Index(t => t.ModifiedById)
                .Index(t => t.DeletedById);
            
            CreateTable(
                "dbo.Comment",
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
                        Client_Id = c.Long(),
                        Employee_Id = c.Long(),
                        AddFacilityOrder_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Client", t => t.Client_Id)
                .ForeignKey("dbo.UserAccount", t => t.CreatedById)
                .ForeignKey("dbo.UserAccount", t => t.DeletedById)
                .ForeignKey("dbo.Employee", t => t.Employee_Id)
                .ForeignKey("dbo.UserAccount", t => t.ModifiedById)
                .ForeignKey("dbo.AddFacilityOrder", t => t.AddFacilityOrder_Id)
                .Index(t => t.CreatedById)
                .Index(t => t.ModifiedById)
                .Index(t => t.DeletedById)
                .Index(t => t.Client_Id)
                .Index(t => t.Employee_Id)
                .Index(t => t.AddFacilityOrder_Id);
            
            CreateTable(
                "dbo.Facility",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Client_Id = c.Long(),
                        Space = c.Int(nullable: false),
                        Email = c.String(),
                        Phone = c.String(),
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
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Client", t => t.Client_Id)
                .ForeignKey("dbo.UserAccount", t => t.CreatedById)
                .ForeignKey("dbo.UserAccount", t => t.DeletedById)
                .ForeignKey("dbo.FacilitiesGroup", t => t.FacilitiesGroup_Id)
                .ForeignKey("dbo.IndustrialCity", t => t.IndustrialCity_Id)
                .ForeignKey("dbo.UserAccount", t => t.ModifiedById)
                .Index(t => t.Client_Id)
                .Index(t => t.IndustrialCity_Id)
                .Index(t => t.FacilitiesGroup_Id)
                .Index(t => t.CreatedById)
                .Index(t => t.ModifiedById)
                .Index(t => t.DeletedById);
            
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
                .ForeignKey("dbo.UserAccount", t => t.CreatedById)
                .ForeignKey("dbo.UserAccount", t => t.DeletedById)
                .ForeignKey("dbo.UserAccount", t => t.ModifiedById)
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
                .ForeignKey("dbo.UserAccount", t => t.CreatedById)
                .ForeignKey("dbo.UserAccount", t => t.DeletedById)
                .ForeignKey("dbo.MainActivity", t => t.MainActivity_Id)
                .ForeignKey("dbo.UserAccount", t => t.ModifiedById)
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
                .ForeignKey("dbo.UserAccount", t => t.CreatedById)
                .ForeignKey("dbo.UserAccount", t => t.DeletedById)
                .ForeignKey("dbo.UserAccount", t => t.ModifiedById)
                .Index(t => t.CreatedById)
                .Index(t => t.ModifiedById)
                .Index(t => t.DeletedById);
            
            CreateTable(
                "dbo.Permission",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        DisplayName = c.String(),
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
                .ForeignKey("dbo.UserAccount", t => t.CreatedById)
                .ForeignKey("dbo.UserAccount", t => t.DeletedById)
                .ForeignKey("dbo.UserAccount", t => t.ModifiedById)
                .Index(t => t.CreatedById)
                .Index(t => t.ModifiedById)
                .Index(t => t.DeletedById);
            
            CreateTable(
                "dbo.Role",
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
                .ForeignKey("dbo.UserAccount", t => t.CreatedById)
                .ForeignKey("dbo.UserAccount", t => t.DeletedById)
                .ForeignKey("dbo.UserAccount", t => t.ModifiedById)
                .Index(t => t.CreatedById)
                .Index(t => t.ModifiedById)
                .Index(t => t.DeletedById)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
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
                .ForeignKey("dbo.UserAccount", t => t.CreatedById)
                .ForeignKey("dbo.UserAccount", t => t.DeletedById)
                .ForeignKey("dbo.UserAccount", t => t.ModifiedById)
                .Index(t => t.ResourceKey)
                .Index(t => t.CreatedById)
                .Index(t => t.ModifiedById)
                .Index(t => t.DeletedById);
            
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
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserAccount", t => t.CreatedById)
                .ForeignKey("dbo.UserAccount", t => t.DeletedById)
                .ForeignKey("dbo.UserAccount", t => t.ModifiedById)
                .Index(t => t.CreatedById)
                .Index(t => t.ModifiedById)
                .Index(t => t.DeletedById);
            
            CreateTable(
                "dbo.UserAccountIndustrialCity",
                c => new
                    {
                        UserAccount_Id = c.Long(nullable: false),
                        IndustrialCity_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserAccount_Id, t.IndustrialCity_Id })
                .ForeignKey("dbo.UserAccount", t => t.UserAccount_Id)
                .ForeignKey("dbo.IndustrialCity", t => t.IndustrialCity_Id)
                .Index(t => t.UserAccount_Id)
                .Index(t => t.IndustrialCity_Id);
            
            CreateTable(
                "dbo.SubActivityFacility",
                c => new
                    {
                        SubActivity_Id = c.Long(nullable: false),
                        Facility_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.SubActivity_Id, t.Facility_Id })
                .ForeignKey("dbo.SubActivity", t => t.SubActivity_Id)
                .ForeignKey("dbo.Facility", t => t.Facility_Id)
                .Index(t => t.SubActivity_Id)
                .Index(t => t.Facility_Id);
            
            CreateTable(
                "dbo.RolePermission",
                c => new
                    {
                        Role_Id = c.Long(nullable: false),
                        Permission_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.Role_Id, t.Permission_Id })
                .ForeignKey("dbo.Role", t => t.Role_Id)
                .ForeignKey("dbo.Permission", t => t.Permission_Id)
                .Index(t => t.Role_Id)
                .Index(t => t.Permission_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Worker", "ModifiedById", "dbo.UserAccount");
            DropForeignKey("dbo.Worker", "DeletedById", "dbo.UserAccount");
            DropForeignKey("dbo.Worker", "CreatedById", "dbo.UserAccount");
            DropForeignKey("dbo.Resource", "ModifiedById", "dbo.UserAccount");
            DropForeignKey("dbo.Resource", "DeletedById", "dbo.UserAccount");
            DropForeignKey("dbo.Resource", "CreatedById", "dbo.UserAccount");
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Role");
            DropForeignKey("dbo.RolePermission", "Permission_Id", "dbo.Permission");
            DropForeignKey("dbo.RolePermission", "Role_Id", "dbo.Role");
            DropForeignKey("dbo.Role", "ModifiedById", "dbo.UserAccount");
            DropForeignKey("dbo.Role", "DeletedById", "dbo.UserAccount");
            DropForeignKey("dbo.Role", "CreatedById", "dbo.UserAccount");
            DropForeignKey("dbo.Permission", "ModifiedById", "dbo.UserAccount");
            DropForeignKey("dbo.Permission", "DeletedById", "dbo.UserAccount");
            DropForeignKey("dbo.Permission", "CreatedById", "dbo.UserAccount");
            DropForeignKey("dbo.AddFacilityOrder", "ModifiedById", "dbo.UserAccount");
            DropForeignKey("dbo.AddFacilityOrder", "FinalApprovaledBy_Id", "dbo.UserAccount");
            DropForeignKey("dbo.AddFacilityOrder", "Facility_Id", "dbo.Facility");
            DropForeignKey("dbo.SubActivity", "ModifiedById", "dbo.UserAccount");
            DropForeignKey("dbo.SubActivity", "MainActivity_Id", "dbo.MainActivity");
            DropForeignKey("dbo.MainActivity", "ModifiedById", "dbo.UserAccount");
            DropForeignKey("dbo.MainActivity", "DeletedById", "dbo.UserAccount");
            DropForeignKey("dbo.MainActivity", "CreatedById", "dbo.UserAccount");
            DropForeignKey("dbo.SubActivityFacility", "Facility_Id", "dbo.Facility");
            DropForeignKey("dbo.SubActivityFacility", "SubActivity_Id", "dbo.SubActivity");
            DropForeignKey("dbo.SubActivity", "DeletedById", "dbo.UserAccount");
            DropForeignKey("dbo.SubActivity", "CreatedById", "dbo.UserAccount");
            DropForeignKey("dbo.SalesItem", "Facility_Id", "dbo.Facility");
            DropForeignKey("dbo.SalesItem", "ModifiedById", "dbo.UserAccount");
            DropForeignKey("dbo.SalesItem", "DeletedById", "dbo.UserAccount");
            DropForeignKey("dbo.SalesItem", "CreatedById", "dbo.UserAccount");
            DropForeignKey("dbo.Facility", "ModifiedById", "dbo.UserAccount");
            DropForeignKey("dbo.Facility", "IndustrialCity_Id", "dbo.IndustrialCity");
            DropForeignKey("dbo.Facility", "FacilitiesGroup_Id", "dbo.FacilitiesGroup");
            DropForeignKey("dbo.Facility", "DeletedById", "dbo.UserAccount");
            DropForeignKey("dbo.Facility", "CreatedById", "dbo.UserAccount");
            DropForeignKey("dbo.Facility", "Client_Id", "dbo.Client");
            DropForeignKey("dbo.AddFacilityOrder", "DeletedById", "dbo.UserAccount");
            DropForeignKey("dbo.AddFacilityOrder", "CreatedById", "dbo.UserAccount");
            DropForeignKey("dbo.Comment", "AddFacilityOrder_Id", "dbo.AddFacilityOrder");
            DropForeignKey("dbo.Comment", "ModifiedById", "dbo.UserAccount");
            DropForeignKey("dbo.Comment", "Employee_Id", "dbo.Employee");
            DropForeignKey("dbo.Comment", "DeletedById", "dbo.UserAccount");
            DropForeignKey("dbo.Comment", "CreatedById", "dbo.UserAccount");
            DropForeignKey("dbo.Comment", "Client_Id", "dbo.Client");
            DropForeignKey("dbo.AddFacilityOrder", "ApprovaledBy_Id", "dbo.UserAccount");
            DropForeignKey("dbo.UserRole", "UserId", "dbo.UserAccount");
            DropForeignKey("dbo.UserRole", "ModifiedById", "dbo.UserAccount");
            DropForeignKey("dbo.UserRole", "DeletedById", "dbo.UserAccount");
            DropForeignKey("dbo.UserRole", "CreatedById", "dbo.UserAccount");
            DropForeignKey("dbo.UserAccount", "ModifiedById", "dbo.UserAccount");
            DropForeignKey("dbo.UserLogin", "UserId", "dbo.UserAccount");
            DropForeignKey("dbo.UserAccountIndustrialCity", "IndustrialCity_Id", "dbo.IndustrialCity");
            DropForeignKey("dbo.UserAccountIndustrialCity", "UserAccount_Id", "dbo.UserAccount");
            DropForeignKey("dbo.IndustrialCity", "ModifiedById", "dbo.UserAccount");
            DropForeignKey("dbo.FacilitiesGroup", "ModifiedById", "dbo.UserAccount");
            DropForeignKey("dbo.FacilitiesGroup", "IndustrialCity_Id", "dbo.IndustrialCity");
            DropForeignKey("dbo.FacilitiesGroup", "DeletedById", "dbo.UserAccount");
            DropForeignKey("dbo.FacilitiesGroup", "CreatedById", "dbo.UserAccount");
            DropForeignKey("dbo.IndustrialCity", "DeletedById", "dbo.UserAccount");
            DropForeignKey("dbo.IndustrialCity", "CreatedById", "dbo.UserAccount");
            DropForeignKey("dbo.IndustrialCity", "City_Id", "dbo.City");
            DropForeignKey("dbo.City", "ModifiedById", "dbo.UserAccount");
            DropForeignKey("dbo.City", "DeletedById", "dbo.UserAccount");
            DropForeignKey("dbo.City", "CreatedById", "dbo.UserAccount");
            DropForeignKey("dbo.City", "CountryID", "dbo.Country");
            DropForeignKey("dbo.Country", "ModifiedById", "dbo.UserAccount");
            DropForeignKey("dbo.Country", "DeletedById", "dbo.UserAccount");
            DropForeignKey("dbo.Country", "CreatedById", "dbo.UserAccount");
            DropForeignKey("dbo.UserAccount", "Employee_Id", "dbo.Employee");
            DropForeignKey("dbo.Employee", "UserAccount_Id", "dbo.UserAccount");
            DropForeignKey("dbo.Employee", "ModifiedById", "dbo.UserAccount");
            DropForeignKey("dbo.Employee", "Job_Id", "dbo.Job");
            DropForeignKey("dbo.Job", "ModifiedById", "dbo.UserAccount");
            DropForeignKey("dbo.Job", "DeletedById", "dbo.UserAccount");
            DropForeignKey("dbo.Job", "CreatedById", "dbo.UserAccount");
            DropForeignKey("dbo.Employee", "DeletedById", "dbo.UserAccount");
            DropForeignKey("dbo.Employee", "CreatedById", "dbo.UserAccount");
            DropForeignKey("dbo.UserAccount", "DeletedById", "dbo.UserAccount");
            DropForeignKey("dbo.UserAccount", "CreatedById", "dbo.UserAccount");
            DropForeignKey("dbo.UserAccount", "Client_Id", "dbo.Client");
            DropForeignKey("dbo.Client", "ModifiedById", "dbo.UserAccount");
            DropForeignKey("dbo.Client", "DeletedById", "dbo.UserAccount");
            DropForeignKey("dbo.Client", "CreatedById", "dbo.UserAccount");
            DropForeignKey("dbo.UserClaim", "UserId", "dbo.UserAccount");
            DropIndex("dbo.RolePermission", new[] { "Permission_Id" });
            DropIndex("dbo.RolePermission", new[] { "Role_Id" });
            DropIndex("dbo.SubActivityFacility", new[] { "Facility_Id" });
            DropIndex("dbo.SubActivityFacility", new[] { "SubActivity_Id" });
            DropIndex("dbo.UserAccountIndustrialCity", new[] { "IndustrialCity_Id" });
            DropIndex("dbo.UserAccountIndustrialCity", new[] { "UserAccount_Id" });
            DropIndex("dbo.Worker", new[] { "DeletedById" });
            DropIndex("dbo.Worker", new[] { "ModifiedById" });
            DropIndex("dbo.Worker", new[] { "CreatedById" });
            DropIndex("dbo.Resource", new[] { "DeletedById" });
            DropIndex("dbo.Resource", new[] { "ModifiedById" });
            DropIndex("dbo.Resource", new[] { "CreatedById" });
            DropIndex("dbo.Resource", new[] { "ResourceKey" });
            DropIndex("dbo.Role", "RoleNameIndex");
            DropIndex("dbo.Role", new[] { "DeletedById" });
            DropIndex("dbo.Role", new[] { "ModifiedById" });
            DropIndex("dbo.Role", new[] { "CreatedById" });
            DropIndex("dbo.Permission", new[] { "DeletedById" });
            DropIndex("dbo.Permission", new[] { "ModifiedById" });
            DropIndex("dbo.Permission", new[] { "CreatedById" });
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
            DropIndex("dbo.Facility", new[] { "DeletedById" });
            DropIndex("dbo.Facility", new[] { "ModifiedById" });
            DropIndex("dbo.Facility", new[] { "CreatedById" });
            DropIndex("dbo.Facility", new[] { "FacilitiesGroup_Id" });
            DropIndex("dbo.Facility", new[] { "IndustrialCity_Id" });
            DropIndex("dbo.Facility", new[] { "Client_Id" });
            DropIndex("dbo.Comment", new[] { "AddFacilityOrder_Id" });
            DropIndex("dbo.Comment", new[] { "Employee_Id" });
            DropIndex("dbo.Comment", new[] { "Client_Id" });
            DropIndex("dbo.Comment", new[] { "DeletedById" });
            DropIndex("dbo.Comment", new[] { "ModifiedById" });
            DropIndex("dbo.Comment", new[] { "CreatedById" });
            DropIndex("dbo.UserRole", new[] { "DeletedById" });
            DropIndex("dbo.UserRole", new[] { "ModifiedById" });
            DropIndex("dbo.UserRole", new[] { "CreatedById" });
            DropIndex("dbo.UserRole", new[] { "RoleId" });
            DropIndex("dbo.UserRole", new[] { "UserId" });
            DropIndex("dbo.UserLogin", new[] { "UserId" });
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
            DropIndex("dbo.Job", new[] { "DeletedById" });
            DropIndex("dbo.Job", new[] { "ModifiedById" });
            DropIndex("dbo.Job", new[] { "CreatedById" });
            DropIndex("dbo.Employee", new[] { "DeletedById" });
            DropIndex("dbo.Employee", new[] { "ModifiedById" });
            DropIndex("dbo.Employee", new[] { "CreatedById" });
            DropIndex("dbo.Employee", new[] { "UserAccount_Id" });
            DropIndex("dbo.Employee", new[] { "Job_Id" });
            DropIndex("dbo.Client", new[] { "DeletedById" });
            DropIndex("dbo.Client", new[] { "ModifiedById" });
            DropIndex("dbo.Client", new[] { "CreatedById" });
            DropIndex("dbo.UserClaim", new[] { "UserId" });
            DropIndex("dbo.UserAccount", "UserNameIndex");
            DropIndex("dbo.UserAccount", new[] { "DeletedById" });
            DropIndex("dbo.UserAccount", new[] { "ModifiedById" });
            DropIndex("dbo.UserAccount", new[] { "CreatedById" });
            DropIndex("dbo.UserAccount", new[] { "Employee_Id" });
            DropIndex("dbo.UserAccount", new[] { "Client_Id" });
            DropIndex("dbo.AddFacilityOrder", new[] { "FinalApprovaledBy_Id" });
            DropIndex("dbo.AddFacilityOrder", new[] { "ApprovaledBy_Id" });
            DropIndex("dbo.AddFacilityOrder", new[] { "DeletedById" });
            DropIndex("dbo.AddFacilityOrder", new[] { "ModifiedById" });
            DropIndex("dbo.AddFacilityOrder", new[] { "CreatedById" });
            DropIndex("dbo.AddFacilityOrder", new[] { "Facility_Id" });
            DropTable("dbo.RolePermission");
            DropTable("dbo.SubActivityFacility");
            DropTable("dbo.UserAccountIndustrialCity");
            DropTable("dbo.Worker");
            DropTable("dbo.Resource");
            DropTable("dbo.Role");
            DropTable("dbo.Permission");
            DropTable("dbo.MainActivity");
            DropTable("dbo.SubActivity");
            DropTable("dbo.SalesItem");
            DropTable("dbo.Facility");
            DropTable("dbo.Comment");
            DropTable("dbo.UserRole");
            DropTable("dbo.UserLogin");
            DropTable("dbo.FacilitiesGroup");
            DropTable("dbo.Country");
            DropTable("dbo.City");
            DropTable("dbo.IndustrialCity");
            DropTable("dbo.Job");
            DropTable("dbo.Employee");
            DropTable("dbo.Client");
            DropTable("dbo.UserClaim");
            DropTable("dbo.UserAccount");
            DropTable("dbo.AddFacilityOrder");
        }
    }
}
