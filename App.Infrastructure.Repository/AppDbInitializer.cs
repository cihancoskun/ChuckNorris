using System.Data.Entity;

namespace App.Infrastructure.Repository
{
    public class AppDbInitializer : MigrateDatabaseToLatestVersion<AppDbContext,AppDbMigrationConfiguration>
    { 
    }
}