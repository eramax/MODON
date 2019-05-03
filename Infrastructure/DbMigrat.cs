using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Infrastructure
{
    public class DbMigrat<TContext> where TContext : DbContext, new()
    {
        public static void Migrat()
        {
            Database.SetInitializer(new DataDbInitializer());
            var configuration = new DataDbConfiguration();
            var migrator = new DbMigrator(configuration);

            if (migrator.GetPendingMigrations().Any())
                migrator.Update();
        }
        internal sealed class DataDbInitializer : MigrateDatabaseToLatestVersion<TContext, DataDbConfiguration> { }
        internal sealed class DataDbConfiguration : DbMigrationsConfiguration<TContext>
        {
            public DataDbConfiguration()
            {
                AutomaticMigrationsEnabled = false;
                AutomaticMigrationDataLossAllowed = false;
            }

            protected override void Seed(TContext context)
            {
                DataSeedInitializer.Seed(context);
                base.Seed(context);
            }
        }
        internal static class DataSeedInitializer
        {
            public static void Seed(TContext context)
            {
                context.SaveChanges();
            }
        }
    }
}
