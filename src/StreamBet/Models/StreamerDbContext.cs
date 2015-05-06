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
            //options.UseSqlServer(Startup.Configuration.Get("Data:DefaultConnection: ConnectionString"));
            options.UseSqlServer("Server=tcp:streambet.database.windows.net,1433;Database=StreamBet;User ID=sshipsey@streambet;Password=xxxx;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;");
        }
    }
}
