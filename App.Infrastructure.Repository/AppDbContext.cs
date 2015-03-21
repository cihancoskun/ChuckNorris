using System.Data.Entity;

using App.Domain.Entities;

namespace App.Infrastructure.Repository
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        //public DbSet<Device> Devices { get; set; }
        //public DbSet<DeviceTag> DeviceTags { get; set; }
        //public DbSet<SmsQueue> SmsQueues { get; set; }
        //public DbSet<MailEater> MailEaters { get; set; }
        //public DbSet<Log> Logs { get; set; }
        //public DbSet<SmsInformation> Infos { get; set; }

        public AppDbContext(string connectionStringOrName)
            : base(connectionStringOrName)
        {
            Database.SetInitializer(new AppDbInitializer());
        }

        public AppDbContext()
            : this("name=AppConnectionString")
        {
        }
    }
}