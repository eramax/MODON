using Domains;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Infrastructure
{
    public class MDContext : IdentityDbContext<UserAccount, Role, long, UserLogins, UserRoles, UserClaims>
    {
        public MDContext() : base("name=DefaultConnection") { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<IndustrialCity> IndustrialCities { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<MainActivity> MainActivities { get; set; }
        public DbSet<SubActivity> SubActivities { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Country> CountryList { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<FacilitiesGroup> FacilitiesGroups { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<AddFacilityOrder> AddFacilityOrders { get; set; }

        public MDContext(string connection) : base(connection)
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            this.RequireUniqueEmail = false;
            Database.SetInitializer<MDContext>(null);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
           

            modelBuilder.Entity<UserAccount>().ToTable("UserAccount");
            modelBuilder.Entity<Role>().ToTable("Role");
            modelBuilder.Entity<UserRoles>().ToTable("UserRole");
            modelBuilder.Entity<UserClaims>().ToTable("UserClaim");
            modelBuilder.Entity<UserLogins>().ToTable("UserLogin");

            modelBuilder.Entity<UserAccount>().HasMany(x => x.IndustrialCities).WithMany(x => x.UserAccounts);
        }
        public static MDContext Create()
        {
            return new MDContext();
        }
    }
}
