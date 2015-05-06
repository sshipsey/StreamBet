using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;

namespace StreamBet.Models
{
    public class StreamerDbContext : DbContext
    {
        public DbSet<Streamer> Streamers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Startup.Configuration.Get("Data:DefaultConnection: ConnectionString"));
        }
    }
}
