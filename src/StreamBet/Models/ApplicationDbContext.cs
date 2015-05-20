using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;

namespace StreamBet.Models
{
    public class ApplicationDbContext : DbContext
    {
        private static bool _created;

        public ApplicationDbContext()
        {
            // Create the database and schema if it doesn't exist
            if (!_created)
            {
                Database.AsRelational().ApplyMigrations();
                _created = true;
            }
        }

        public DbSet<Streamer> Streamers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Streamer>().Ignore(m => m.IsLive);
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
